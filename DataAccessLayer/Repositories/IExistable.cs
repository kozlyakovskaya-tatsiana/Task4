using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    interface IExistable<TEntity>
    {
        bool Exists(TEntity item, out TEntity resultItem);
    }
}
