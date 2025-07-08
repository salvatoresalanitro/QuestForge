namespace QuestForge.Domain.Common.Exceptions
{
    public class CampaignCreationException : DomainException
    {
        public CampaignCreationException() { }

        public CampaignCreationException(string message) : base(message) { }

        public CampaignCreationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
