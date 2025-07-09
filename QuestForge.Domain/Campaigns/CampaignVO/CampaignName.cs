using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Domain.Campaigns.CampaignVO
{
    public sealed record CampaignName
    {
        public string Value { get; }

        private CampaignName(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new CampaignCreationException("Name cannot be empty.");
            }

            if(value.Length < 5)
            {
                throw new CampaignCreationException("Name cannot be less than 5 characters.");
            }

            if(value.Length > 100)
            {
                throw new CampaignCreationException("Name cannot exceed 100 characters.");
            }

            Value = value.Trim();
        }

        public static CampaignName Create(string value)
        {
            return new CampaignName(value);
        }

        public override string ToString() => Value;
    }
}
