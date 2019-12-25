using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Parsers.Models
{
    public class CsvLine
    {
        public string ManagerName { get; private set; }

        public DateTime DateTime { get; private set; }

        public string CustomerName { get; private set; }

        public string ProductName { get; private set; }

        public double ProductSum { get; private set; }

        public CsvLine(string managerName, string dateTime, string customer, string productName, string productSum)
        {
            ManagerName = managerName ?? throw new Exception("Invalid value of manager's name");

            DateTime = DateTime.Parse(dateTime);

            CustomerName = customer ?? throw new Exception("Invalid value of customer's name");

            ProductName = productName ?? throw new Exception("Invalid value of product's name");

            ProductSum = double.Parse(productSum);

        }
    }
}
