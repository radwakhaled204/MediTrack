using System.ComponentModel.DataAnnotations;

namespace MediTrack.Dtos
{
    public class RegisterDto
    {
        [StringLength(20, MinimumLength = 3 ,ErrorMessage = "Enter Name Between 3 And 20 Character")]
        public string user_name { get; set; }

        [EmailAddress(ErrorMessage = "Please Enter A Valid Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public string password { get; set; }
    }
}
