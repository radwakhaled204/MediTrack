using System.ComponentModel.DataAnnotations;

namespace MediTrack.Core.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        [Required]
        public string user_name { get; set; }

        public byte[] password_hash { get; set; }
        public byte[] password_salt { get; set; }
        [Required]
        public string email { get; set; }

        public DateTime joinedDate { get; set; }
        public string role { get; set; }



    }
}
