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

        public static Sex GetSex()
        {
            return Random.Next(0, 2) == 0 ? Sex.Male : Sex.Female;
        }
        

        public static (int, int) GetMaxAndNumberOfAnimals()
        {
            int max = Random.Next(1,50);
            int noOfAnimals = Random.Next(0,max);
            return (max , noOfAnimals);
        }
    }
}
