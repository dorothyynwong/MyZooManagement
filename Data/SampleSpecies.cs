using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public static class SampleSpecies
    {
        public const int NumberOfSpecies = 8;
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
                ClassificationId = RandomNumberGenerator.GetClassificationId()
            };
        }
    }
}
