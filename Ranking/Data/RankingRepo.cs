using Microsoft.EntityFrameworkCore;
using Ranking.DTOs;
using Ranking.Models;

namespace Ranking.Data
{
    public class RankingRepo(MyDBContext _dbContext) : IRankingRepo
    {
        public List<PointConfig> GetPoints()
        {
            return _dbContext.PointConfig.FromSqlRaw("EXEC sp_GetPointConfig").ToList();
        }

        public List<Tier> GetTier()
        {
            return _dbContext.Tier.FromSqlRaw("EXEC sp_GetTier").ToList();
        }

        public List<TotalUserInfo> GetTotalUser()
        {
            return _dbContext.TotalUserInfo.FromSqlRaw("EXEC sp_GetTotalUsersPerTier").ToList();
        }

        public void Recalculate()
        {
            _dbContext.Database.ExecuteSqlRaw("EXEC sp_Calculate");
        }

        public void UpdatePoint(PointDTO pointDTO)
        {
            //var p = _dbContext.PointConfig.FirstOrDefault(p => p.ConfigID == 1);
            //p.PointPerMonth = pointDTO.PointPerMonth;
            //p.PointPerRM = pointDTO.PointPerRM;
            // Execute the stored procedure
            _dbContext.Database.ExecuteSqlRaw(
                "EXEC sp_UpdatePointConfig @PointPerMonth = {0}, @PointPerRM = {1}",
                pointDTO.PointPerMonth, pointDTO.PointPerRM
            );

            // Fetch the updated data
            //_dbContext.SaveChanges();
        }

        public void UpdateTier(TierDTO tierDTO)
        {
            //var t = _dbContext.Tier.FirstOrDefault(t => t.TierName.ToUpper() == tierDTO.TierName.ToUpper());

            //t.TierMin = tierDTO.TierMin;
            //t.TierMax = tierDTO.TierMax;
            //_dbContext.SaveChanges();
            //return t;
            _dbContext.Database.ExecuteSqlRaw(
                "EXEC sp_UpdateTier @TierName = {0}, @TierMin = {1}, @TierMax = {2}",
                tierDTO.TierName, tierDTO.TierMin, tierDTO.TierMax
            );

            // Fetch the updated Tier object (optional, only if needed)
            //var updatedTier = _dbContext.Tier.FirstOrDefault(t => t.TierName.ToUpper() == tierDTO.TierName.ToUpper());
            //return updatedTier;
        }
    }
}
