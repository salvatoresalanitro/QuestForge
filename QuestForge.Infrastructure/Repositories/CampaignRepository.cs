using Microsoft.EntityFrameworkCore;
using QuestForge.Domain.Campaigns;
using QuestForge.Infrastructure.Data;
using QuestForge.Infrastructure.Mapping;

namespace QuestForge.Infrastructure.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly QuestForgeContext _context;

        public CampaignRepository(QuestForgeContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Campaign campaign, CancellationToken cancellationToken)
        {
            await _context.Campaigns.AddAsync(campaign.MapToModel(), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Campaign campaign)
        {
            _context.Campaigns.Remove(campaign.MapToModel());
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Campaign>> GetAllAsync(CancellationToken cancellationToken)
        {
            var campaigns = await _context.Campaigns.Select(c => c.MapToDomain()).ToListAsync(cancellationToken);

            return campaigns;
        }

        public async Task<Campaign?> GetByIdAsync(Guid campaignId, CancellationToken cancellationToken)
        {
            var campaign = await _context.Campaigns.FirstOrDefaultAsync(c => c.Id == campaignId, cancellationToken);
            return campaign?.MapToDomain();
        }

        public async Task UpdateAsync(Campaign campaign)
        {
            _context.Campaigns.Update(campaign.MapToModel());

            await _context.SaveChangesAsync();
        }
    }
}
