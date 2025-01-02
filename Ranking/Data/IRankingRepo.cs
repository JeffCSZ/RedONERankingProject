using Ranking.DTOs;
using Ranking.Models;

namespace Ranking.Data
{
    public interface IRankingRepo
    {
        List<PointConfig> GetPoints();
        List<Tier> GetTier();
        void UpdateTier(TierDTO tierDTO);
        void UpdatePoint(PointDTO pointDTO);
        List<TotalUserInfo> GetTotalUser();
        void Recalculate();

    }
}
