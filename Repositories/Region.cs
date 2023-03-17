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

        public async Task<IEnumerable<RegionTable>> AddRegion(RegionTable newRegion)
        {
            newRegion.Id = Guid.NewGuid();
            await _db.AddAsync(newRegion);
            await _db.SaveChangesAsync();
            List<RegionTable> regions = await _db.Regions.ToListAsync();
            return regions;
        }

        public async Task<RegionTable> DeleteRegion(Guid id)
        {
            Model.RegionTable region = await _db.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if(region == null)
            {
                return null;
            }
            _db.Regions.Remove(region);
            await _db.SaveChangesAsync();
            return region;
        }

        public async Task<RegionTable> GetRegion(Guid id)
        {
            Model.RegionTable region = await _db.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (_db.Regions.Contains(region))
                return region;

            return null;
        }

        public async Task<IEnumerable<RegionTable>> GetRegions()
        {
            List<RegionTable> regions = await _db.Regions.ToListAsync();

            return regions;
        }

        public async Task<RegionTable> UpdateRegion(Guid id, RegionTable existingRegion)
        {
            Model.RegionTable ExistingRegion = await _db.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (ExistingRegion == null)
            {
                return null;
            }
            ExistingRegion.Code = existingRegion.Code;
            ExistingRegion.Name = existingRegion.Name;
            ExistingRegion.Area = existingRegion.Area;
            ExistingRegion.Latitude = existingRegion.Latitude;
            ExistingRegion.Longitude = existingRegion.Longitude;
            ExistingRegion.Population = existingRegion.Population;

            await _db.SaveChangesAsync();
            return ExistingRegion;

        }
    }
}
