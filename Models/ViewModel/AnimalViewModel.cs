using ZooManagement.Helpers;

namespace ZooManagement.Models.ViewModel
{
    public class AnimalViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpeciesId { get; set; }
        public string SpeciesName { get; set; }
        public int ClassificationId { get; set; }
        public string ClassificationName  { get; set; }
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age => DateHelper.CalculateAge(DateOfBirth); 
        public DateTime DateCameToZoo { get; set; }
        public int EnclosureId { get; set; }
        public string EnclosureName { get; set; }

    }
}
