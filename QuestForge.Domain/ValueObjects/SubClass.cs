namespace QuestForge.Domain.ValueObjects
{
    public record SubClass
    {
        public int Id { get; init; }
        public string Name { get; private set; } = string.Empty;
    }
}