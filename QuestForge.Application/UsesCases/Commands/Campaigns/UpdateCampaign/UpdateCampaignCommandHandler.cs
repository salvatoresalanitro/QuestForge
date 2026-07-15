using MediatR;
using QuestForge.Application.Exceptions;
using QuestForge.Application.Mapping;
using QuestForge.Domain.Campaigns;
using QuestForge.DTOs.DTOsCampaign;

namespace QuestForge.Application.UsesCases.Commands.Campaigns.UpdateCampaign
{
    public sealed record UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, CampaignDto>
    {
        private readonly ICampaignRepository _repository;

        public UpdateCampaignCommandHandler(ICampaignRepository repository)
        {
            _repository = repository;
        }

        public async Task<CampaignDto> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaign = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if(campaign is null)
            {
                throw new CampaignNotFoundException("Campaign not found.");
            }

            campaign.Update(request.Name, request.Description);

            await _repository.UpdateAsync(campaign, cancellationToken);

            return CampaignMapper.ToDto(campaign);
        }
    }
}
