using System.ComponentModel.DataAnnotations;
using MediTrack.Core.Models;

namespace MediTrack.WebAPI.Dtos
{
    public class PatientDto
    {
        [StringLength(60, MinimumLength = 10 , ErrorMessage = "Enter Your Name")]
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string? PatientCode { get; set; }
        [StringLength(11)]
        public string? PhoneNum { get; set; }
        [StringLength(14)]
        public string? NationalId { get; set; }
        public string? Address { get; set; }

        // FK + Navigation property
        public int? UserId { get; set; }
        public int? InsuranceId { get; set; }
    }
}
