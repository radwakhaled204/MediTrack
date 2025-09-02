using System.ComponentModel.DataAnnotations;

namespace MediTrack.Core.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime JoinedDate { get; set; }
        public string Role { get; set; }
    }
}
