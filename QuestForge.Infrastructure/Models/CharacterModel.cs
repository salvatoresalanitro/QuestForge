namespace QuestForge.Infrastructure.Models
{
    public class CharacterModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public int ArmorClass { get; set; }
        public SpeciesModel Species { get; set; } = null!;
        public int SpeciesId { get; set; }
        public int ClassId { get; set; }
        public ClassModel Class { get; set; } = null!;
        public List<ItemModel> Items { get; init; } = [];
        public CampaignModel? Campaign { get; set; }
    }
}
