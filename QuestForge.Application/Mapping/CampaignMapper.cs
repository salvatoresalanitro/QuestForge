using QuestForge.Core.Entities;
using QuestForge.DTOs.DTOsCampaign;

namespace QuestForge.Application.Mapping
{
    public static class CampaignMapper
    {
        public static CampaignDto ToDto(Campaign campaign)
        {
            return new CampaignDto
            {
                Id = campaign.Id,
                Name = campaign.Name,
                Description = campaign.Description,
                Characters = campaign.Characters,
                Enemies = campaign.Enemies,
                Items = campaign.Items,
                Npcs = campaign.Npcs
            };
        }

        public static Campaign ToEntity(CreateCampaignDto dto)
        {
            return new Campaign
            {
                Name = dto.Name,
                Description = dto.Description,
            };
        }
    }
}
