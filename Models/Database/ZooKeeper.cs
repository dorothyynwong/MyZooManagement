namespace ZooManagement.Models.Database
{
    public class ZooKeeper
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Enclosure> Enclosures { get; set; } = [];

    }
}
