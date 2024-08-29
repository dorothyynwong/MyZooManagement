using Microsoft.EntityFrameworkCore;

namespace ZooManagement.Models.Database
{
    [Keyless]
    public class EnclosureZooKeeper
    {
        public int EnclosureId { get; set; }
        public int ZooKeeperId { get; set; }
        
        public Enclosure Enclosure { get; set; }
        public ZooKeeper ZooKeeper { get; set; }
        
    }
}
