using crudapi.Model;

namespace crudapi.Repositories
{
    public interface IWalk
    {
        Task<IEnumerable<WalksTable>> AllWalksAsync();
        Task<WalksTable> GetWalkAsync(Guid id);
        Task<WalksTable> AddWalk(WalksTable walk);
        Task<WalksTable> UpdateWorkAsync(Guid id, Model.WalksTable existingWalk);
        Task<WalksTable> DeleteWalkAsync(Guid id);
    }
}
