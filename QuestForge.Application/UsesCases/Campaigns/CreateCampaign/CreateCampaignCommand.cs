using MediatR;

namespace QuestForge.Application.UsesCases.Campaigns.CreateCampaign
{
    public sealed record CreateCampaignCommand : IRequest<Guid>
    {
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;

        public CreateCampaignCommand(string name, string description)
        {
            Name  = name;
            Description = description;
        }
    }
}
