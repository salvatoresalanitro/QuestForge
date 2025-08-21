namespace QuestForge.Application.Exceptions
{
    internal class CampaignNotFoundException : AppException
    {
        internal CampaignNotFoundException() { }

        internal CampaignNotFoundException(string message) : base(message) { }

        internal CampaignNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
