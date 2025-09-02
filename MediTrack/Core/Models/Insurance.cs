using System.ComponentModel.DataAnnotations;

namespace MediTrack.Core.Models
{
    public class Insurance
    {
        [Key]
        public int InsuranceId { get; set; }
        public string ProviderName { get; set; }
        public string CoverageDetails { get; set; }
        public int PolicyNum { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
