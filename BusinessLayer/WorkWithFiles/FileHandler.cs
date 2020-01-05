using BusinessLayer.Parsers;
using BusinessLayer.Parsers.Models;
using DataAccessLayer.EntityModels;
using DataAccessLayer.Repositories.Models;
using System;
using System.IO;
using System.Linq;

namespace BusinessLayer.WorkWithFiles
{
    public class FileHandler
    {
        private static object locker = new object();

        public void StartHandle(string pathToFile, IParser<CsvLine> parser)
        {
            var lines = parser.ParseFile(pathToFile);

            foreach (var line in lines)
            {
                SaveData(line.Manager, line.Product, line.Customer, line.DateTime);
            }

            var shortFileName = pathToFile.ToString().Split('\\').LastOrDefault();

            new FileInfo(pathToFile).MoveTo(@"E:\Универ\Epam\Task4\Files\ParsedFiles\" + DateTime.Now.ToString("dd.MM.yyyy HH-mm-ss") + shortFileName);

        }

        private void SaveData(Manager manager, Product product, Customer customer, DateTime date)
        {
            lock (locker)
            {
                using (var unitOfWork = new UnitOfWork())
                {

                    unitOfWork.ManagersRepository.Exists(manager, out var resultManager);

                    unitOfWork.ProductsRepository.Exists(product, out var resultProduct);

                    unitOfWork.CustomersRepository.Exists(customer, out var resultCustomer);

                    unitOfWork.SalesRepository.Create(new Sale
                    {
                        Manager = resultManager ?? manager,

                        Customer = resultCustomer ?? customer,

                        Product = resultProduct ?? product,

                        DateTime = date,

                        Sum = resultProduct?.Cost ?? product.Cost
                    });

                    unitOfWork.Save();
                }
            }
        }
    }
}
