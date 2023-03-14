using crudapi.DBContext;
using crudapi.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace crudapi.Repositories
{
    public class Region : IRegion
    {
        private readonly CRUDDbContext _db;
        public Region(CRUDDbContext db) => _db = db;

        public async Task<RegionTable> GetRegion(Guid id)
        {
            Model.RegionTable region = await _db.Regions.FirstOrDefaultAsync(r => r.Id == id);
            return region;
        }

        public async Task<IEnumerable<RegionTable>> GetRegions()
        {
            List<RegionTable> regions = await _db.Regions.ToListAsync();

            return regions;
        }
    }
}
