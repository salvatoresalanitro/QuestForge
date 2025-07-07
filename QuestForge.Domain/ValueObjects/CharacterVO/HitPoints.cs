using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Domain.ValueObjects.CharacterVO
{
    public sealed record HitPoints
    {
        public int Value { get; }

        private HitPoints(int value)
        {
            if(value < 0)
            {
                throw new CharacterCreationException("HitPoints cannot be negative.");
            }

            Value = value;
        }

        public static HitPoints Create(int value)
        {
            return new HitPoints(value);
        }

        public static implicit operator int(HitPoints hitPoints) => hitPoints.Value;

        public override string ToString() => Value.ToString();
    }
}
