using MediatR;
using QuestForge.Application.Exceptions;
using QuestForge.Application.Mapping;
using QuestForge.Domain.Characters;
using QuestForge.DTOs.DTOsCharacter;

namespace QuestForge.Application.UsesCases.Queries.Characters.GetCharacterById
{
    public class GetCharacterByIdQueryHandler : IRequestHandler<GetCharacterByIdQuery, CharacterDto>
    {
        private readonly ICharacterRepository _characterRepository;

        public GetCharacterByIdQueryHandler(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<CharacterDto> Handle(GetCharacterByIdQuery request, CancellationToken cancellationToken)
        {
            var character = await _characterRepository.GetByIdAsync(request.Id, cancellationToken);

            return character is null
                ? throw new CharacterNotFoundException("Character not found.")
                : CharacterMapper.ToDto(character);
        }
    }
}
