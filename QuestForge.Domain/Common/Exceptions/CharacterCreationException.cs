namespace QuestForge.Domain.Common.Exceptions
{
    public class CharacterCreationException : DomainException
    {
        public CharacterCreationException() { }

        public CharacterCreationException(string message) : base(message) { }

        public CharacterCreationException(string message, Exception innerException) : base(message, innerException) { }
    }
}