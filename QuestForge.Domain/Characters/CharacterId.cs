namespace QuestForge.Domain.Characters
{
    public record CharacterId
    {
        public Guid Id { get; init; }

        private CharacterId()
        {
            Id = Guid.NewGuid();
        }

        public static CharacterId Create()
        {
            return new CharacterId();
        }
    }
}
