namespace QuestForge.Core.Entities
{
    public class ItemType
    {
        public int Id { get; init; }
        public string Name { get; private set; } = string.Empty;
        public List<Item> Items { get; private set; } = [];

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
