using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
          
        }

        public Manager(string secondName)
        {
            SecondName = string.IsNullOrWhiteSpace(secondName)
                ? throw new Exception("Invalid value of manager's name")
                : secondName;
        }

    }
}
