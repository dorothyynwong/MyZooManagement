using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public static class SampleSpecies
    {
        public const int NumberOfSpecies = 6;

        private static readonly IList<IList<string>> Data = new List<IList<string>>
        {
            new List<string> { "1","Lion" ,"1"},
            new List<string> { "2","Tigers","1" },
            new List<string> { "3","Swallows","3" },
            new List<string> { "4","Parrot","3" },
            new List<string> { "5","Cod","5" },
            new List<string> { "6","Snake","6" }
        };

        public static IEnumerable<Species> GetSpecies()
        {
            return Enumerable.Range(0, NumberOfSpecies).Select(CreateRandomSpecies);
        }

        private static Species CreateRandomSpecies(int index)
        {

            return new Species
            {
                Id = int.Parse(Data[index][0]),
                Name = Data[index][1],
                ClassificationId = int.Parse(Data[index][2])
            };
        }
    }
}
