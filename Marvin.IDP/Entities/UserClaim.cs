using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Entities
{
    public class UserClaim : IConcurrencyAware
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(200)]
        [Required]
        public string Type { get; set; }
        [MaxLength(200)]
        [Required]
        public string Value { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [ConcurrencyCheck]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();   
    }
}
