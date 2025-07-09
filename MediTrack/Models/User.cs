using System.ComponentModel.DataAnnotations;

namespace MediTrack.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        [Required]
        public string user_name { get; set; }
        [Required]
        public string password { get; set; }
        public byte[] password_hash { get; set; }
        public byte[] password_salt { get; set; }
        [Required]
        public string email { get; set; }
        public string user_code { get; set; }
        public int phone_num { get; set; }



    }
}
