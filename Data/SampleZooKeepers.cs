using ZooManagement.Models.Database;
using ZooManagement.Helpers;

namespace ZooManagement.Data
{
    public static class SampleZooKeepers
    {
        public const int NumberOfZooKeepers = 30;

        public static IEnumerable<ZooKeeper> GetZooKeepers()
        {
            return Enumerable.Range(0, NumberOfZooKeepers).Select(CreateRandomZooKeeper);
        }

        private static ZooKeeper CreateRandomZooKeeper(int index)
        {
            return new ZooKeeper
            {
                Id = index+1,
                Name = NameGenerator.GetAnimalName(index),
                EnclosureId = RandomNumberGenerator.GetEnclosureId()
            };
        }
    }
}
