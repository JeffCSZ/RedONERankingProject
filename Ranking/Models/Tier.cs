using System.ComponentModel.DataAnnotations;

namespace Ranking.Models
{
    public class Tier
    {
        [Key]
        public long TierID { get; set; }
        public string TierName { get; set; }
        public decimal TierMin { get; set; }
        public decimal TierMax { get; set; }
    }
}
