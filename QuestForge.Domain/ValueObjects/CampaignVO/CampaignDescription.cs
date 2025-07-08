using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Domain.ValueObjects.CampaignVO
{
    public sealed record CampaignDescription
    {
        public string Value { get; } = string.Empty;

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
            return new CampaignDescription(value);
        }
    }
}
