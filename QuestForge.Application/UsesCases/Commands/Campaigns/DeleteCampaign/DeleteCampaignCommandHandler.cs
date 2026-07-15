using MediatR;
using QuestForge.Domain.Campaigns;

namespace QuestForge.Application.UsesCases.Commands.Campaigns.DeleteCampaign
{
    public sealed record DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommand, bool>
    {
        private readonly ICampaignRepository _repository;

        public DeleteCampaignCommandHandler(ICampaignRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaign = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (campaign is null)
            {
                return false;
            }

            await _repository.DeleteAsync(campaign, cancellationToken);
            return true;
        }
    }
}
