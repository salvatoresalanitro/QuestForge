namespace QuestForge.Infrastructure.Models
{
    public class CharacterModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public int Level { get; init; }
        public int HitPoints { get; init; }
        public int ArmorClass { get; init; }
        public SpeciesModel Species { get; init; } = null!;
        public int SpeciesId { get; init; }
        public int ClassId { get; init; }
        public ClassModel Class { get; init; } = null!;
        public List<ItemModel> Items { get; init; } = [];
        public CampaignModel? Campaign { get; init; }
    }
}
