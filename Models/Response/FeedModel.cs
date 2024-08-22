using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Models.Response
{   
    
    public class FeedAnimalModel : AnimalResponse
    {
        public FeedAnimalModel(Animal animal) : base(animal)
        {
        }

    }

    public class FeedModel : ListResponse<FeedAnimalModel>
    {
        private FeedModel(SearchRequest search, IEnumerable<FeedAnimalModel> items, int totalNumberOfItems) 
            : base(search, items, totalNumberOfItems, "feed") { }

        public static FeedModel Create(SearchRequest searchRequest, IEnumerable<Animal> animals, int totalNumberOfItems)
        {
            var feedModels = animals.Select(p => new FeedAnimalModel(p));
            return new FeedModel(searchRequest, feedModels, totalNumberOfItems);
        }
    }
}