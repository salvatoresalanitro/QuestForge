namespace QuestForge.Infrastructure.Models
{
    public class SpeciesModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public List<SubSpeciesModel> SubSpecies { get; init; } = [];
    }
}
