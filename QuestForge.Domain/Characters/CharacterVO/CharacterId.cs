namespace QuestForge.Domain.Characters.CharacterVO
{
    public record CharacterId
    {
        public Guid Value { get; init; }

        private CharacterId(Guid value)
        {
            Value = value;
        }

        public static CharacterId Create()
            => Create(Guid.NewGuid());

        public static CharacterId Create(Guid id)
            => new CharacterId(id);
    }
}
