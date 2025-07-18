using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Domain.Campaigns.CampaignVO
{
    public sealed record CampaignDescription
    {
        public string Value { get; private set; } = string.Empty;

        private CampaignDescription(string value)
        {
            if(value.Length > 500)
            {
                throw new CampaignCreationException("Description cannot exceed 500 characters.");
            }

            Value = value;
        }

        public static CampaignDescription Create(string value)
        {
            return new CampaignDescription(value.Trim());
        }

        public void Update(string value)
        {
            Value = value.Trim();
        }

        public override string ToString() => Value;
    }
}
