using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using ZooManagement.Repositories;

namespace ZooManagement.Services
{
    public interface IAnimalService
    {
        Animal GetAnimalById(int id);
        IEnumerable<Animal> Search(AnimalSearchRequest search);
        int Count(AnimalSearchRequest search);
        Animal Create(CreateAnimalRequest animal);
    }

    public class AnimalService : IAnimalService
    {
        private readonly ILogger<AnimalService> _logger;
        private readonly IAnimalsRepo _animals;
        private readonly ISpeciesRepo _species;
        private readonly IEnclosuresRepo _enclosures;

        public AnimalService(ILogger<AnimalService> logger, IAnimalsRepo animals, ISpeciesRepo species, IEnclosuresRepo enclosures)
        {
            _logger = logger;
            _animals = animals;
            _species = species;
            _enclosures = enclosures;
        }

        public Animal GetAnimalById(int id)
        {
            Animal animal = _animals.GetAnimalById(id);
            if (animal == null)
            {
                _logger.LogWarning($"Animal with ID {id} not found");
                throw new InvalidOperationException($"Animal with ID {id} not found");
            }
            return animal;
        }

        public IEnumerable<Animal> Search(AnimalSearchRequest search)
        {
            IEnumerable<Animal> animals = _animals.Search(search);
            if (animals == null || animals.Count() == 0)
            {
                _logger.LogWarning($"Animals not found for parameters {search.Filters}");
                throw new InvalidOperationException($"Animals not found for parameters {search.Filters}");  
            }
            return animals;
        }

        public int Count(AnimalSearchRequest search)
        {
            return _animals.Count(search);
        }

        public Animal Create(CreateAnimalRequest animal)
        {
            Enclosure enclosure = _enclosures.GetEnclosure(animal.EnclosureId);
            
            if (enclosure == null)
            {
                _logger.LogWarning($"Enclosure with ID {animal.EnclosureId} not found.");
                throw new InvalidOperationException($"Enclosure with ID {animal.EnclosureId} not found.");
            }

            if (enclosure.MaxNumberOfAnimals < enclosure.NumberOfAnimals + 1)
            {
                _logger.LogWarning($"Cannot add animal to enclosure. Enclosure ID {animal.EnclosureId} has reached its maximum capacity.");
                throw new InvalidOperationException($"Maximum number of animals in the enclosure has been reached for enclosure {animal.EnclosureId}");
            }

            int newNumberOfAnimals = enclosure.NumberOfAnimals + 1;
            
            Enclosure updatedEnclosure = _enclosures.AddAnimalToEnclosure(animal.EnclosureId);
            if (updatedEnclosure == null)
            {
                _logger.LogError($"Failed to update enclosure or enclosure {animal.EnclosureId} not found.");
                throw new Exception($"Failed to update enclosure or enclosure {animal.EnclosureId} not found.");
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