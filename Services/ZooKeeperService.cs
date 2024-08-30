using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using ZooManagement.Models.ViewModel;
using ZooManagement.Repositories;

namespace ZooManagement.Services
{
    public interface IZooKeeperService
    {
        ZooKeeper GetZooKeeperById(int id);
        Animal Create(CreateAnimalRequest animal);
    }

    public class ZooKeeperService : IZooKeeperService
    {
        private readonly ILogger<ZooKeeperService> _logger;
        private readonly IAnimalsRepo _animals;
        private readonly IZooKeepersRepo _zooKeepers;
        private readonly IEnclosuresRepo _enclosures;
        private readonly IEnclosuresZooKeepersRepo _enclosuresZooKeepers;

        public ZooKeeperService(ILogger<ZooKeeperService> logger, 
                                IZooKeepersRepo zooKeepers, 
                                IAnimalsRepo animals, 
                                IEnclosuresRepo enclosures,
                                IEnclosuresZooKeepersRepo enclosuresZooKeepers)
        {
            _logger = logger;
            _zooKeepers = zooKeepers;
            _animals = animals;
            _enclosures = enclosures;
            _enclosuresZooKeepers = enclosuresZooKeepers;
        }

        public ZooKeeper GetZooKeeperById(int id)
        {
            ZooKeeper zooKeeper = _zooKeepers.GetZooKeeperById(id);
            // EnclosureZooKeeper enclosureZooKeeper = _enclosures
            
            if (zooKeeper == null)
            {
                _logger.LogWarning($"Zoo Keeper with ID {id} not found");
                throw new InvalidOperationException($"Zoo Keeper with ID {id} not found");
            }
            return zooKeeper;
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