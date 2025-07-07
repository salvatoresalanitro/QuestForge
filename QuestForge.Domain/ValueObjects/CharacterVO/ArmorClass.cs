using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Domain.ValueObjects.CharacterVO
{
    public record ArmorClass
    {
        public int Value { get; }

        private ArmorClass(int value)
        {
            if(value < 0)
            {
                throw new CharacterCreationException("Armor class cannot be negative.");
            }

            Value = value;
        }

        public static ArmorClass Create(int value)
        {
            return new ArmorClass(value);
        }

        public static implicit operator int(ArmorClass armorClass) => armorClass.Value;
        public override string ToString() => Value.ToString();
    }
}
