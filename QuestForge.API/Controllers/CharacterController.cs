using Microsoft.AspNetCore.Mvc;
using QuestForge.Core.RepositoryInterfaces;

namespace QuestForge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

    }
}
