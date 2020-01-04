using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.EntityModels
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

       public Customer()
        {
          
        }

        public Customer(string fullName)
        {
            FullName = string.IsNullOrWhiteSpace(fullName)
                ? throw new Exception("Invalid value of customer's name")
                : fullName;
        }

    }
}
