using ZooManagement.Models.Database;
using ZooManagement.Helpers;

namespace ZooManagement.Models.Response
{
    public class EnclosureZooKeeperResponse
    {
        private readonly EnclosureZooKeeper _EnclosureZooKeeper;

        public EnclosureZooKeeperResponse(EnclosureZooKeeper EnclosureZooKeeper)
        {
            _EnclosureZooKeeper = EnclosureZooKeeper;
        }

        public int Id => _EnclosureZooKeeper.Id;
        public int EnclosureId => _EnclosureZooKeeper.EnclosureId;
        public int ZooKeeperId => _EnclosureZooKeeper.ZooKeeperId;
    }
}