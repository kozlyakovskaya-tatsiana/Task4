using BusinessLayer.Parsers;
using BusinessLayer.Parsers.Models;
using DataAccessLayer.EntityModels;
using DataAccessLayer.Repositories.Models;
using System;

namespace BusinessLayer.WorkWithFiles
{
    public class FileHandler
    {
        private static object locker = new object();

        public void StartHandle(string fileName, IParser<CsvLine> parser)
        {
            var lines = parser.ParseFile(fileName);

            foreach (var line in lines)
            {
                SaveData(line.Manager, line.Product, line.Customer, line.DateTime);
            }

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
