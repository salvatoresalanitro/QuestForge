namespace QuestForge.Infrastructure.Models
{
    public class CampaignModel
    {
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public List<CharacterModel> Characters = [];
        public List<ItemModel> Items = [];
    }
}
