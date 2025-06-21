using QuestForge.Core.Entities;

namespace QuestForge.Core.Interfaces.RepositoryInterfaces
{
    public interface INpcRepository
    {
        Task<Npc> GetNpcByIdAsync(Guid npcId);
        Task<IEnumerable<Npc>> GetAllNpcsAsync();
        Task<Npc> CreateNpcAsync(Npc npc);
        Task<Npc> UpdateNpcAsync(Npc npc);
        Task DeleteNpcAsync(Guid npcId);
        Task<IEnumerable<Npc>> GetNpcsByCampaignIdAsync(Guid campaignId);
    }
}
