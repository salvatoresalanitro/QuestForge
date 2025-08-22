using MediatR;
using QuestForge.Application.Exceptions;
using QuestForge.Domain.Characters;
using QuestForge.Domain.ValueObjects;

namespace QuestForge.Application.UsesCases.Commands.Characters.CreateCharacter
{
    public sealed record CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, Guid>
    {
        private readonly ISpeciesRepository _speciesRepository;
        private readonly IClassRepository _classRepository;
        private readonly ICharacterRepository _characterRepository;

        public CreateCharacterCommandHandler(ISpeciesRepository speciesRepository, IClassRepository classRepository, ICharacterRepository characterRepository)
        {
            _speciesRepository = speciesRepository;
            _classRepository = classRepository;
            _characterRepository = characterRepository;
        }

        public async Task<Guid> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
        {
            var species = await _speciesRepository.GetByIdAsync(request.SpeciesId);
            var @class = await _classRepository.GetByIdAsync(request.ClassId);

            if(species is null)
            {
                throw new SpeciesNotFoundException("Species not found.");
            }

            if(@class is null)
            {
                throw new ClassNotFoundException("Class not found.");
            }

            var character = Character.Create(
                request.Name,
                species,
                @class,
                request.Level,
                request.HitPoints,
                request.ArmorClass,
                []
            );

            await _characterRepository.CreateAsync(character, cancellationToken);
            return character.Id.Value;
        }
    }
}