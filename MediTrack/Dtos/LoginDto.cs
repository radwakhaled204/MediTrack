using System.ComponentModel.DataAnnotations;

namespace MediTrack.Dtos
{
    public class LoginDto
    {
        [EmailAddress(ErrorMessage = "Please Enter A Valid Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public string password { get; set; }
    }
}
