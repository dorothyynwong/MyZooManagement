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
            ZooKeepers = animal.ZooKeepers.Select(z => new ZooKeeperResponse(z));
        }

        public int Id => _animal.Id;
        public string Name => _animal.Name;
        public int ClassificationId => _animal.ClassificationId;
        public string ClassificationName => _animal.ClassificationName;
        public int SpeciesId => _animal.SpeciesId;
        public string SpeciesName => _animal.SpeciesName;
        public Sex Sex => _animal.Sex;
        public DateTime DateOfBirth => _animal.DateOfBirth;
        public int Age => DateHelper.CalculateAge(DateOfBirth);
        public DateTime  DateCameToZoom => _animal.DateCameToZoo;
        public int EnclosureId => _animal.EnclosureId;
        public string EnclosureName => _animal.EnclosureName;

        public IEnumerable<ZooKeeperResponse> ZooKeepers {get;}

    }
}