using crudapi.DBContext;
using crudapi.Model;
using Microsoft.EntityFrameworkCore;

namespace crudapi.Repositories
{
    public class Walk : IWalk
    {
        private readonly CRUDDbContext _db;

        public Walk(CRUDDbContext db)
        {
            _db = db;
        }

        public async Task<WalksTable> AddWalk(WalksTable walk)
        {
            walk.Id = Guid.NewGuid();
            await _db.Walks.AddAsync(walk);
            await _db.SaveChangesAsync();
            return walk;
        }

        public async Task<IEnumerable<WalksTable>> AllWalksAsync()
        {
            List<WalksTable> Walks = await _db.Walks
                .Include(r => r.Region)
                .Include(r => r.WalksDifficulty)
                .ToListAsync();
            return Walks;
        }
        public async Task<WalksTable> GetWalkAsync(Guid id)
        {
            Model.WalksTable Walk = await _db.Walks
                .Include(r => r.Region)
                .Include(r => r.WalksDifficulty)
                .FirstOrDefaultAsync(w => w.Id == id);
            return Walk;
        }

        public async Task<WalksTable> UpdateWorkAsync(Guid id, Model.WalksTable existingWalk)
        {
            Model.WalksTable ExistingWalk = await _db.Walks.FirstOrDefaultAsync(w => w.Id == id);
            if (ExistingWalk==null)
            {
                return null;
            }

            ExistingWalk.Name=existingWalk.Name;
            ExistingWalk.Length=existingWalk.Length;

            await _db.SaveChangesAsync();
            return ExistingWalk;
            
        }
        public async Task<WalksTable> DeleteWalkAsync(Guid id)
        {
            Model.WalksTable Walk = await _db.Walks.FirstOrDefaultAsync(w=>w.Id==id);
            if (Walk == null)
                return null;
            _db.Walks.Remove(Walk);
            await _db.SaveChangesAsync();
            return Walk;

        }
    }
}
