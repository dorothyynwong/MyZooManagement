using ZooManagement.Models.Database;
using ZooManagement.Helpers;

namespace ZooManagement.Data
{
    public static class SampleAnimals
    {
        public const int NumberOfAnimals = 100;

        public static IEnumerable<Animal> GetAnimals(int startIndex, int numberOfAnimals, int enclosureId)
        {
            return Enumerable.Range(startIndex, numberOfAnimals).Select(index => CreateRandomAnimal(index, enclosureId));
        }

        private static Animal CreateRandomAnimal(int index, int enclosureId)
        {
            return new Animal
            {
                Id = index+1,
                Name = NameGenerator.GetAnimalName(index),
                SpeciesId = RandomNumberGenerator.GetSpeciesId(),
                Sex = RandomNumberGenerator.GetSex(),
                DateOfBirth = DateGenerator.GetDateOfBirth(),
                DateCameToZoo = DateGenerator.GetDateCameZoo(),
                EnclosureId = enclosureId
            
            };
        }
    }
}
