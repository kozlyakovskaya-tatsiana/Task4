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
    public class CustomersRepository : IRepository<Customer>, IDisposable
    {
        private SalesDBContext _context;

        public CustomersRepository(SalesDBContext context)
        {
            _context = context;
        }

        public void Create(Customer item)
        {
            _context.Customers.Add(item);
        }

        public IEnumerable<Customer> Get(Func<Customer, bool> predicate)
        {
            return _context.Customers.Where(predicate).ToList();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public void Remove(Customer item)
        {
            if (item != null)
                _context.Customers.Remove(item);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Customer item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
