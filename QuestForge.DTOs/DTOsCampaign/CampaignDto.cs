using QuestForge.DTOs.DTOsCharacter;
using QuestForge.DTOs.DTOsItem;

namespace QuestForge.DTOs.DTOsCampaign
{
    public class CampaignDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<CharacterDto>? Characters { get; set; }
        public List<ItemDto>? Items { get; set; }
    }
}
