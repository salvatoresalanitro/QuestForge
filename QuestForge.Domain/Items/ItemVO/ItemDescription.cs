using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Domain.Items.ItemVO
{
    public sealed class ItemDescription
    {
        public string Value { get; } = string.Empty;

        private ItemDescription(string value)
        {
            if (value.Length > 500)
            {
                throw new ItemCreationException("Description cannot exceed 500 characters.");
            }

            Value = value;
        }

        public static ItemDescription Create(string value)
        {
            return new ItemDescription(value);
        }
    }
}
