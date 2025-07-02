namespace QuestForge.Core.Entities
{
    public class SubSpecies
    {
        public int Id { get; init; }
        public string Name { get; private set; } = string.Empty;
        public int SpeciesId { get; private set; }
        public Species Species { get; private set; } = null!;
        private SubSpecies(int id, string name, int speciesId)
        {
            Id = id;
            Name = name;
            SpeciesId = speciesId;
        }

        public static SubSpecies Create(int id, string name, int speciesId)
        {
            return new SubSpecies(id, name, speciesId);
        }
    }
}