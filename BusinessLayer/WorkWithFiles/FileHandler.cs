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
            try
            {
                var csvLines = parser.ParseFile(pathToFile);

                if (csvLines == null)
                    return;

                foreach (var line in csvLines)
                {
                    try
                    {
                        SaveData(line);
                    }
                    catch (Exception ex)
                    {
                        Log.Write($"{line} was not saved to databes because " + ex.Message);
                    }
                }

                try
                {
                    var fileName = Path.GetFileName(pathToFile);

                    var pathToDirectory = Path.GetDirectoryName(pathToFile);

                    new FileInfo(pathToFile).MoveTo(Path.Combine(pathToDirectory, "Parsed" + DateTime.Now.ToString("dd.MM.yyyy HH-mm-ss") + fileName));
                }
                catch(Exception ex)
                {
                    Log.Write("File wasn't renamed because " + ex.Message);
                }
                
            }

            catch (Exception ex)
            {
                Log.Write(ex.Message);
            }
        }

        private void SaveData(CsvLine csvLine)
        {

            if (csvLine == null)
                return;

            var managerName = csvLine.ManagerName;

            var productName = csvLine.ProductName;

            var productCost = csvLine.ProductCost;

            var customerName = csvLine.CustomerName;

            var date = csvLine.Date;

            lock (locker)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var manager = unitOfWork.ManagersRepository.GetAll().FirstOrDefault(man => man.Name == managerName) ?? new Manager(managerName);

                    var product = unitOfWork.ProductsRepository.GetAll().FirstOrDefault(prod => prod.Name == productName && prod.Cost == productCost) ?? new Product(productName, productCost);

                    var customer = unitOfWork.CustomersRepository.GetAll().FirstOrDefault(cust => cust.FullName == customerName) ?? new Customer(customerName);

                    unitOfWork.SalesRepository.Create(new Sale(manager, customer, product, date));

                    unitOfWork.Save();

                }
            }
        }
    }
}
