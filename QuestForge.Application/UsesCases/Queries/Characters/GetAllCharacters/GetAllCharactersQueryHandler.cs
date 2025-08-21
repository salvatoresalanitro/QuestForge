using MediatR;
using QuestForge.Application.Mapping;
using QuestForge.Domain.Characters;
using QuestForge.DTOs.DTOsCharacter;

namespace QuestForge.Application.UsesCases.Queries.Characters.GetAllCharacters
{
    internal class GetAllCharactersQueryHandler : IRequestHandler<GetAllCharactersQuery, IEnumerable<CharacterDto>>
    {
        private readonly ICharacterRepository _characterRepository;

        public GetAllCharactersQueryHandler(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<IEnumerable<CharacterDto>> Handle(GetAllCharactersQuery request, CancellationToken cancellationToken)
        {
            var characters = await _characterRepository.GetAllAsync(cancellationToken);

            return characters is null
                ? throw new Exception("No characters found.")
                : characters.Select(c => CharacterMapper.ToDto(c));
        }
    }
}
