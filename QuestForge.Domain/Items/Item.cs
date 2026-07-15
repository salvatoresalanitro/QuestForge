using QuestForge.Domain.Campaigns;
using QuestForge.Domain.Characters;
using QuestForge.Domain.Items.ItemVO;
using QuestForge.Domain.ValueObjects;

namespace QuestForge.Domain.Items
{
    public class Item
    {
        public ItemId Id { get; }
        public ItemName Name { get; }
        public ItemDescription Description { get; }
        public ItemType Type { get; }
        public Character? Character { get; }
        public Campaign? Campaign { get; }

        private Item(
            Guid id,
            string name,
            string description,
            ItemType type
        )
        {
            Id = ItemId.Create(id);
            Name = ItemName.Create(name);
            Description = ItemDescription.Create(description);
            Type = type;
        }

        public static Item Create(
            Guid id,
            string name,
            string description,
            ItemType type
        )
        {
            return new Item(id, name, description, type);
        }
    }
}
