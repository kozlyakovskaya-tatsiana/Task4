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
    public class ProductsRepository : IRepository<Product>, IDisposable
    {
        private SalesDBContext _context;

        public ProductsRepository(SalesDBContext context)
        {
            _context = context;
        }

        public void Create(Product item)
        {
            _context.Products.Add(item);
        }

        public IEnumerable<Product> Get(Func<Product, bool> predicate)
        {
            return _context.Products.Where(predicate).ToList();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Remove(Product item)
        {
            if (item != null)
                _context.Products.Remove(item);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Product item)
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
