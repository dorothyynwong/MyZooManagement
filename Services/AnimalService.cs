using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using ZooManagement.Repositories;

namespace ZooManagement.Services
{
    public interface IAnimalService
    {
        Animal Create(CreateAnimalRequest animal);
    }

    public class AnimalService : IAnimalService
    {
        private readonly ILogger<AnimalService> _logger;
        private readonly IAnimalsRepo _animals;
        private readonly IEnclosuresRepo _enclosures;

        public AnimalService(ILogger<AnimalService> logger, IAnimalsRepo animals, IEnclosuresRepo enclosures)
        {
            _logger = logger;
            _animals = animals;
            _enclosures = enclosures;
        }

        public Animal Create(CreateAnimalRequest animal)
        {
            Enclosure enclosure = _enclosures.GetEnclosure(animal.EnclosureId);
            
            if (enclosure == null)
            {
                _logger.LogWarning("Enclosure with ID {EnclosureId} not found.", animal.EnclosureId);
                throw new InvalidOperationException("Enclosure not found.");
            }

            if (enclosure.MaxNumberOfAnimals < enclosure.NumberOfAnimals + 1)
            {
                _logger.LogWarning("Cannot add animal to enclosure. Enclosure ID {EnclosureId} has reached its maximum capacity.", animal.EnclosureId);
                throw new InvalidOperationException("Maximum number of animals in the enclosure has been reached.");
            }

            int newNumberOfAnimals = enclosure.NumberOfAnimals + 1;
            
            Enclosure updatedEnclosure = _enclosures.AddAnimalToEnclosure(animal.EnclosureId);
            if (updatedEnclosure == null)
            {
                throw new Exception("Failed to update enclosure or enclosure not found.");
            }

            if (updatedEnclosure.NumberOfAnimals != newNumberOfAnimals)
            {
                throw new Exception("Number of animals in the enclosure did not update correctly.");
            }

            return _animals.Create(animal);
        }
    }
}