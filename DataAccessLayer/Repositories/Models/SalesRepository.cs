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
    public class SalesRepository : IRepository<Sale>, IDisposable
    {
        private SalesDBContext _context;

        public SalesRepository(SalesDBContext context)
        {
            _context = context;
        }

        public void Create(Sale item)
        {
            _context.Sales.Add(item);
        }

        public IEnumerable<Sale> Get(Func<Sale, bool> predicate)
        {
            return _context.Sales.Where(predicate).ToList();
        }

        public IEnumerable<Sale> GetAll()
        {
            return _context.Sales.ToList();
        }

        public void Remove(Sale item)
        {
            if (item != null)
                _context.Sales.Remove(item);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Sale item)
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
