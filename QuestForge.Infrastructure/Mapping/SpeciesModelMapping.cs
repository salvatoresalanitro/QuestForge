using QuestForge.Domain.ValueObjects;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Mapping
{
    public static class SpeciesModelMapping
    {
        public static Species MapToDomain(this SpeciesModel model)
        {
            var subSpecies = model.AllSubSpecies
                .Select(s => SubSpecies.Create(s.Id, s.Name, s.Species.MapToDomain()))
                .ToList();

            return Species.Create(
                model.Id,
                model.Name,
                subSpecies    
            );
        }

        public static SpeciesModel MapToModel(this Species species)
        {
            var model = new SpeciesModel()
            {
                Id = species.Id,
                Name = species.Name
            };

            model.AllSubSpecies.AddRange(
                species.AllSubSpecies
                    .Select(s => s.MapToModel()
                )
            );

            return model;
        }
    }
}
