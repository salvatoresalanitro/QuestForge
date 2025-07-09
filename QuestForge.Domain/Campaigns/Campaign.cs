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
        private Campaign(
            Guid id,
            string name,
            string description,
            List<Character> characters,
            List<Item> items
        )
        {
            Id = CampaignId.Create(id);
            Name = CampaignName.Create(name);
            Description = CampaignDescription.Create(description);
            _characters = characters;
            _items = items;
        }

        public static Campaign Create(
            Guid id,
            string name,
            string description,
            List<Character> characters,
            List<Item> items
        )
        {
            return new Campaign(id, name, description, characters, items);
        }

        public static Campaign Reconstitute(
            CampaignId id,
            CampaignName name,
            CampaignDescription description,
            List<Character> characters,
            List<Item> items
        )
        {
            return new Campaign(
                id.Value,
                name.Value,
                description.Value,
                characters,
                items
            );
        }
    }
}
