using MediatR;
using QuestForge.DTOs.DTOsCampaign;

namespace QuestForge.Application.UsesCases.Commands.Campaigns.UpdateCampaign
{
    public sealed record UpdateCampaignCommand : IRequest<CampaignDto>
    {
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;

        public UpdateCampaignCommand(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
