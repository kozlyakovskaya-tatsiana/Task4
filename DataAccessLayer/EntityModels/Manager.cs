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

        public Manager(string secondName):this()
        {
            SecondName = secondName;
        }

        public override bool Equals(object obj)
        {
            return obj is Manager && ((Manager)obj).SecondName.Equals(this.SecondName);
        }

        public override int GetHashCode()
        {
            return this.SecondName.GetHashCode();
        }
    }
}
