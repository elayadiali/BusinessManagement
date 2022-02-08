using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Ingredient:BaseEntity
    {
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("[PlatId]")]
        public int PlatId { get; set; }
    }
}
