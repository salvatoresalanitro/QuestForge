namespace QuestForge.Application.Exceptions
{
    internal class SpeciesNotFoundException : AppException
    {
        internal SpeciesNotFoundException() { }

        internal SpeciesNotFoundException(string message) : base(message) { }

        internal SpeciesNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
