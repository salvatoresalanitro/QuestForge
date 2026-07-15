using QuestForge.Domain.Items;

namespace QuestForge.Domain.ValueObjects
{
    public sealed record ItemType
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public List<Item> Items { get; init; } = [];

        private ItemType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static ItemType Create(int id, string name)
        {
            return new ItemType(id, name);
        }
    }
}
