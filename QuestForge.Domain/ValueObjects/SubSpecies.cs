namespace QuestForge.Domain.ValueObjects
{
    public sealed record SubSpecies
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public Species Species {  get; init; }

        private SubSpecies(int id, string name, Species species)
        {
            Id = id;
            Name = name;
            Species = species;
        }

        public static SubSpecies Create(int id, string name, Species species)
        {
            return new SubSpecies(id, name, species);
        }
    }
}