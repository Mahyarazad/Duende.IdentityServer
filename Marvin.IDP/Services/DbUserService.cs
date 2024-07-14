using IdentityServer.DbContexts;
using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Services
{
    public interface IDbUserService
    {
        Task<bool> ValidateCredentialsAsync(string userName,string password);

        Task<IEnumerable<UserClaim>> GetUserClaimsBySubjectAsync(string subject);

        Task<User?> GetUserByUserNameAsync(string userName);

        Task<User?> GetUserBySubjectAsync(string subject);

        void AddUser(User userToAdd);

        Task<bool> IsUserActive(string subject);

        Task<bool> SaveChangesAsync();
    }
    public class DbUserService : IDbUserService
    {
        private readonly IdentityDbContext _context;

        public DbUserService(IdentityDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> IsUserActive(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                return false;
            }

            var user = await GetUserBySubjectAsync(subject);

            if (user == null)
            {
                return false;
            }

            return user.Active;
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
            return (user.Password == password);
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

        public void AddUser(User userToAdd)
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

            _context.Users.Add(userToAdd);
        }


        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
