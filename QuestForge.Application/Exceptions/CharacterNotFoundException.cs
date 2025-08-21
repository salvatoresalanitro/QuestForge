namespace QuestForge.Application.Exceptions
{
    internal class CharacterNotFoundException : AppException
    {
        internal CharacterNotFoundException() { }

        internal CharacterNotFoundException(string message) : base(message) { }

        internal CharacterNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
