using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Repositories
{
    public interface IEnclosuresZooKeepersRepo
    {
        List<ZooKeeper> GetZooKeepersByEnclosureId(int enclosureId);
        List<Enclosure> GetEnclosuresByZooKeeperId(int zooKeeperId);

        EnclosureZooKeeper Create(int enclosureId, int zooKeeperId);

    }

    public class EnclosuresZooKeepersRepo : IEnclosuresZooKeepersRepo
    {
        private readonly ZooManagementDbContext _context;

        public EnclosuresZooKeepersRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public List<ZooKeeper> GetZooKeepersByEnclosureId(int enclosureId)
        {
            var query = _context.EnclosuresZooKeepers
                            .Include(ez => ez.ZooKeeper)
                            .Where(ez => ez.EnclosureId == enclosureId);

            List<ZooKeeper> zooKeepers = query.Select( z => new ZooKeeper
                            {
                                Id = z.ZooKeeper.Id,
                                Name = z.ZooKeeper.Name,
                            }).ToList();
                    
            return zooKeepers;
        }

        public List<Enclosure> GetEnclosuresByZooKeeperId(int zooKeeperId)
        {
            var query = _context.EnclosuresZooKeepers
                            .Include(ez => ez.Enclosure)
                            .Where(ez => ez.ZooKeeperId == zooKeeperId);

            List<Enclosure> enclosures = query.Select( e => new Enclosure
                            {
                                Id = e.Enclosure.Id,
                                Name = e.Enclosure.Name,
                                MaxNumberOfAnimals = e.Enclosure.MaxNumberOfAnimals,
                                NumberOfAnimals = e.Enclosure.NumberOfAnimals,
                            }).ToList();
                    
            return enclosures;
        }

        public EnclosureZooKeeper Create(int enclosureId, int zooKeeperId)
        {
            var insertResult = _context.EnclosuresZooKeepers.Add(new EnclosureZooKeeper
                                                {
                                                    EnclosureId = enclosureId, 
                                                    ZooKeeperId = zooKeeperId
                                                });
            _context.SaveChanges();
            return insertResult.Entity;
        }

    }
}