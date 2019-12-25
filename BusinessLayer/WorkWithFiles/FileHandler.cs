using BusinessLayer.Parsers;
using BusinessLayer.Parsers.Models;
using DataAccessLayer.ContextModels;
using DataAccessLayer.EntityModels;
using DataAccessLayer.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.WorkWithFiles
{
    public class FileHandler
    {
        public void StartHandle(string fileName, IParser<CsvLine> parser)
        {
            var lines = parser.ParseFile(fileName);

            using (var unitOfWork = new UnitOfWork())
            {

                foreach (var line in lines)
                {
                    var manager = new Manager(line.ManagerName);

                    var date = line.DateTime;

                    var customer = new Customer(line.CustomerName);

                    var product = new Product(line.ProductName, line.ProductSum);

                    unitOfWork.ManagersRepository.Create(manager);

                    unitOfWork.ProductsRepository.Create(product);

                    unitOfWork.CustomersRepository.Create(customer);

                    unitOfWork.SalesRepository.Create(new Sale(manager, customer, product, date, line.ProductSum));

                }

                unitOfWork.Save();
            }
        }
    }
}
