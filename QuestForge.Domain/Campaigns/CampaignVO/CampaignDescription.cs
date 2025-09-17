using System.ComponentModel.DataAnnotations;
using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Domain.Campaigns.CampaignVO
{
    public sealed record CampaignDescription
    {
        public string Value { get; private set; } = string.Empty;

        private CampaignDescription(string value)
        {
            if(value is null)
            {
                throw new CampaignCreationException("Null value on description.");
            }

            if(value.Length > 500)
            {
                throw new CampaignCreationException("Description cannot exceed 500 characters.");
            }

            Value = value.Trim();
        }

        public static CampaignDescription Create(string value)
        {
            return new CampaignDescription(value);
        }

        public void Update(string value)
        {
            if (value is null)
            {
                throw new CampaignUpdateException("Null value on description.");
            }

            if (value.Length > 500)
            {
                throw new CampaignUpdateException("Description cannot exceed 500 characters.");
            }

            Value = value.Trim();
        }

        public override string ToString() => Value;
    }
}
