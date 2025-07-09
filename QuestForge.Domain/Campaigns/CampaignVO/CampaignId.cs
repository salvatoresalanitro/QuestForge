namespace QuestForge.Domain.Campaigns.CampaignVO
{
    public record CampaignId
    {
        public Guid Id { get; init; }

        private CampaignId()
        {
            Id = Guid.NewGuid();
        }

        public static CampaignId Create()
        {
            return new CampaignId();
        }
    }
}
