using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Repositories
{
    public interface IEnclosuresRepo
    {
        bool IsLimitReached(int id);
    }

    public class EnclosuresRepo : IEnclosuresRepo
    {
        private readonly ZooManagementDbContext _context;

        public EnclosuresRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public bool IsLimitReached(int id)
        { 
            Enclosure enclosure = _context.Enclosures
                .Single(enclosure => enclosure.Id == id);
            return enclosure.MaxNumberOfAnimals > enclosure.NumberOfAnimals;
        }
    }
}