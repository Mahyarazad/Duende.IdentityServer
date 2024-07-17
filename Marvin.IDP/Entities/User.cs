using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Entities
{
    public class User : IConcurrencyAware
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Subject { get; set; }
        [Required]
        public bool Active { get; set; }
        [MaxLength(200)]
        public string UserName { get; set; }
        [MaxLength(200)]
        public string Password { get; set; }
        [ConcurrencyCheck]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
        public ICollection<UserClaim> UserClaims { get; set; } = new List<UserClaim>();
        public ICollection<UserSecret> UserSecrets { get; set; } = new List<UserSecret>();

        [MaxLength(200)]
        public string? SecurityCode { get; set; }
        [MaxLength(200)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime SecurityExpirationDate { get; set; }
    }
}
