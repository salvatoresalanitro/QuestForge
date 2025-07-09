namespace QuestForge.Infrastructure.Models
{
    public class CampaignModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public List<CharacterModel> Characters { get; init; } = [];
        public List<ItemModel> Items { get; init; } = [];
    }
}
