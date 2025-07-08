namespace QuestForge.Infrastructure.Models
{
    public class ItemTypeModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public List<ItemModel> Items { get; init; } = [];
    }
}
