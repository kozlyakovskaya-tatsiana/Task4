using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityModels
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }


        public virtual IEnumerable<Sale> Sales { get; set; }

        public Customer()
        {
            Sales = new List<Sale>();
        }

    }
}
