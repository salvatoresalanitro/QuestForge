using AutoMapper;
using QuestForge.Core.DTOs.DTOsCharacter;
using QuestForge.Core.Entities;

namespace QuestForge.API.Mappings
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterDto>();
            CreateMap<CreateCharacterDto, Character>();
        }
    }
}
