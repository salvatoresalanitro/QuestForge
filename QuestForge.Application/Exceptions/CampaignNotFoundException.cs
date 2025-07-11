namespace QuestForge.Application.Exceptions
{
    public class CampaignNotFoundException : ApplicationException
    {
        public CampaignNotFoundException() { }

        public CampaignNotFoundException(string message) : base(message) { }

        public CampaignNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
