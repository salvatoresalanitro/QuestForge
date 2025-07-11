namespace QuestForge.Domain.Campaigns
{
    public interface ICampaignRepository
    {
        Task<Campaign?> GetByIdAsync(Guid campaignId);
        Task<IEnumerable<Campaign>> GetAllAsync();
        Task CreateAsync(Campaign campaign, CancellationToken cancellationToken);
        Task UpdateAsync(Campaign campaign);
        Task DeleteAsync(Campaign campaign);
    }
}
