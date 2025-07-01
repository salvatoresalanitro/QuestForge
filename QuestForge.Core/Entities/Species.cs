namespace QuestForge.Core.Entities
{
    public class Species
    {
        public int Id { get; init; }
        public string Name { get; private set; } = string.Empty;

        public Species(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
