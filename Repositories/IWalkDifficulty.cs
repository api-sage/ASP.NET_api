using crudapi.Model;

namespace crudapi.Repositories
{
    public interface IWalkDifficulty
    {
        Task<IEnumerable<WalksDifficultyTable>> GetAllAsync();
        Task<WalksDifficultyTable> GetWalkDifficultyAsync(Guid id);
        Task<WalksDifficultyTable> AddWalkDifficultyAsync(Model.WalksDifficultyTable newDifficulty);
        Task<WalksDifficultyTable> UpdateWalkDifficultyAsync(Guid id, Model.WalksDifficultyTable existingWalk);
        Task<WalksDifficultyTable> DeleteAsync(Guid id);
    }
}
