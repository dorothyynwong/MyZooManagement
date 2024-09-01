using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Models.Response
{   
    
    public class FeedAnimalModel : AnimalResponse
    {
        public FeedAnimalModel(Animal animal) : base(animal) 
        { 
            // Enclosure = new FeedEnclosureModel(animal.Enclosure);
        }

        // public FeedEnclosureModel Enclosure { get; }
    }

    public class AnimalFeedModel : ListResponse<FeedAnimalModel>
    {
        private AnimalFeedModel(SearchRequest search, IEnumerable<FeedAnimalModel> items, int totalNumberOfItems) 
            : base(search, items, totalNumberOfItems, "animals") { }

        public static AnimalFeedModel Create(SearchRequest searchRequest, IEnumerable<Animal> animals, int totalNumberOfItems)
        {
            var feedModels = animals.Select(p => new FeedAnimalModel(p));
            return new AnimalFeedModel(searchRequest, feedModels, totalNumberOfItems);
        }
    }
}