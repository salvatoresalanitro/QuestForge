using QuestForge.Domain.ValueObjects;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Mapping
{
    public static class SubSpeciesModelMapping
    {
        public static SubSpecies MapToDomain(this SubSpeciesModel model)
        {
            return SubSpecies.Create(
                model.Id,
                model.Name,
                model.Species.MapToDomain()
            );
        }

        public static SubSpeciesModel MapToModel(this SubSpecies domain)
        {
            return new SubSpeciesModel()
            {
                Id = domain.Id,
                Name = domain.Name,
                Species = domain.Species.MapToModel()
            };
        }
    }
}
