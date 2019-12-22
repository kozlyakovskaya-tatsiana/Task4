using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IRepository<TEntity> where TEntity:class
    {
        void Create(TEntity item);

        void Remove(TEntity item);

        void Update(TEntity item);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

        void Save();

    }
}
