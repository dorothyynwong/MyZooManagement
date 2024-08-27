using System.Collections.Generic;

namespace ZooManagement.Data
{
    public static class EnclosureGenerator
    {
        private static readonly IList<string> Enclosures = new List<string>
        {
            "Lion",
            "Aviary",
            "Reptile",
            "Giraffe",
            "Hippo",
            "Penguin",
            "Tiger",
            "Parrot",
        };

        public static string GetEnclosure(int index)
        {
            return Enclosures[index];
        }
    }
}