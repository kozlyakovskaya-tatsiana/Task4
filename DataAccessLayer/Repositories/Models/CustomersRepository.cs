using DataAccessLayer.ContextModels;
using DataAccessLayer.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Models
{
    public class CustomersRepository : IRepository<Customer>, IExistable<Customer>, IDisposable
    {
        private SalesDBContext db;

        public CustomersRepository(SalesDBContext context)
        {
            db = context;
        }

        public void Create(Customer item)
        {
            db.Customers.Add(item);
        }

        public IQueryable<Customer> GetAll()
        {
            return db.Customers;
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public void Remove(int id)
        {
            var customer = db.Customers.Find(id);

            if (customer != null)
                db.Customers.Remove(customer);
        }

        public void Update(Customer item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /*  public void Save()
          {
              db.SaveChanges();
          }*/

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Exists(Customer item, out Customer resultItem)
        {
            var customers = db.Customers.Where(customer=> customer.FullName.Equals(item.FullName)).ToArray();

            if (customers.Count() != 0)
            {
                resultItem = customers.FirstOrDefault();
                return true;
            }

            resultItem = item;
            return false;
        }
    }
}
