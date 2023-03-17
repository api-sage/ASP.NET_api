using crudapi.DBContext;
using crudapi.Model;
using Microsoft.EntityFrameworkCore;

namespace crudapi.Repositories
{
    public class WalkDifficulty : IWalkDifficulty
    {
        private readonly CRUDDbContext _db;
        public WalkDifficulty(CRUDDbContext db) => _db = db;

        public async Task<WalksDifficultyTable> AddWalkDifficultyAsync(WalksDifficultyTable newDifficulty)
        {
            newDifficulty.Id = Guid.NewGuid();
            await _db.WalksDifficulty.AddAsync(newDifficulty);
            await _db.SaveChangesAsync();
            return newDifficulty;

        }

        public async Task<WalksDifficultyTable> DeleteAsync(Guid id)
        {
            Model.WalksDifficultyTable ToDelete = await _db.WalksDifficulty.FindAsync(id); 
            _db.WalksDifficulty.Remove(ToDelete);
            await _db.SaveChangesAsync();
            return ToDelete;
        }

        public async Task<IEnumerable<WalksDifficultyTable>> GetAllAsync()
        {
            List<Model.WalksDifficultyTable> Walks = await _db.WalksDifficulty.ToListAsync();
            return Walks;
        }

        public async Task<WalksDifficultyTable> GetWalkDifficultyAsync(Guid id)
        {
            Model.WalksDifficultyTable walk = await _db.WalksDifficulty.FindAsync(id);
            return walk;

        }

        public async Task<WalksDifficultyTable> UpdateWalkDifficultyAsync(Guid id, WalksDifficultyTable existingWalk)
        {
            var targetWalk = await _db.WalksDifficulty.FindAsync(id);
            if (targetWalk != null)
            {
                targetWalk.Code=existingWalk.Code;
                await _db.SaveChangesAsync();
                return targetWalk;
            }
            return null;
        }
    }
}
