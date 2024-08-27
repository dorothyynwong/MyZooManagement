using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Repositories
{
    public interface ISpeciesRepo
    {
        Species GetSpecies(int id);
        int GetClassificationId(int id);

        IEnumerable<Species> Search(AnimalSearchRequest search);
    }

    public class SpeciesRepo : ISpeciesRepo
    {
        private readonly ZooManagementDbContext _context;

        public SpeciesRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public Species GetSpecies(int id)
        {
            return _context.Species
                .FirstOrDefault(Species => Species.Id == id);
        }

        public int GetClassificationId(int id)
        {
            Species species = GetSpecies(id);
            return species.ClassificationId;
        }

        public IEnumerable<Species> Search(AnimalSearchRequest search)
        {
            return _context.Species
                .Where(s => search.ClassificationId == null || s.ClassificationId == search.ClassificationId)
                .Skip((search.Page - 1) * search.PageSize)
                .Take(search.PageSize);
        }
    }
}