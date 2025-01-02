using Microsoft.EntityFrameworkCore;
using Ranking.Models;

namespace Ranking.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> o) : base(o)
        { }
        public DbSet<Tier> Tier { get; set; }
        public DbSet<PointConfig> PointConfig { get; set; }
        public DbSet<TotalUserInfo> TotalUserInfo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TotalUserInfo>().HasNoKey();
        }
    }
}
