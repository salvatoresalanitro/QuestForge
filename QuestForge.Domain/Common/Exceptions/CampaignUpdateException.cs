namespace QuestForge.Domain.Common.Exceptions
{
    public class CampaignUpdateException : DomainException
    {
        public CampaignUpdateException() { }

        public CampaignUpdateException(string message) : base(message) { }

        public CampaignUpdateException(string message, Exception innerException) : base(message, innerException) { }
    }
}
