using ZooManagement.Models.Database;
using ZooManagement.Helpers;

namespace ZooManagement.Models.Response
{
    public class ZooKeeperEnclosureResponse
    {
        private readonly ZooKeeper _zooKeeper;

        public ZooKeeperEnclosureResponse(ZooKeeper zooKeeper)
        {
            _zooKeeper = zooKeeper;
        }

        public int Id => _zooKeeper.Id;
        public string Name => _zooKeeper.Name;
        public List<Enclosure> Enclosures => _zooKeeper.Enclosures;
        
    }
}