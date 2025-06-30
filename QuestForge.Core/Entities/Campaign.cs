namespace QuestForge.Core.Entities
{
    public class Campaign
    {
        public Guid Id { get; init; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Character> Characters { get; init; }
        public List<Item> Items { get; init; }
        public List<Npc> Npcs { get; init; }
        public List<Enemy> Enemies { get; init; }

        private Campaign(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Characters = [];
            Items = [];
            Npcs = [];
            Enemies = [];
        }

        public static Campaign Create(string name, string description)
        {
            return new Campaign(name, description);
        }

        public void Update(string name, string desciption)
        {
            Name = name;
            Description = desciption;
        }
    }
}
