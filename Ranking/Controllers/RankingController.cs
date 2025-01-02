using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ranking.Data;
using Ranking.DTOs;
using Ranking.Models;

namespace Ranking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController (IRankingRepo _rankingRepo) : ControllerBase
    {
        [HttpGet("GetTier")]
        public ActionResult<List<Tier>> GetTier()
        {
            var t = _rankingRepo.GetTier();
            return Ok(t);
        }

        [HttpPost("UpdateTier")]
        public ActionResult UpdateTier(TierDTO tierDTO)
        {
            _rankingRepo.UpdateTier(tierDTO);
            return Ok();
        }

        [HttpGet("GetPoint")]
        public ActionResult<List<PointConfig>> GetPoint()
        {
            var p = _rankingRepo.GetPoints();
            return Ok(p);
        }

        [HttpPost("UpdatePoint")]
        public ActionResult UpdatePoint(PointDTO pointDTO)
        {
            _rankingRepo.UpdatePoint(pointDTO);
            return Ok();
        }

        [HttpGet("GetTotalUserPerTier")]
        public ActionResult<List<TotalUserInfo>> GetTotalUserInfo()
        {
            var userInfo = _rankingRepo.GetTotalUser();
            return Ok(userInfo);
        }

        [HttpGet("Recalculate")]
        public ActionResult Recalculate()
        {
            _rankingRepo.Recalculate();
            return Ok();
        }
    }
}
