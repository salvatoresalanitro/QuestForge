namespace QuestForge.Core.Entities
{
    public class SubSpecies
    {
        public int Id { get; init; }
        public string Name { get; private set; } = string.Empty;
        public int SpeciesId { get; private set; }
        public Species Species { get; private set; } = null!;
        public SubSpecies(int id, string name, int speciesId)
        {
            Id = id;
            Name = name;
            SpeciesId = speciesId;
        }
    }
}