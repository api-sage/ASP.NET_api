using crudapi.Model;

namespace crudapi.Repositories
{
    public interface IRegion
    {
        Task<IEnumerable<RegionTable>> GetRegions();
        Task<RegionTable> GetRegion(Guid id);
        Task<IEnumerable<RegionTable>> AddRegion(RegionTable newRegion);
        Task<RegionTable> DeleteRegion(Guid id);
        Task<RegionTable> UpdateRegion(Guid id, RegionTable existingRegion);

    }
}
