namespace QuestForge.Core.Entities
{
    public class Species
    {
        public int Id { get; init; }
        public string Name { get; private set; }

        //private Species() { } //for EF Core

        public Species(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
