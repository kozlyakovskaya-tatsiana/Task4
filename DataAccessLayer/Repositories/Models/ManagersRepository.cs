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
    public class ManagersRepository : IRepository<Manager>, IDisposable
    {
        private SalesDBContext _context;

        public ManagersRepository(SalesDBContext context)
        {
            _context = context;
        }
        public void Create(Manager item)
        {
            _context.Managers.Add(item);
        }

        public IEnumerable<Manager> Get(Func<Manager, bool> predicate)
        {
            return _context.Managers.Where(predicate).ToList();
        }

        public IEnumerable<Manager> GetAll()
        {
            return _context.Managers.ToList();
        }

        public void Remove(Manager item)
        {
            if (item != null) _context.Managers.Remove(item);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Manager item)
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
