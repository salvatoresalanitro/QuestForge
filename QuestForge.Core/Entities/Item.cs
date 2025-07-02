namespace QuestForge.Core.Entities
{
    public class Item
    {
        public Guid Id { get; init; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int TypeId { get; private set; }
        public ItemType Type { get; private set; } = null!;
        public Character OwnerCharacter { get; private set; } = null!;
        public Guid OwnerCharacterId { get; private set; }
        public Campaign Campaign { get; private set; } = null!;
        public Guid CampaignId { get; private set; }

        private Item(string name, string description, int typeId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            TypeId = typeId;
        }

        public static Item Create(string name, string description, int typeId)
        {
            return new Item(name, description, typeId);
        }
    }
}
