using System;
using ZooManagement.Helpers;
using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public static class RandomNumberGenerator
    {
        private static readonly Random Random = new Random();
        
        public static int GetSpeciesId()
        {
            return Random.Next(1, SampleSpecies.NumberOfSpecies + 1);
        }

        public static int GetEnclosureId()
        {
            return Random.Next(1, SampleEnclosures.NumberOfEnclosures + 1);
        }

        public static Sex GetSex()
        {
            return Random.Next(0, 2) == 0 ? Sex.Male : Sex.Female;
        }
        

        public static int GetMaxNumberOfAnimals()
        {
            return Random.Next(1,50);
        }

        public static int GetNumberOfAnimals(int maxNumberOfAnimals)
        {
            return Random.Next(0,maxNumberOfAnimals);
        }
    }
}
