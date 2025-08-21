using MediatR;
using QuestForge.DTOs.DTOsCharacter;

namespace QuestForge.Application.UsesCases.Queries.Characters.GetCharacterById
{
    public sealed record GetCharacterByIdQuery : IRequest<CharacterDto>
    {
        public Guid Id { get; }

        public GetCharacterByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
