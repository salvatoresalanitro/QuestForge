namespace QuestForge.Infrastructure.Models
{
    public class CharacterModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public SpeciesModel Species { get; init; } = null!;
        public ClassModel Class { get; init; } = null!;
        public int Level { get; init; }
        public int HitPoints { get; init; }
        public int ArmorClass { get; init; }
        public List<ItemModel> Items { get; init; } = [];
        public CampaignModel? Campaign { get; init; }
    }
}
