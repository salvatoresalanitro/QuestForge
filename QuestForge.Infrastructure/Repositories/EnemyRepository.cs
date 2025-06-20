using QuestForge.Core.Entities;
using QuestForge.Core.RepositoryInterfaces;

namespace QuestForge.Infrastructure.Repositories
{
    public class EnemyRepository : IEnemyRepository
    {
        public Task<Enemy> CreateEnemyAsync(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEnemyAsync(Guid enemyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Enemy>> GetAllEnemiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Enemy>> GetEnemiesByCampaignIdAsync(Guid campaignId)
        {
            throw new NotImplementedException();
        }

        public Task<Enemy> GetEnemyByIdAsync(Guid enemyId)
        {
            throw new NotImplementedException();
        }

        public Task<Enemy> UpdateEnemyAsync(Enemy enemy)
        {
            throw new NotImplementedException();
        }
    }
}
