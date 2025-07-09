using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Domain.Characters.CharacterVO
{
    public sealed record CharacterName
    {
        public string Value { get; }

        private CharacterName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new CharacterCreationException("Name cannot be empty");
            }

            if(value.Length < 3)
            {
                throw new CharacterCreationException("Name cannot be less than 3 character");
            }

            if(value.Length > 25)
            {
                throw new CharacterCreationException("Name cannot exceed 25 characters");
            }

            Value = value.Trim();
        }

        public static CharacterName Create(string value)
        {
            return new CharacterName(value);
        }

        public override string ToString() => Value;
    }
}
