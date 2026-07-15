using MediatR;

namespace QuestForge.Application.UsesCases.Commands.Campaigns.DeleteCampaign
{
    public sealed record DeleteCampaignCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public DeleteCampaignCommand(Guid id)
        {
            Id = id;
        }
    }
}
