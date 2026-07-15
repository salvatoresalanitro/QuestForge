using MediatR;
using QuestForge.DTOs.DTOsCampaign;

namespace QuestForge.Application.UsesCases.Queries.Campaigns.GetCampaignById
{
    public sealed record GetCampaignByIdQuery : IRequest<CampaignDto>
    {
        public Guid Id { get; }

        public GetCampaignByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}