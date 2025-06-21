using AutoMapper;
using QuestForge.Core.DTOs.DTOsCampaign;
using QuestForge.Core.Entities;

namespace QuestForge.API.Mappings
{
    public class CampaignProfile : Profile
    {
        public CampaignProfile()
        {
            CreateMap<Campaign, CampaignDto>();
            CreateMap<CreateCampaignDto, Campaign>();
        }
    }
}
