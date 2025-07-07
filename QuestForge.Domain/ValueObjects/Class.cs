namespace QuestForge.Domain.ValueObjects
{
    public record Class
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public List<SubClass> SubClasses { get; private set; } = [];
    }
}
