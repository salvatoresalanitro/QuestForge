using MediatR;
using QuestForge.Domain.Characters;

namespace QuestForge.Application.UsesCases.Commands.Characters.DeleteCharacter
{
    public sealed record DeleteCharacterCommandHandler : IRequestHandler<DeleteCharacterCommand, bool>
    {
        private readonly ICharacterRepository _characterRepository;

        public DeleteCharacterCommandHandler(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<bool> Handle(DeleteCharacterCommand request, CancellationToken cancellationToken)
        {
            var character = await _characterRepository.GetByIdAsync(request.Id, cancellationToken);

            if(character is null)
            {
                return false;
            }

            await _characterRepository.DeleteAsync(character, cancellationToken);
            return true;
        }
    }
}
