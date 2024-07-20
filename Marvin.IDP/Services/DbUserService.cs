using IdentityServer.DbContexts;
using IdentityServer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace IdentityServer.Services
{
    public interface IDbUserService
    {
        Task<bool> ValidateCredentialsAsync(string userName,string password);
        Task<IEnumerable<UserClaim>> GetUserClaimsBySubjectAsync(string subject);
        Task<User?> GetUserByUserNameAsync(string userName);
        Task<UserSecret?> GetUserSecretAsync(string subject, string name);
        Task<User?> GetUserBySubjectAsync(string subject);
        void AddUser(User userToAdd, string password);
        Task<bool> IsUserActive(string subject);
        Task<bool> SaveChangesAsync();
        Task<bool> ActivateUserAsync(string securityCode);
        Task<bool> AddUserSecret(string subject, string name, string secret);
        Task<User?> FindUserByExternalProvider(string providerName, string providerIdentityKey);
        Task<User> AddProvisionUser(string providerName, string providerIdentityKey, IEnumerable<Claim> claims);
    }
    public class DbUserService : IDbUserService
    {
        private readonly IdentityDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        public DbUserService(IdentityDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public async Task<bool> IsUserActive(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                return false;
            }

            var user = await GetUserBySubjectAsync(subject);
            var externalUser = await IsThereAnyExternalUser(subject);

            if(externalUser)
            {
                return true;
            }

            if (user == null)
            {
                return false;
            }


            return user.Active;
        }

        private async Task<bool> IsThereAnyExternalUser(string subject)
        {
            return await _context.UserLogins.FirstOrDefaultAsync(x=>x.ProviderIdentityKey == subject) != null;
        }

        public async Task<bool> ValidateCredentialsAsync(string userName,
          string password)
        {
            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var user = await GetUserByUserNameAsync(userName);

            if (user == null)
            {
                return false;
            }

            if (!user.Active)
            {
                return false;
            }

            // Validate credentials
            //return (user.Password == password);
            var validationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            return (validationResult == PasswordVerificationResult.Success);
        }

        public async Task<User?> GetUserByUserNameAsync(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            return await _context.Users
                 .FirstOrDefaultAsync(x => x.UserName.ToLower() == userName.ToLower());
        }

        public async Task<IEnumerable<UserClaim>> GetUserClaimsBySubjectAsync(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException(nameof(subject));
            }

            return await _context.UserClaims.Where(u => u.User.Subject == subject).ToListAsync();
        }

        public async Task<User?> GetUserBySubjectAsync(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException(nameof(subject));
            }

            return await _context.Users.FirstOrDefaultAsync(u => u.Subject == subject);
        }

        public void AddUser(User userToAdd, string password)
        {
            if (userToAdd == null)
            {
                throw new ArgumentNullException(nameof(userToAdd));
            }

            if (_context.Users.Any(u => u.UserName == userToAdd.UserName))
            {
                // in a real-life scenario you'll probably want to 
                // return this as a validation issue
                throw new Exception("Username must be unique");
            }

            if (_context.Users.Any(u => u.Email == userToAdd.Email))
            {
                throw new Exception("Email must be unique");
            }

            userToAdd.SecurityCode = Convert.ToBase64String(RandomNumberGenerator.GetBytes(128));
            userToAdd.SecurityExpirationDate = DateTime.UtcNow.AddHours(1);
            userToAdd.Password = _passwordHasher.HashPassword(userToAdd, password);
            _context.Users.Add(userToAdd);
        }


        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> ActivateUserAsync(string securityCode)
        {
            if (string.IsNullOrWhiteSpace(securityCode))
            {
                throw new ArgumentNullException(nameof(securityCode));
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.SecurityCode == securityCode && x.SecurityExpirationDate >= DateTime.UtcNow);

            if(user == null) { return false; }

            user.Active = true;
            user.SecurityCode = null;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddUserSecret(string subject, string name, string secret)
        {
            if(string.IsNullOrWhiteSpace(subject)) { throw new ArgumentNullException(nameof(subject)); }
            if(string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(name)); }
            if(string.IsNullOrWhiteSpace(secret)) { throw new ArgumentNullException(nameof(secret)); }

            var user = await GetUserBySubjectAsync(subject);
            if(user == null)
            {
                return false;
            }
            else
            {
                user.UserSecrets.Add(new UserSecret()
                {
                    Name = name,
                    Secret = secret
                });
                return true;
            }
        }

        public async Task<UserSecret?> GetUserSecretAsync(string subject, string name)
        {
            if (string.IsNullOrWhiteSpace(subject)) { throw new ArgumentNullException(nameof(subject)); }
            if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(name)); }
            return await _context.UserSecrets.FirstOrDefaultAsync(x => x.Name == name && x.User.Subject == subject);
        }

        public async Task<User?> FindUserByExternalProvider(string providerName, string providerIdentityKey)
        {
            if (string.IsNullOrWhiteSpace(providerName)) { throw new ArgumentNullException(nameof(providerName)); }
            if (string.IsNullOrWhiteSpace(providerIdentityKey)) { throw new ArgumentNullException(nameof(providerIdentityKey)); }

            var loginUser =  await _context.UserLogins.Include(u => u.User)
                .FirstOrDefaultAsync(x => x.Provider == providerName && x.ProviderIdentityKey == providerIdentityKey);

            return loginUser?.User;

        }

        public async Task<User> AddProvisionUser(string providerName, string providerIdentityKey, IEnumerable<Claim> claims)
        {
            if (string.IsNullOrWhiteSpace(providerName)) { throw new ArgumentNullException(nameof(providerName)); }
            if (string.IsNullOrWhiteSpace(providerIdentityKey)) { throw new ArgumentNullException(nameof(providerIdentityKey)); }
            if (claims == null) { throw new ArgumentNullException(nameof(claims)); }

            var user = new User
            {
                Active = true,
                Subject = Guid.NewGuid().ToString(),
            };

            foreach(var claim in claims)
            {
                user.UserClaims.Add(new UserClaim()
                {
                    Value = claim.Value,
                    Type = claim.Type,
                });
            }

            user.UserLogins.Add(new UserLogin() { Provider = providerName, ProviderIdentityKey = providerIdentityKey });
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
