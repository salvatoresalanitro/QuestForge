using MediatR;

namespace QuestForge.Application.UsesCases.Commands.Characters.CreateCharacter
{
    public sealed record CreateCharacterCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public int SpeciesId { get; set; }
        public int ClassId { get; set; }
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public int ArmorClass { get; set; }

        public CreateCharacterCommand(
            string name,
            int speciesId,
            int classId,
            int level,
            int hitPoints,
            int armorClass
        )
        {
            Name = name;
            SpeciesId = speciesId;
            ClassId = classId;
            Level = level;
            HitPoints = hitPoints;
            ArmorClass = armorClass;
        }
    }
}
