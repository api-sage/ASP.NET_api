using System.ComponentModel.DataAnnotations;

namespace crudapi.Model
{
    public class WalksTable
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }

        ///Navigation Properties
        public RegionTable Region { get; set; }
        public WalksDifficultyTable WalksDifficulty { get; set; }
    }
}
