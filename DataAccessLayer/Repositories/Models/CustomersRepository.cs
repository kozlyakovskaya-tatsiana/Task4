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
        private SalesDBContext _db;

        public CustomersRepository(SalesDBContext context)
        {
            _db = context;
        }

        public void Create(Customer item)
        {
            _db.Customers.Add(item);
        }

        public IQueryable<Customer> GetAll()
        {
            return _db.Customers;
        }

        public Customer Get(int id)
        {
            return _db.Customers.Find(id);
        }

        public void Remove(int id)
        {
            var customer = _db.Customers.Find(id);

            if (customer != null)
                _db.Customers.Remove(customer);
        }

        public void Update(Customer item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        /*  public void Save()
          {
              db.SaveChanges();
          }*/

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Exists(Customer item, out Customer resultItem)
        {
            var customers = _db.Customers.Where(customer => customer.FullName.Equals(item.FullName));

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
