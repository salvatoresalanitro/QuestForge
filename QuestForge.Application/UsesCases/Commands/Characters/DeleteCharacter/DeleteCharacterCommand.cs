using MediatR;

namespace QuestForge.Application.UsesCases.Commands.Characters.DeleteCharacter
{
    public sealed record DeleteCharacterCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public DeleteCharacterCommand(Guid id)
        {
            Id = id;
        }
    }
}
