namespace QuestForge.Core.Entities
{
    public class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Species Species { get; set; }
        public Class Class { get; set; }
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public int ArmorClass { get; set; }
        public List<Item> Items { get; set; } = [];
        public Campaign? Campaign { get; set; }
        public Guid CampaignId { get; set; }
    }
}
