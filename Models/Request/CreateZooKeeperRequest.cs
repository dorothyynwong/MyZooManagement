using System.ComponentModel.DataAnnotations;
using ZooManagement.Helpers;

namespace ZooManagement.Models.Request
{
    public class CreateZooKeeperRequest
    {
        [Required]
        public int Id { get;}
        
        [Required]
        public string Name { get; set; }

        [Required]
        public int EnclosureId { get; set; }
    }
}