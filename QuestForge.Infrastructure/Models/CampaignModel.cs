namespace QuestForge.Infrastructure.Models
{
    public class CampaignModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<CharacterModel> Characters { get; set; } = [];
        public List<ItemModel> Items { get; set; } = [];
    }
}
