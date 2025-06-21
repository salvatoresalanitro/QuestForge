using QuestForge.Core.Entities;

namespace QuestForge.Core.DTOs.DTOsCampaign
{
    public class CampaignDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Character>? Characters { get; set; }
        public List<Item>? Items { get; set; }
        public List<Npc>? Npcs { get; set; }
        public List<Enemy>? Enemies { get; set; }
    }
}
