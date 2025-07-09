using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Domain.Characters.CharacterVO
{
    public sealed record Level
    {
        public int Value { get; }
        private Level(int value)
        {
            if(value < 1)
            {
                throw new CharacterCreationException("Level must be at least 1.");
            }
            
            if(value > 20)
            {
                throw new CharacterCreationException("Level cannot exceed 20.");
            }

            Value = value;
        }

        public static Level Create(int value)
        {
            return new Level(value);
        }

        public static implicit operator int(Level level) => level.Value;

        public override string ToString() => Value.ToString();
    }
}
