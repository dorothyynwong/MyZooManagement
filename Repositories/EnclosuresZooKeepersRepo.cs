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
            return  new List<ZooKeeper>{};
        }

        public List<Enclosure> GetEnclosures(int zooId)
        {
            return  new List<Enclosure>{};
        }


    }
}