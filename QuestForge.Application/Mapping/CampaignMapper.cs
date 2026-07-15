using QuestForge.Domain.Campaigns;
using QuestForge.DTOs.DTOsCampaign;

namespace QuestForge.Application.Mapping
{
    public static class CampaignMapper
    {
        public static CampaignDto ToDto(Campaign campaign)
        {
            return new CampaignDto
            {
                Id = campaign.Id.Value,
                Name = campaign.Name.Value,
                Description = campaign.Description.Value,
                Characters = campaign.Characters.Select(CharacterMapper.ToDto).ToList(),
                Items = campaign.Items.Select(ItemMapper.ToDto).ToList(),
            };
        }

        public static Campaign ToEntity(CreateCampaignDto dto)
        {
            return Campaign.Create(dto.Name, dto.Description ?? string.Empty);
        }
    }
}
