using MediatR;
using QuestForge.Application.Exceptions;
using QuestForge.Application.Mapping;
using QuestForge.Domain.Characters;
using QuestForge.DTOs.DTOsCharacter;

namespace QuestForge.Application.UsesCases.Commands.Characters.UpdateCharacter
{
    public sealed record UpdateCharacterCommandHandler : IRequestHandler<UpdateCharacterCommand, CharacterDto>
    {
        private readonly ICharacterRepository _characterRepository;

        public UpdateCharacterCommandHandler(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<CharacterDto> Handle(UpdateCharacterCommand request, CancellationToken cancellationToken)
        {
            var character = await _characterRepository.GetByIdAsync(request.Id, cancellationToken);

            if(character is null)
            {
                throw new CharacterNotFoundException("Character not found.");
            }

            var characterDto = request.Character;

            character.Update(
                characterDto.Name,
                characterDto.SpeciesId,
                characterDto.ClassId,
                characterDto.Level,
                characterDto.HitPoints,
                characterDto.ArmorClass
            );

            await _characterRepository.UpdateAsync(character, cancellationToken);

            return CharacterMapper.ToDto(character);
        }
    }
}
