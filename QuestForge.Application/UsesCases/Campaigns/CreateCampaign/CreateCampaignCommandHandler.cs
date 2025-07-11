using MediatR;
using QuestForge.Domain.Campaigns;

namespace QuestForge.Application.UsesCases.Campaigns.CreateCampaign
{
    public sealed class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand>
    {
        private readonly ICampaignRepository _repository;

        public CreateCampaignCommandHandler(ICampaignRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            var toBeCreated = Campaign.Create(
                request.Name,
                request.Description
            );

            await _repository.CreateAsync(toBeCreated, cancellationToken);
        }
    }
}
