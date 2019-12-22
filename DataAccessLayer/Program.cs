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
                var u = db.Managers.ToArray().LastOrDefault();
                Console.WriteLine(db.Managers.ToArray().LastOrDefault().SecondName);

                Console.WriteLine("Success");
            }

            Console.ReadKey();
        }
    }
}
