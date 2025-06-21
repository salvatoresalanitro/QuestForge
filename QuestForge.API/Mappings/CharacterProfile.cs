using AutoMapper;
using QuestForge.Core.Entities;
using QuestForge.DTOs.DTOsCharacter;

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
