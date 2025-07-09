namespace QuestForge.Domain.Campaigns.CampaignVO
{
    public record CampaignId
    {
        public Guid Value { get; init; }

        private CampaignId(Guid value)
        {
            Value = value;
        }

        public static CampaignId Create()
            => Create(Guid.NewGuid());

        public static CampaignId Create(Guid id)
            => new CampaignId(id);
    }
}
