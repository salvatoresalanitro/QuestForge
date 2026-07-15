using MediatR;
using QuestForge.DTOs.DTOsCharacter;

namespace QuestForge.Application.UsesCases.Queries.Characters.GetAllCharacters
{
    public sealed record GetAllCharactersQuery : IRequest<IEnumerable<CharacterDto>> { }
}
