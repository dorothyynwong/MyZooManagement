using ZooManagement.Models.Database;

namespace ZooManagement.Models.Request
{
    public class CreateAnimalRequest
    {
        public string Name { get; set; }
        public int SpeciesId { get; set; }
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCameToZoo { get; set; }
    }
}