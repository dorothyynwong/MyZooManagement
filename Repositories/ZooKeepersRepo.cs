using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Repositories
{
    public interface IZooKeepersRepo
    {
        ZooKeeper GetZooKeeper(int id);
        ZooKeeper Create(CreateZooKeeperRequest zooKeeper);

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

        public ZooKeeper Create(CreateZooKeeperRequest zooKeeper)
        {
            var insertResult = _context.ZooKeepers.Add(new ZooKeeper
            {
                Name = zooKeeper.Name,
                EnclosureId = zooKeeper.EnclosureId
            });
            _context.SaveChanges();
            return insertResult.Entity;
        }
    }
}