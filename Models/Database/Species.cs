namespace ZooManagement.Models.Database
{
    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassificationId { get; set; }
        public Classification Classification { get; set; }
    }
}
