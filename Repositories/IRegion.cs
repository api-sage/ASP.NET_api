using crudapi.Model;

namespace crudapi.Repositories
{
    public interface IRegion
    {
        Task<IEnumerable<RegionTable>> GetRegions();
        Task<RegionTable> GetRegion(Guid id);
    }
}
