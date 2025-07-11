using MediatR;
using QuestForge.Domain.Campaigns;

namespace QuestForge.Application.UsesCases.Commands.Campaigns.CreateCampaign
{
    public sealed class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Guid>
    {
        private readonly ICampaignRepository _repository;

        public CreateCampaignCommandHandler(ICampaignRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaign = Campaign.Create(
                request.Name,
                request.Description
            );

            await _repository.CreateAsync(campaign, cancellationToken);

            return campaign.Id.Value;
        }
    }
}
