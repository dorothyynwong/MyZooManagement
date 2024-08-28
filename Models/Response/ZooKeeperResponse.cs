using ZooManagement.Models.Database;
using ZooManagement.Helpers;

namespace ZooManagement.Models.Response
{
    public class ZooKeeperResponse
    {
        private readonly ZooKeeper _zooKeeper;

        public ZooKeeperResponse(ZooKeeper zooKeeper)
        {
            _zooKeeper = zooKeeper;
        }

        public int Id => _zooKeeper.Id;
        public string Name => _zooKeeper.Name;
        
    }
}