namespace QuestForge.Domain.ValueObjects
{
    public sealed record Species
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public List<SubSpecies> AllSubSpecies { get; init; } = [];

        private Species(int id, string name, List<SubSpecies> subSpecies)
        {
            Id = id;
            Name = name;
            AllSubSpecies = subSpecies;
        }

        public static Species Create(int id, string name, List<SubSpecies> subSpecies)
        {
            return new Species(id, name, subSpecies);
        }
    }
}
