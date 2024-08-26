using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public static class SampleSpecies
    {
        public const int NumberOfSpecies = 6;

        // private static readonly IList<IList<string>> Data = new List<IList<string>>
        // {
        //     new List<string> { "1","1"},
        //     new List<string> { "2","1" },
        //     new List<string> { "3","3" },
        //     new List<string> { "4","3" },
        //     new List<string> { "5","5" },
        //     new List<string> { "6","6" }
        // };

        public static IEnumerable<Species> GetSpecies()
        {
            return Enumerable.Range(0, NumberOfSpecies).Select(CreateRandomSpecies);
        }

        private static Species CreateRandomSpecies(int index)
        {

            return new Species
            {
                Id = index+1,
                Name = SpeciesGenerator.GetSpecies(index),
                ClassificationId = index
            };
        }
    }
}
