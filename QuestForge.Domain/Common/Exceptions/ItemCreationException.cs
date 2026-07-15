namespace QuestForge.Domain.Common.Exceptions
{
    public class ItemCreationException : DomainException
    {
        public ItemCreationException() { }

        public ItemCreationException(string message) : base(message) { }

        public ItemCreationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
