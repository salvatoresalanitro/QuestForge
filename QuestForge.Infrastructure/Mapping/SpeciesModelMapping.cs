using QuestForge.Domain.ValueObjects;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Mapping
{
    public static class SpeciesModelMapping
    {
        public static Species MapToDomain(this SpeciesModel model)
        {
            var allSubSpecies = model.AllSubSpecies
                .Select(sM => SubSpecies.Create(sM.Id, sM.Name, sM.Species.MapToDomain()))
                .ToList();

            return Species.Create(
                model.Id,
                model.Name,
                allSubSpecies    
            );
        }

        public static SpeciesModel MapToModel(this Species domain)
        {
            var model = new SpeciesModel()
            {
                Id = domain.Id,
                Name = domain.Name
            };

            model.AllSubSpecies.AddRange(
                domain.AllSubSpecies.Select(s => s.MapToModel())
            );

            return model;
        }
    }
}
