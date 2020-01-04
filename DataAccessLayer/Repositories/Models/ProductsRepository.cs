using DataAccessLayer.ContextModels;
using DataAccessLayer.EntityModels;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer.Repositories.Models
{
    public class ProductsRepository : IRepository<Product>, IExistable<Product>, IDisposable
    {
        private SalesDBContext _db;

        public ProductsRepository(SalesDBContext context)
        {
            _db = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Product item)
        {
            if (item != null)

                _db.Products.Add(item);
        }

        public IQueryable<Product> GetAll()
        {
            return _db.Products;
        }

        public Product Get(int id)
        {
            return _db.Products.Find(id);
        }

        public void Remove(int id)
        {
            var product = _db.Products.Find(id);

            if (product != null)

                _db.Products.Remove(product);
        }

        public void Update(Product item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        /* public void Save()
         {
             _db.SaveChanges();
         }*/

        public void Dispose()
        {
            _db.Dispose();

            GC.SuppressFinalize(this);
        }

        public bool Exists(Product item, out Product resultItem)
        {

            var products = _db.Products.Where(product => product.Name.Equals(item.Name) && product.Cost == item.Cost);

            if (products.Count() != 0)
            {
                resultItem = products.FirstOrDefault();

                return true;
            }

            resultItem = null;

            return false;
        }
    }
}
