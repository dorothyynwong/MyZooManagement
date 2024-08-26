using System.ComponentModel.DataAnnotations;
using ZooManagement.Helpers;

namespace ZooManagement.Models.Request
{
    public class CreateAnimalRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int SpeciesId { get; set; }

        [Required]
        public Sex Sex { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public DateTime DateCameToZoo { get; set; }
        [Required]
        public int EnclosureId { get; set; }
    }
}