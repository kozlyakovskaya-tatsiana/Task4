using DataAccessLayer.EntityModels;
using System;

namespace BusinessLayer.Parsers.Models
{
    public class CsvLine
    {
        public Manager Manager { get; private set; }

        public DateTime DateTime { get; private set; }

        public Customer Customer { get; private set; }

        public Product Product { get; private set; } 

        public CsvLine(string managerName, string dateTime, string customerName, string productName, string productSum)
        {
            Manager = new Manager(managerName);

            DateTime = DateTime.Parse(dateTime);

            Customer = new Customer(customerName);

            Product = new Product(productName, Convert.ToDouble(productSum));
        }
    }
}
