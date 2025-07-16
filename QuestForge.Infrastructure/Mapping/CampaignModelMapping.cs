using QuestForge.Domain.Campaigns;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Mapping
{
    public static class CampaignModelMapping
    {
        public static Campaign MapToDomain(this CampaignModel model)
        {
            return Campaign.Create(
                model.Id,
                model.Name,
                model.Description,
                model.Characters.Select(c => c.MapToDomain()).ToList(),
                model.Items.Select(c => c.MapToDomain()).ToList()
            );
        }

        public static CampaignModel MapToModel(this Campaign domain)
        {
            var model = new CampaignModel()
            {
                Id = domain.Id.Value,
                Name = domain.Name.Value,
                Description = domain.Description.Value,
            };

            model.Characters.AddRange(
                domain.Characters.Select(c => c.MapToModel())
            );

            model.Items.AddRange(
                domain.Items.Select(i => i.MapToModel())
            );

            return model;
        }
    }
}
