using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Domain.Characters.CharacterVO
{
    public record ArmorClass
    {
        public int Value { get; private set; }

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

        public void Update(int value)
        {
            if (value < 0)
            {
                throw new CharacterUpdateException("Armor class cannot be negative.");
            }

            Value = value;
        }

        public static implicit operator int(ArmorClass armorClass) => armorClass.Value;
        public override string ToString() => Value.ToString();
    }
}
