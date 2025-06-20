namespace QuestForge.Core.Entities
{
    public class Npc
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Campaign? Campaign { get; set; }
        public Guid CampaignId { get; set; }
    }
}
