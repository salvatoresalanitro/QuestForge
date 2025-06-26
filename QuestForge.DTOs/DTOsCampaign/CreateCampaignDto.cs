using System.ComponentModel.DataAnnotations;

namespace QuestForge.DTOs.DTOsCampaign
{
    public class CreateCampaignDto
    {
        [Required(ErrorMessage = "Name must be between 3 and 100 characters")]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
