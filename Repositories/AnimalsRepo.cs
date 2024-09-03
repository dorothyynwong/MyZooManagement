using Microsoft.EntityFrameworkCore;
using ZooManagement.Helpers;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using ZooManagement.Models.ViewModel;

namespace ZooManagement.Repositories
{
    public interface IAnimalsRepo
    {

        Animal GetAnimalById(int id);
        List<Animal> GetAnimalByEnclosureId(int enclosureId);

        Animal Create(CreateAnimalRequest animal);

        IEnumerable<AnimalViewModel> Search(AnimalSearchRequest search);

        int Count(AnimalSearchRequest search);
    }

    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooManagementDbContext _context;
        public AnimalsRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public Animal GetAnimalById(int id)
        {
            return _context.Animals
                .FirstOrDefault(animal => animal.Id == id);
        }

        public List<Animal> GetAnimalByEnclosureId(int enclosureId)
        {
            return _context.Animals
                .Where(animal => animal.EnclosureId == enclosureId)
                .ToList();
        }

        public IEnumerable<AnimalViewModel> Search(AnimalSearchRequest search)
        {

            var query = _context.Animals
                    .Include(a => a.Species)
                    .ThenInclude(s => s.Classification)
                    .Where(a => search.SpeciesId == null || a.SpeciesId == search.SpeciesId)
                    .Where(a => search.ClassificationId == null || a.Species.ClassificationId == search.ClassificationId)
                    .Where(a => search.Name == null || a.Name == search.Name)
                    .Where(a => search.DateCameToZoo == null || a.DateCameToZoo.Date == search.DateCameToZoo)
                    .Where(a => search.EnclosureId == null || a.EnclosureId == search.EnclosureId);
                    // .OrderBy(a => search.OrderBy == null ? a.Species.Name : search.OrderBy);

            if (string.IsNullOrEmpty(search.OrderBy))
            {
                query = query.OrderBy(a => a.Species.Name);
            }
            else
            {
                query = query.OrderBy(a => EF.Property<object>(a, search.OrderBy));
            }

            List<AnimalViewModel> animals = query.Select(a => new AnimalViewModel
            {
                Id = a.Id,
                Name = a.Name,
                SpeciesId = a.SpeciesId,
                ClassificationId = a.Species.ClassificationId,
                DateOfBirth = a.DateOfBirth,
                DateCameToZoo = a.DateCameToZoo,
                EnclosureId = a.EnclosureId,
                EnclosureName = a.Enclosure.Name,
                SpeciesName = a.Species.Name,
                ClassificationName = a.Species.Classification.Name
            })
                        .ToList();


            IEnumerable<AnimalViewModel> filteredAndOrderedAnimals = animals
                   .Where(a => search.Age == null || a.Age == search.Age)
                   // .OrderBy(a => CustomOrder.EnclosureOrder.ContainsKey(a.EnclosureName) ? CustomOrder.EnclosureOrder[a.EnclosureName] : int.MaxValue)
                   // .ThenBy(a => a.Name)
                   .Skip((search.Page - 1) * search.PageSize)
                   .Take(search.PageSize);

            return filteredAndOrderedAnimals;
        }

        public int Count(AnimalSearchRequest search)
        {
            return _context.Animals
                .Count(p => search.SpeciesId == null || p.SpeciesId == search.SpeciesId);
        }

        public Animal Create(CreateAnimalRequest animal)
        {
            var insertResult = _context.Animals.Add(new Animal
            {
                Name = animal.Name,
                SpeciesId = animal.SpeciesId,
                Sex = animal.Sex,
                DateOfBirth = animal.DateOfBirth.Date,
                DateCameToZoo = animal.DateCameToZoo.Date,
                EnclosureId = animal.EnclosureId
            });
            _context.SaveChanges();
            return insertResult.Entity;
        }
    }
}