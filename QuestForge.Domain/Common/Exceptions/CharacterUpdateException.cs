namespace QuestForge.Domain.Common.Exceptions
{
    public class CharacterUpdateException : DomainException
    {
        public CharacterUpdateException() { }

        public CharacterUpdateException(string message) : base(message) { }

        public CharacterUpdateException(string message, Exception innerException) : base(message, innerException) { }
    }
}
