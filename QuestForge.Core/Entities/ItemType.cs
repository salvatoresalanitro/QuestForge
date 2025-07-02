namespace QuestForge.Core.Entities
{
    public class ItemType
    {
        public int Id { get; init; }
        public string Name { get; private set; } = string.Empty;
        public List<Item> Items { get; private set; } = [];

        public ItemType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
