using ZooManagement.Helpers;
using ZooManagement.Models.ViewModel;

namespace ZooManagement.Models.Response
{
    public class AnimalDetailsResponse
    {
        private readonly AnimalViewModel _animal;

        public AnimalDetailsResponse(AnimalViewModel animal)
        {
            _animal = animal;
        }

        public int Id => _animal.Id;
        public string Name => _animal.Name;
        public int SpeciesId => _animal.SpeciesId;
        public Sex Sex => _animal.Sex;
        public DateTime DateOfBirth => _animal.DateOfBirth;
        public int Age => DateHelper.CalculateAge(DateOfBirth);
        public DateTime  DateCameToZoom => _animal.DateCameToZoo;
        public int EnclosureId => _animal.EnclosureId;
        public int ClassificationId => _animal.ClassificationId;
        public string ClassificationName => _animal.ClassificationName;
        public string SpeciesName => _animal.SpeciesName;
        public string EnclosureName => _animal.EnclosureName;

    }
}