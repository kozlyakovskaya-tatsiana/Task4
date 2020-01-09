using DataAccessLayer.ContextModels;
using DataAccessLayer.EntityModels;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer.Repositories.Models
{
    public class SalesRepository : IRepository<Sale>, IDisposable
    {
        private SalesDBContext _db;

        public SalesRepository(SalesDBContext context)
        {
            _db = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Sale item)
        {
            if (item != null)
                _db.Sales.Add(item);
        }

        public IQueryable<Sale> GetAll()
        {
            return _db.Sales;
        }

        public Sale Get(int id)
        {
            return _db.Sales.Find(id);
        }

        public void Remove(int id)
        {
            var sale = _db.Sales.Find(id);

            if (sale != null)
                _db.Sales.Remove(sale);
        }

        public void Update(Sale item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
