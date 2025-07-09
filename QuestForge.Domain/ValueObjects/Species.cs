namespace QuestForge.Domain.ValueObjects
{
    public sealed record Species
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public List<SubSpecies> SubSpecies { get; init; } = [];

        private Species(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Species Create(int id, string name)
        {
            return new Species(id, name);
        }
    }
}
