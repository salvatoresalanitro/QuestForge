using QuestForge.Domain.Campaigns.CampaignVO;
using QuestForge.Domain.Characters;
using QuestForge.Domain.Items;

namespace QuestForge.Domain.Campaigns
{
    public class Campaign
    {
        public CampaignId Id { get; }
        public CampaignName Name { get; }
        public CampaignDescription Description { get; }
        private List<Character> _characters = [];
        public IReadOnlyCollection<Character> Characters => _characters;
        private readonly List<Item> _items = [];
        public IReadOnlyCollection<Item> Items => _items;
        //public List<Npc> Npcs { get; init; }
        //public List<Enemy> Enemies { get; init; }

        private Campaign (string name, string description)
        {
            Id = CampaignId.Create();
            Name = CampaignName.Create(name);
            Description = CampaignDescription.Create(description);
        }

        public static Campaign Create(string name, string description)
        {
            return new Campaign (name, description);
        }
    }
}
