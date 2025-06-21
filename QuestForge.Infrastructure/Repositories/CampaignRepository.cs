using Microsoft.EntityFrameworkCore;
using QuestForge.Core.Entities;
using QuestForge.Core.Interfaces.RepositoryInterfaces;
using QuestForge.Infrastructure.Data;

namespace QuestForge.Infrastructure.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly QuestForgeContext _context;

        public CampaignRepository(QuestForgeContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Campaign campaign)
        {
            await _context.Campaigns.AddAsync(campaign);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Campaign campaign)
        {
            _context.Campaigns.Remove(campaign);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Campaign>> GetAllAsync()
        {
            var campaigns = await _context.Campaigns.ToListAsync();

            return campaigns;
        }

        public async Task<Campaign?> GetByIdAsync(Guid campaignId)
        {
            var campaign = await _context.Campaigns.FirstOrDefaultAsync(c => c.Id == campaignId);
            return campaign;
        }

        public async Task<Campaign?> UpdateAsync(Campaign campaign)
        {
            var camp = await _context.Campaigns.FirstOrDefaultAsync(c => c.Id == campaign.Id);

            if(camp != null)
            {
                camp.Name = campaign.Name;
                camp.Description = campaign.Description;
                camp.Characters = campaign.Characters;
                camp.Items = campaign.Items;
                camp.Npcs = campaign.Npcs;
                camp.Enemies = campaign.Enemies;
            }

            await _context.SaveChangesAsync();

            return camp;
        }
    }
}
