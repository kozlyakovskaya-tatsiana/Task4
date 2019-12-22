using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.EntityModels
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public virtual ICollection<Sale> Sales { get; set; }

        public Product()
        {
            Sales = new List<Sale>();
        }
    }
}
