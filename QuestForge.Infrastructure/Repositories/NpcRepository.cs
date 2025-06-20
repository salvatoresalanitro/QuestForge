using QuestForge.Core.Entities;
using QuestForge.Core.RepositoryInterfaces;

namespace QuestForge.Infrastructure.Repositories
{
    internal class NpcRepository : INpcRepository
    {
        public Task<Npc> CreateNpcAsync(Npc npc)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNpcAsync(Guid npcId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Npc>> GetAllNpcsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Npc> GetNpcByIdAsync(Guid npcId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Npc>> GetNpcsByCampaignIdAsync(Guid campaignId)
        {
            throw new NotImplementedException();
        }

        public Task<Npc> UpdateNpcAsync(Npc npc)
        {
            throw new NotImplementedException();
        }
    }
}
