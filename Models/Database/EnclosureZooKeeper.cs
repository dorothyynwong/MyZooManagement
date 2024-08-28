namespace ZooManagement.Models.Database
{
    public class EnclosureZooKeeper
    {
        public int EnclosureId { get; set; }
        public int ZooKeeperId { get; set; }
        
        public Enclosure Enclosure { get; set; }
        public ZooKeeper ZooKeeper { get; set; }
        
    }
}
