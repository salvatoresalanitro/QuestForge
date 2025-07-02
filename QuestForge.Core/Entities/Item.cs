namespace QuestForge.Core.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ItemTypeId { get; private set; }
        public ItemType ItemType { get; private set; } = null!;
        public Character OwnerCharacter { get; set; } = null!;
        public Guid OwnerCharacterId { get; set; }
        public Campaign Campaign { get; set; } = null!;
        public Guid CampaignId { get; set; }
    }
}
