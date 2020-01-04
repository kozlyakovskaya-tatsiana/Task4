using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.EntityModels
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Cost { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

       public Product()
        {

        }

        public Product(string name, double cost)
        {
            Name = string.IsNullOrWhiteSpace(name)
                ? throw new Exception("Invalid input of product's name")
                : name;

            Cost = cost;
        }
    }
}
