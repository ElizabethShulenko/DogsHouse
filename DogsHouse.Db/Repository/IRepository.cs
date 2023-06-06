using DogsHouse.Db.Entities;

namespace DogsHouse.Db.Repository
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();
    }
}
