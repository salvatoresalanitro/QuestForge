using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Domain.Items.ItemVO
{
    public sealed record ItemName
    {
        public string Value { get; }

        private ItemName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ItemCreationException("Name cannot be empty.");
            }

            if (value.Length > 100)
            {
                throw new ItemCreationException("Name cannot exceed 100 characters.");
            }

            Value = value.Trim();
        }

        public static ItemName Create(string value)
        {
            return new ItemName(value);
        }

        public override string ToString() => Value;
    }
}
