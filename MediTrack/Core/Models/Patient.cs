using System.ComponentModel.DataAnnotations;
namespace MediTrack.Core.Models
{
    public class Patient
    {
        [Key]
        public int patient_id { get; set; }
        public string full_name { get; set; }
        public DateTime birth_date { get; set; }
        public string gender { get; set; }
        public string? patient_code { get; set; }
        public int? phone_num { get; set; }
        public string? address { get; set; }
        public User user_id { get; set; }
        public Insurance insurance_id { get; set; }
    }
}
