using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkProject.Models
{
    public class Categories : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
