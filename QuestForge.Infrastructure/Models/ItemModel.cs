namespace QuestForge.Infrastructure.Models
{
    public class ItemModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public ItemTypeModel Type { get; init; } = null!;
        public CharacterModel? Character { get; init; }
        public CampaignModel? Campaign { get; init; }
    }
}
