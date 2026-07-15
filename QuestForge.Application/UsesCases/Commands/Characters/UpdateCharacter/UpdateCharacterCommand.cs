using MediatR;
using QuestForge.DTOs.DTOsCharacter;

namespace QuestForge.Application.UsesCases.Commands.Characters.UpdateCharacter
{
    public sealed record UpdateCharacterCommand : IRequest<CharacterDto>
    {
        public Guid Id { get; }
        public CreateCharacterDto Character { get; }

        public UpdateCharacterCommand(Guid id, CreateCharacterDto character)
        {
            Id = id;
            Character = character;
        }
    }
}
