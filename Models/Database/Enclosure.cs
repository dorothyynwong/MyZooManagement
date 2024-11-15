namespace ZooManagement.Models.Database
{
    public class Enclosure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxNumberOfAnimals   { get; set; }
        public int NumberOfAnimals  { get; set; }

        // public List<ZooKeeper> ZooKeepers { get; set; } = [];
        public List<Animal> Animals { get; set; } = [];
        public List<EnclosureZooKeeper> EnclosureZooKeepers { get; set; } = [];
    }
}
