
namespace DataAccessLayer.Repositories
{
    interface IExistable<TEntity>
    {
        bool Exists(TEntity item, out TEntity resultItem);
    }
}
