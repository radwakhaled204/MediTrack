using System.ComponentModel.DataAnnotations;

namespace MediTrack.Core.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string? PatientCode { get; set; }
        public string? PhoneNum { get; set; }
        public string? NationalId { get; set; }
        public string? Address { get; set; }

        // FK + Navigation property
        public int? UserId { get; set; }
        public User User { get; set; }

        public int? InsuranceId { get; set; }
        public Insurance Insurance { get; set; }
    }
}
