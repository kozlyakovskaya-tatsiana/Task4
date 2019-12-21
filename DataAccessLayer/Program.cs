using DataAccessLayer.ContextModels;
using DataAccessLayer.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SalesDBContext db = new SalesDBContext())
            {

                /*Customer cust = db.Customers.FirstOrDefault();
                 Product pro = db.Products.FirstOrDefault();
                 Manager man = db.Managers.FirstOrDefault();*/

                // db.Sales.Add(new Sale { Manager = man, Customer = cust, Product = pro, dateTime = DateTime.Now, Sum = 899f });
                //db.SaveChanges();

                var u = db.Managers.Include(man=>man.Sales).FirstOrDefault();

                //  var u = db.Sales.Include(sale=>sale.Manager).ToList();




                Console.WriteLine("Success");
            }
            Console.ReadKey();
        }
    }
}
