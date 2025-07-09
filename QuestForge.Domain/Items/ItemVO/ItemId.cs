namespace QuestForge.Domain.Items.ItemVO
{
    public sealed record ItemId
    {
        public Guid Value { get; init; }

        private ItemId(Guid value)
        {
            Value = value;
        }

        public static ItemId Create()
            => Create(Guid.NewGuid());

        public static ItemId Create(Guid id)
            => new ItemId(id);
    }
}
