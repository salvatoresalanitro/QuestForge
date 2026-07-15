namespace QuestForge.Infrastructure.Models
{
    public class SubSpeciesModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public int SpeciesId { get; init; }
        public SpeciesModel Species { get; init; } = null!;
    }
}