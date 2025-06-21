using AutoMapper;
using QuestForge.Core.Entities;
using QuestForge.DTOs.DTOsCampaign;

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
