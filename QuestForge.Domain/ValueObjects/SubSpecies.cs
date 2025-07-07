namespace QuestForge.Domain.ValueObjects
{
    public record SubSpecies
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}