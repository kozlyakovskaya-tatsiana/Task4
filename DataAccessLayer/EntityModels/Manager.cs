using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityModels
{
    public class Manager
    {
        public int Id { get; set; }

        [Required]
        public string SecondName { get; set; }


        public virtual ICollection<Sale> Sales { get; set; }

        public Manager()
        {
            Sales = new List<Sale>();
        }
    }
}
