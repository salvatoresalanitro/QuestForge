namespace QuestForge.Domain.Campaigns
{
    public interface ICampaignRepository
    {
        Task<Campaign?> GetByIdAsync(Guid campaignId, CancellationToken cancellationToken);
        Task<IEnumerable<Campaign>> GetAllAsync(CancellationToken cancellationToken);
        Task CreateAsync(Campaign campaign, CancellationToken cancellationToken);
        Task UpdateAsync(Campaign campaign, CancellationToken cancellationToken);
        Task DeleteAsync(Campaign campaign);
    }
}
