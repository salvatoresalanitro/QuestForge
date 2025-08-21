namespace QuestForge.Application.Exceptions
{
    internal class ClassNotFoundException : AppException
    {
        internal ClassNotFoundException() { }

        internal ClassNotFoundException(string message) : base(message) { }

        internal ClassNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
