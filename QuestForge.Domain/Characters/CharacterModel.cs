using QuestForge.Domain.Campaigns;
using QuestForge.Domain.Items;
using QuestForge.Domain.ValueObjects;

namespace QuestForge.Domain.Characters
{
    public class CharacterModel
    {
        public Guid Id { get; init; }
        public string Name { get; private set; } = string.Empty;
        public Species Species { get; private set; }
        public Class Class { get; private set; }
        public int Level { get; init; }
        public int HitPoints { get; init; }
        public int ArmorClass { get; init; }
        public List<ItemModel> Items { get; init; } = [];
        public CampaignModel Campaign { get; private set; }
        public Guid CampaignId { get; private set; }
    }
}
