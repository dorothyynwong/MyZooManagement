using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Repositories
{
    public interface IEnclosuresRepo
    {
        Enclosure GetEnclosure(int id);
        Enclosure AddAnimalToEnclosure(int id);
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

        public Enclosure AddAnimalToEnclosure(int id)
        {
            Enclosure enclosure = GetEnclosure(id);
            enclosure.NumberOfAnimals++;
            var updateResult = _context.Enclosures.Update(enclosure);
            _context.SaveChanges();
            return updateResult.Entity;
        }
    }
}