using crudapi.Model;
using Microsoft.EntityFrameworkCore;

namespace crudapi.DBContext
{
    public class CRUDDbContext : DbContext
    {
        public CRUDDbContext(DbContextOptions<CRUDDbContext> options)
            :base(options)
        {
        }

        public DbSet<RegionTable> Regions { get; set; }
        public DbSet<WalksTable> Walks { get; set; }
        public DbSet<WalksDifficultyTable> WalksDifficulty { get; set; }
    }
}
