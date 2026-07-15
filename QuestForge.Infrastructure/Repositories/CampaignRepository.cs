using Microsoft.EntityFrameworkCore;
using QuestForge.Domain.Campaigns;
using QuestForge.Infrastructure.Data;
using QuestForge.Infrastructure.Mapping;
using QuestForge.Infrastructure.Models;

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

        public async Task DeleteAsync(Campaign campaign, CancellationToken cancellationToken)
        {
            var modelTracked = _context.ChangeTracker.Entries<CampaignModel>()
                .First(model => model.Entity.Id == campaign.Id.Value).Entity;

            _context.Campaigns.Remove(modelTracked);
            await _context.SaveChangesAsync(cancellationToken);
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

        public async Task UpdateAsync(Campaign campaign, CancellationToken cancellationToken)
        {
            var modelTracked = _context.ChangeTracker.Entries<CampaignModel>()
                .First(model => model.Entity.Id == campaign.Id.Value).Entity;
            UpdateModelTracked(campaign, modelTracked);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private static void UpdateModelTracked(Campaign campaign, CampaignModel modelTracked)
        {
            modelTracked.Name = campaign.Name.Value;
            modelTracked.Description = campaign.Description.Value;

            modelTracked.Characters.Clear();
            modelTracked.Items.Clear();

            modelTracked.Characters.AddRange(campaign.Characters.Select(c => c.MapToModel()));
            modelTracked.Items.AddRange(campaign.Items.Select(i => i.MapToModel()));
        }
    }
}
