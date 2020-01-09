using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.EntityModels
{
    public class Sale
    {
        public int Id { get; set; }

        [Required]
        public double Sum { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int? ManagerId { get; set; }

        public int? CustomerId { get; set; }

        public int? ProductId { get; set; }


        public virtual Manager Manager { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }

        public Sale()
        {

        }

        public Sale(Manager manager, Customer customer, Product product, DateTime dateTime)
        {
            Manager = manager;

            Date = dateTime;

            Customer = customer;

            Product = product;

            Sum = Product.Cost;
        }

    }
}
