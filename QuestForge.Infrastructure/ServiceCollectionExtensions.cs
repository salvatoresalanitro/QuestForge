using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuestForge.Domain.Campaigns;
using QuestForge.Domain.Characters;
using QuestForge.Domain.Items;
using QuestForge.Domain.ValueObjects;
using QuestForge.Infrastructure.Data;
using QuestForge.Infrastructure.Repositories;

namespace QuestForge.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<QuestForgeContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("QuestForgeConnection"))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());

            service.AddScoped<ICampaignRepository, CampaignRepository>();
            service.AddScoped<ICharacterRepository, CharacterRepository>();
            service.AddScoped<IItemRepository, ItemRepository>();
            service.AddScoped<ISpeciesRepository, SpeciesRepository>();
            service.AddScoped<IClassRepository, ClassRepository>();

            return service;
        }
    }
}
