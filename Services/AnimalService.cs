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
                _logger.LogWarning($"Enclosure with ID {animal.EnclosureId} not found.");
                throw new InvalidOperationException("Enclosure not found.");
            }

            if (enclosure.MaxNumberOfAnimals < enclosure.NumberOfAnimals + 1)
            {
                _logger.LogWarning($"Cannot add animal to enclosure. Enclosure ID {animal.EnclosureId} has reached its maximum capacity.");
                throw new InvalidOperationException("Maximum number of animals in the enclosure has been reached.");
            }

            int newNumberOfAnimals = enclosure.NumberOfAnimals + 1;
            
            Enclosure updatedEnclosure = _enclosures.AddAnimalToEnclosure(animal.EnclosureId);
            if (updatedEnclosure == null)
            {
                _logger.LogError($"Failed to update enclosure {animal.EnclosureId}. Enclosure update operation failed or not found. ");
                throw new Exception("Failed to update enclosure or enclosure not found.");
            }

            if (updatedEnclosure.NumberOfAnimals != newNumberOfAnimals)
            {
                _logger.LogWarning($"Number of animals in enclosure ID {animal.EnclosureId} did not update as expected. Expected: {newNumberOfAnimals}, Actual: {updatedEnclosure.NumberOfAnimals}.");
                throw new Exception("Number of animals in the enclosure did not update correctly.");
            }

            return _animals.Create(animal);
        }
    }
}