using QuestForge.Core.Entities;

namespace QuestForge.Infrastructure.Models
{
    public class ItemModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public ItemType Type { get; init; } = null!;
        public Character? Character { get; init; }
        public Campaign? Campaign { get; init; } = null!;
    }
}
