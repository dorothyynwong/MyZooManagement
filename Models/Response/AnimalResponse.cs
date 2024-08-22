using ZooManagement.Models.Database;
using ZooManagement.Helpers;

namespace ZooManagement.Models.Response
{
    public class AnimalResponse
    {
        private readonly Animal _animal;

        public AnimalResponse(Animal animal)
        {
            _animal = animal;
        }

        public int Id => _animal.Id;
        public string Name => _animal.Name;
        public int SpeciesId => _animal.SpeciesId;
        public Sex Sex => _animal.Sex;
        public DateTime DateOfBirth => _animal.DateOfBirth;
        public DateTime  DateCameToZoom => _animal.DateCameToZoo;
    }
}