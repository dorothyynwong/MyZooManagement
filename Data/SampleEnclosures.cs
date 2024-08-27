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
            int maxNumberOfAnimals = RandomNumberGenerator.GetMaxNumberOfAnimals();
            return new Enclosure
            {
                Id = index+1,
                Name = EnclosureGenerator.GetEnclosure(index),
                MaxNumberOfAnimals = maxNumberOfAnimals,
                NumberOfAnimals = RandomNumberGenerator.GetNumberOfAnimals(maxNumberOfAnimals)
            };
        }
    }
}