using System;

namespace BusinessLayer.Parsers.Models
{
    public class CsvLine
    {
        public string ManagerName { get; private set; }

        public DateTime Date { get; private set; }

        public string CustomerName { get; private set; }

        public string ProductName { get; private set; } 

        public double ProductCost { get; private set; }

        public CsvLine(string managerName, string date, string customerName, string productName, string productCost)
        {
            ManagerName = managerName;

            Date = DateTime.Parse(date);

            CustomerName = customerName;

            ProductName = productName;

            ProductCost = Convert.ToDouble(productCost);
        }

        public override string ToString()
        {
            return $"{ManagerName} {Date} {CustomerName} {ProductName} {ProductCost}";
        }
    }
}
