using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using ZooManagement.Models.ViewModel;
using ZooManagement.Repositories;

namespace ZooManagement.Services
{
    public interface IZooKeeperService
    {
        ZooKeeper GetZooKeeperById(int id);
        ZooKeeper Create(CreateZooKeeperRequest zooKeeper);
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
            
            if (zooKeeper == null)
            {
                _logger.LogWarning($"Zoo Keeper with ID {id} not found");
                throw new InvalidOperationException($"Zoo Keeper with ID {id} not found");
            }

            List<Enclosure> enclosures = _enclosuresZooKeepers.GetEnclosuresByZooKeeperId(id);
            if (enclosures == null)
            {
                _logger.LogWarning($"Enclosures of Zoo Keeper ID {id} not found");
                throw new InvalidOperationException($"Enclosures of Zoo Keeper ID {id} not found");
            }
            enclosures.Select(enclosure => enclosure.Animals = _animals.GetAnimalByEnclosureId(enclosure.Id)).ToList();

            zooKeeper.Enclosures = enclosures;

            return zooKeeper;
        }


        public ZooKeeper Create(CreateZooKeeperRequest zooKeeper)
        {
            Enclosure enclosure = _enclosures.GetEnclosure(zooKeeper.EnclosureId);
            
            if (enclosure == null)
            {
                _logger.LogWarning($"Enclosure with ID {zooKeeper.EnclosureId} not found.");
                throw new InvalidOperationException($"Enclosure with ID {zooKeeper.EnclosureId} not found.");
            }

            ZooKeeper newZooKeeper = _zooKeepers.Create(zooKeeper);
            if (newZooKeeper == null)
            {
                _logger.LogWarning($"Zoo Keeper {zooKeeper.Name} cannot be created.");
                throw new InvalidOperationException($"Zoo Keeper {zooKeeper.Name} cannot be created.");
            }

            EnclosureZooKeeper enclosureZooKeeper = _enclosuresZooKeepers.Create(enclosure.Id, newZooKeeper.Id);
            if (enclosureZooKeeper == null)
            {
                 _logger.LogWarning($"Relationship of Zoo Keeper {newZooKeeper.Id} and Enclosure {enclosure.Id} cannot be created.");
                throw new InvalidOperationException($"Relationship of Zoo Keeper {newZooKeeper.Id} and Enclosure {enclosure.Id} cannot be created.");               
            }

            return newZooKeeper;
        }
    }
}