namespace QuestForge.Infrastructure.Models
{
    public class SubClassModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public int ClassId { get; init; }
        public ClassModel Class { get; init; } = null!;
    }
}