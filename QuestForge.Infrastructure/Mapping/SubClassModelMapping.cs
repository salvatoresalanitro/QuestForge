using QuestForge.Domain.ValueObjects;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Mapping
{
    public static class SubClassModelMapping
    {
        public static SubClass MapToDomain(this SubClassModel model)
        {
            return SubClass.Create(
                model.Id,
                model.Name
            );
        }

        public static SubClassModel MapToModel(this SubClass domain)
        {
            return new SubClassModel()
            {
                Id = domain.Id,
                Name = domain.Name,
            };
        }
    }
}
