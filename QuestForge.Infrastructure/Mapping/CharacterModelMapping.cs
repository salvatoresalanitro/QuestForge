using QuestForge.Domain.Characters;
using QuestForge.Domain.Characters.CharacterVO;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Mapping
{
    public static class CharacterModelMapping
    {
        public static Character MapToDomain(this CharacterModel model)
        {
            return Character.Create(
                model.Id,
                model.Name,
                model.Species.MapToDomain(),
                model.Class.MapToDomain(),
                model.Level,
                model.HitPoints,
                model.ArmorClass,
                model.Items.Select(i => i.MapToDomain()).ToList()
            );

            return Character.Reconstitute(
                CharacterId.Create(model.Id),
                CharacterName.Create(model.Name),
                model.Species.MapToDomain(),
                model.Class.MapToDomain(),
                Level.Create(model.Level),
                HitPoints.Create(model.HitPoints),
                ArmorClass.Create(model.ArmorClass),
                model.Items.Select(i => i.MapToDomain()).ToList()
            );
        }

        public static CharacterModel MapToModel(this Character domain)
        {
            var model = new CharacterModel()
            {
                Id = domain.Id.Value,
                Name = domain.Name.Value,
                Species = domain.Species.MapToModel(),
                Class = domain.Class.MapToModel(),
                Level = domain.Level.Value,
                HitPoints = domain.HitPoints.Value,
                ArmorClass = domain.ArmorClass.Value,
            };

            model.Items.AddRange(
                domain.Items.Select(i => i.MapToModel())
            );

            return model;
        }
    }
}
