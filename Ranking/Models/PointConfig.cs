using System.ComponentModel.DataAnnotations;

namespace Ranking.Models
{
    public class PointConfig
    {
        [Key]
        public long ConfigID { get; set; }
        public int PointPerMonth { get; set; }
        public int PointPerRM { get; set; }
    }
}
