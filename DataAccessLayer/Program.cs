using DataAccessLayer.ContextModels;
using DataAccessLayer.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories.Models;

namespace DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
           /* using (SalesDBContext db = new SalesDBContext())
            {
                db.Products.Add(new Product("Philips", 237.85));
                db.SaveChanges();
            }

            using (SalesDBContext db = new SalesDBContext())
            {
                db.Products.Add(new Product("Philips", 237.85));
                db.SaveChanges();
            }

            Console.WriteLine("Success");*/
            

            Console.ReadKey();
        }
    }
}
