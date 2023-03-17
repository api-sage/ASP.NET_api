namespace crudapi.Model.DTO
{
    public class WalksTable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }

        public RegionTable Region { get; set; }
        public WalksDifficultyTable WalksDifficulty { get; set; }
    }
}
