using QuestForge.Domain.ValueObjects;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Mapping
{
    public static class ClassModelMapping
    {
        public static Class MapToDomain(this ClassModel model)
        {
            var subClasses = model.SubClasses
                .Select(scM => SubClass.Create(scM.Id, scM.Name, scM.Class.MapToDomain()))
                .ToList();

            return Class.Create(
                model.Id,
                model.Name,
                subClasses
            );
        }

        public static ClassModel MapToModel(this Class domain)
        {
            var model = new ClassModel()
            {
                Id = domain.Id,
                Name = domain.Name,
            };

            model.SubClasses.AddRange(
                domain.SubClasses.Select(c => c.MapToModel())
            );

            return model;
        }
    }
}
