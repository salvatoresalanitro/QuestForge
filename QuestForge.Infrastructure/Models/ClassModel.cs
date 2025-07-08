namespace QuestForge.Infrastructure.Models
{
    public class ClassModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public List<SubClassModel> SubClasses { get; init; } = [];
    }
}
