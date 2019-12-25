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
        private SalesDBContext db;

        public ManagersRepository(SalesDBContext context)
        {
            db = context;
        }

        public void Create(Manager item)
        {
            db.Managers.Add(item);
        }

        public IQueryable<Manager> GetAll()
        {
            return db.Managers;
        }

        public Manager Get(int id)
        {
            return db.Managers.Find(id);
        }

        public void Remove(int id)
        {
            var manager = db.Managers.Find(id);

            if (manager != null)
                db.Managers.Remove(manager);
        }

        public void Update(Manager item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /* public void Save()
         {
             db.SaveChanges();
         }*/

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
