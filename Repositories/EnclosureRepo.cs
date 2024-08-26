using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Repositories
{
    public interface IEnclosuresRepo
    {
        Enclosure GetEnclosure(int id);
    }

    public class EnclosuresRepo : IEnclosuresRepo
    {
        private readonly ZooManagementDbContext _context;

        public EnclosuresRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public Enclosure GetEnclosure(int id)
        {
            return _context.Enclosures
                .Single(enclosure => enclosure.Id == id);
        }
    }
}