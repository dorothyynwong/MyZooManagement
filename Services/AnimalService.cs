using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using ZooManagement.Repositories;

namespace ZooManagement.Services
{
    public interface IAnimalService
    {
        Animal Create(CreateAnimalRequest animal);
    }

    public class AnimalService : IAnimalService
    {
        private readonly IAnimalsRepo _animals;
        private readonly IEnclosuresRepo _enclosures;

        public AnimalService(IAnimalsRepo animals, IEnclosuresRepo enclosures)
        {
            _animals = animals;
            _enclosures = enclosures;
        }

        public Animal Create(CreateAnimalRequest animal)
        {
            try
            {
                if (_enclosures.IsLimitReached(animal.EnclosureId))
                {
                    return _animals.Create(animal);
                }
                else
                {
                    throw new InvalidOperationException("Enclosure Limit has been reached !");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}