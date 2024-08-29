using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Repositories
{
    public interface IZooKeepersRepo
    {
        ZooKeeper GetZooKeeperById(int id);
        ZooKeeper Create(CreateZooKeeperRequest zooKeeper);

    }

    public class ZooKeepersRepo : IZooKeepersRepo
    {
        private readonly ZooManagementDbContext _context;

        public ZooKeepersRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public ZooKeeper GetZooKeeperById(int id)
        {
            return _context.ZooKeepers
                .FirstOrDefault(zooKeeper => zooKeeper.Id == id);
        }

        public ZooKeeper Create(CreateZooKeeperRequest zooKeeper)
        {
            var insertResult = _context.ZooKeepers.Add(new ZooKeeper
            {
                Name = zooKeeper.Name,
            });
            _context.SaveChanges();
            return insertResult.Entity;
        }
    }
}