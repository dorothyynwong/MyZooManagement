using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public static class SampleEnclosuresZooKeepers
    {
        public static int NumberOfEnclosuresZooKeepers = 100;

        public static IEnumerable<EnclosureZooKeeper> GetEnclosuresZooKeepers()
        {
            Dictionary<string, int> enclosuresZooKeepers = new Dictionary<string, int>{};
            return Enumerable.Range(0, NumberOfEnclosuresZooKeepers).Select(index => CreateRandomEnclosureZooKeeper(index, enclosuresZooKeepers));

        }
        
        private static EnclosureZooKeeper CreateRandomEnclosureZooKeeper(int index, Dictionary<string, int> enclosuresZooKeepers)
        {
            int enclosureId = 0;
            int zooKeeperId = 0;
            do
            {
                enclosureId = RandomNumberGenerator.GetEnclosureId();
                zooKeeperId = RandomNumberGenerator.GetZooKeeperId();
            }
            while(enclosuresZooKeepers.ContainsKey(enclosureId.ToString()+zooKeeperId.ToString()));

            enclosuresZooKeepers.Add(enclosureId.ToString()+zooKeeperId.ToString(),1);

            return new EnclosureZooKeeper
            {
                EnclosureId = enclosureId,
                ZooKeeperId = zooKeeperId
            };
        }
    }
}