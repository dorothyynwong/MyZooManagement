using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public static class SampleAnimals
    {
        public const int NumberOfAnimals = 1;

        private static readonly IList<IList<string>> Data = new List<IList<string>>
        {
            new List<string> { "1","Kania", "1", "2","29/04/2020","29/04/2020" }

        };

        public static IEnumerable<Animal> GetAnimals()
        {
            return Enumerable.Range(0, NumberOfAnimals).Select(CreateRandomAnimal);
        }

        private static Animal CreateRandomAnimal(int index)
        {
            int sexNo = int.Parse(Data[index][3]);

            return new Animal
            {
                Id = int.Parse(Data[index][0]),
                Name = Data[index][1],
                SpeciesId = int.Parse(Data[index][2]),
                Sex = sexNo == 1 ? Sex.Male : Sex.Female,
                DateOfBirth = DateTime.Parse(Data[index][4]),
                DateCameToZoo = DateTime.Parse(Data[index][5]),
            };
        }
    }
}
