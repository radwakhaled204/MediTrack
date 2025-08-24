using System.ComponentModel.DataAnnotations;
namespace MediTrack.Core.Models
{
    public class Insurance
    {
        [Key]
        public int insurance_id { get; set; }
        public string provider_name { get; set; }
        public string coverage_details { get; set; }
        public int policy_num { get; set; }
        public DateTime valid_from { get; set; }
        public DateTime valid_to { get; set; }

    }
}
