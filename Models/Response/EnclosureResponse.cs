using ZooManagement.Models.Database;
using ZooManagement.Helpers;

namespace ZooManagement.Models.Response
{
    public class EnclosureResponse
    {
        private readonly Enclosure _enclosure;

        public EnclosureResponse(Enclosure enclosure)
        {
            _enclosure = enclosure;
        }

        public int Id => _enclosure.Id;
        public string Name => _enclosure.Name;
        public int MaxNumberOfAnimals=> _enclosure.MaxNumberOfAnimals;
        public int NumberOfAnimals => _enclosure.NumberOfAnimals;
    }
}