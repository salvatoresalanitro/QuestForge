using MediatR;
using QuestForge.DTOs.DTOsCampaign;

namespace QuestForge.Application.UsesCases.Queries.Campaigns.GetAllCampaigns
{
    public sealed record GetAllCampaignsQuery : IRequest<IEnumerable<CampaignDto>> { }
}
