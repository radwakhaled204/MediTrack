using System.ComponentModel.DataAnnotations;

namespace MediTrack.WebAPI.Dtos
{
    public class UserDto
    {
        [Required]
        public string user_name { get; set; }

        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }

    }
}
