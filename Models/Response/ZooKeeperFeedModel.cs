using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using ZooManagement.Repositories;

namespace ZooManagement.Models.Response
{  
 
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
            Animals = enclosure.Animals
                        .Select(e => new FeedAnimalModel(e));
            ZooKeepers = enclosure.ZooKeepers
                        .Select(e => new FeedZooKeeperModel(e));
        }

        public IEnumerable<FeedAnimalModel> Animals {get;}
        public IEnumerable<FeedZooKeeperModel> ZooKeepers {get;}
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