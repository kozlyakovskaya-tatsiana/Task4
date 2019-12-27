using BusinessLayer.Parsers;
using BusinessLayer.Parsers.Models;
using DataAccessLayer.ContextModels;
using DataAccessLayer.EntityModels;
using DataAccessLayer.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.WorkWithFiles
{
    public class FileHandler
    {
        static object locker = new object();
        public void StartHandle(string fileName, IParser<CsvLine> parser)
        {
            var lines = parser.ParseFile(fileName);
            lock (locker)
            {
                using (var unitOfWork = new UnitOfWork())
                {

                    foreach (var line in lines)
                    {
                        var manager = new Manager(line.ManagerName);

                        var date = line.DateTime;

                        var customer = new Customer(line.CustomerName);

                        var product = new Product(line.ProductName, line.ProductSum);

                        unitOfWork.ManagersRepository.Exists(manager, out var resultManager);

                        unitOfWork.ProductsRepository.Exists(product, out var resultProduct);

                        unitOfWork.CustomersRepository.Exists(customer, out var resultCustomer);

                        unitOfWork.SalesRepository.Create(new Sale(resultManager, resultCustomer, resultProduct, date, line.ProductSum));

                        unitOfWork.Save();

                    }

                }
                Thread.Sleep(3000);
            }
            Console.WriteLine(fileName + "was saved");
        }
    }
}
