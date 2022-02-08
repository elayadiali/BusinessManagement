using System.ComponentModel.DataAnnotations;

namespace DomainModel.Models
{
    public class Restaurant: BaseEntity
    {
        [Key]
        public long? Id { get; set; } 

        public string Name { get; set; }

        public List<Plat> Plats { get; set; }
    }
}
