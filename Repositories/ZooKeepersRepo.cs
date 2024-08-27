using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Repositories
{
    public interface IZooKeepersRepo
    {
        ZooKeeper GetZooKeeper(int id);

    }

    public class ZooKeepersRepo : IZooKeepersRepo
    {
        private readonly ZooManagementDbContext _context;

        public ZooKeepersRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public ZooKeeper GetZooKeeper(int id)
        {
            return _context.ZooKeepers
                .FirstOrDefault(zooKeeper => zooKeeper.Id == id);
        }
    }
}