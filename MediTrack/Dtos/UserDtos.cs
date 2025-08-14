using System.ComponentModel.DataAnnotations;

namespace MediTrack.Dtos
{
    public class UserDtos
    {
        [Required]
        public string user_name { get; set; }

        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }

    }
}
