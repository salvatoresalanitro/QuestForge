using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestForge.Core.Entities;

namespace QuestForge.Core.RepositoryInterfaces
{
    public interface IEnemyRepository
    {
        Task<Enemy> GetEnemyByIdAsync(Guid enemyId);
        Task<IEnumerable<Enemy>> GetAllEnemiesAsync();
        Task<Enemy> CreateEnemyAsync(Enemy enemy);
        Task<Enemy> UpdateEnemyAsync(Enemy enemy);
        Task DeleteEnemyAsync(Guid enemyId);
        Task<IEnumerable<Enemy>> GetEnemiesByCampaignIdAsync(Guid campaignId);
    }
}
