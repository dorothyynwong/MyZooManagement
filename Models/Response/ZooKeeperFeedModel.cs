using Newtonsoft.Json;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using ZooManagement.Repositories;

namespace ZooManagement.Models.Response
{  
    public class FeedAnimalModel : AnimalResponse
    {
        public FeedAnimalModel(Animal animal) : base(animal) 
        { 
        }
    }
 
    public class FeedZooKeeperModel : ZooKeeperResponse
    {
        public FeedZooKeeperModel(ZooKeeper zooKeeper) : base(zooKeeper) 
        { 
            Enclosures = zooKeeper.Enclosures
                            .Select(e => new FeedEnclosureModel(e));
        }
        
        public IEnumerable<FeedEnclosureModel> Enclosures { get; }
    }

    public class FeedEnclosureModel : EnclosureResponse
    {
        public FeedEnclosureModel(Enclosure enclosure) : base(enclosure) 
        {
            Name = enclosure.Name; 
            MaxNumberOfAnimals = enclosure.MaxNumberOfAnimals;
            NumberOfAnimals = enclosure.NumberOfAnimals;
            Animals = enclosure.Animals
                        .Select(e => new FeedAnimalModel(e));
        }
        
        [JsonProperty(Order = 1)] 
        public new string Name { get; set; }

        [JsonProperty(Order = 2)] 
        public new int MaxNumberOfAnimals { get; set; }

        [JsonProperty(Order = 3)]
        public new int NumberOfAnimals { get; set; }

        [JsonProperty(Order = 4)] 
        public IEnumerable<FeedAnimalModel> Animals { get; }
    }

    public class FeedEnclosureZooKeeperModel : EnclosureZooKeeperResponse
    {
        public FeedEnclosureZooKeeperModel(EnclosureZooKeeper enclosureZooKeeper) : base(enclosureZooKeeper) 
        { 
            Enclosure = new FeedEnclosureModel(enclosureZooKeeper.Enclosure);
            ZooKeeper = new FeedZooKeeperModel(enclosureZooKeeper.ZooKeeper);
        }

        public FeedEnclosureModel Enclosure { get; }
        public FeedZooKeeperModel ZooKeeper { get; }
    }


    public class ZooKeeperFeedModel : ListResponse<FeedZooKeeperModel>
    {
        private ZooKeeperFeedModel(SearchRequest search, IEnumerable<FeedZooKeeperModel> items, int totalNumberOfItems) 
            : base(search, items, totalNumberOfItems, "zookeepers") { }

        public static ZooKeeperFeedModel Create(SearchRequest searchRequest, IEnumerable<ZooKeeper> zooKeepers, int totalNumberOfItems)
        {
            var feedModels = zooKeepers.Select(p => new FeedZooKeeperModel(p));
            return new ZooKeeperFeedModel(searchRequest, feedModels, totalNumberOfItems);
        }
    }
}