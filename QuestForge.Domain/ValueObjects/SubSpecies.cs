namespace QuestForge.Domain.ValueObjects
{
    public sealed record SubSpecies
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;

        private SubSpecies(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static SubSpecies Create(int id, string name)
        {
            return new SubSpecies(id, name);
        }
    }
}