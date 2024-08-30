using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Repositories
{
    public interface IEnclosuresZooKeepersRepo
    {
        List<ZooKeeper> GetZooKeepers(int enclosureId);
        List<Enclosure> GetEnclosures(int zooId);

    }

    public class EnclosuresZooKeepersRepo : IEnclosuresZooKeepersRepo
    {
        private readonly ZooManagementDbContext _context;

        public EnclosuresZooKeepersRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public List<ZooKeeper> GetZooKeepers(int enclosureId)
        {
            var query = _context.EnclosuresZooKeepers
                            .Include(ez => ez.ZooKeeper);

            List<ZooKeeper> zooKeepers = query.Select( z => new ZooKeeper
                            {
                                Id = z.ZooKeeper.Id,
                                Name = z.ZooKeeper.Name,
                            }).ToList();
                    
            return zooKeepers;
        }

        public List<Enclosure> GetEnclosures(int zooKeeperId)
        {
            var query = _context.EnclosuresZooKeepers
                            .Include(ez => ez.Enclosure);

            List<Enclosure> enclosures = query.Select( e => new Enclosure
                            {
                                Id = e.Enclosure.Id,
                                Name = e.Enclosure.Name,
                                MaxNumberOfAnimals = e.Enclosure.MaxNumberOfAnimals,
                                NumberOfAnimals = e.Enclosure.NumberOfAnimals,
                            }).ToList();
                    
            return enclosures;
        }


    }
}