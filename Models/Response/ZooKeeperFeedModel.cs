using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Models.Response
{  
 
    public class FeedZooKeeperModel : ZooKeeperResponse
    {
        public FeedZooKeeperModel(ZooKeeper zooKeeper) : base(zooKeeper) 
        { 

        }
    }

    public class FeedEnclosureModel : EnclosureResponse
    {
        public FeedEnclosureModel(Enclosure enclosure) : base(enclosure) 
        {

        }
    }

    public class FeedEnclosureZooKeeperModel : EnclosureZooKeeperResponse
    {
        public FeedEnclosureZooKeeperModel(EnclosureZooKeeper enclosureZooKeeper) : base(enclosureZooKeeper) 
        { 
            
        }
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