using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Plat:BaseEntity
    {
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Catrtegorie { get; set; }
        [ForeignKey("RestaurantId")]
        public long RestaurantId { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
