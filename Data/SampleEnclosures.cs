using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public static class SampleEnclosures
    {
        public static int NumberOfEnclosures = 8;
        
        public static IEnumerable<Enclosure> GetEnclosures()
        {
            return Enumerable.Range(0, NumberOfEnclosures).Select(CreateRandomEnclosure);

        }

        private static Enclosure CreateRandomEnclosure(int index)
        {
            (int maxNumberOfAnimals, int numberOfAnimals) = RandomNumberGenerator.GetMaxAndNumberOfAnimals();

            return new Enclosure
            {
                Id = index+1,
                Name = SpeciesGenerator.GetSpecies(index),
                MaxNumberOfAnimals = maxNumberOfAnimals,
                NumberOfAnimals = numberOfAnimals
            };
        }
    }
}