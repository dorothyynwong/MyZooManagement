using System.Collections.Generic;

namespace ZooManagement.Data
{
    public static class SpeciesGenerator
    {
        private static readonly IList<string> Species = new List<string>
        {
            "Lion",
            "Aviary",
            "Reptile",
            "Giraffe",
            "Hippo",
            "Penguin",
            "Tiger",
            "Parrot"
        };

        public static string GetSpecies(int index)
        {
            return Species[index];
        }
    }
}