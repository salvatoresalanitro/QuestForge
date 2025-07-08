namespace QuestForge.Domain.ValueObjects
{
    public record Species
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public List<SubSpecies> SubSpecies { get; init; } = [];
    }
}
