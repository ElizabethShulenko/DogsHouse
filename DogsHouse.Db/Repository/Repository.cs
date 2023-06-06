using DogsHouse.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DogsHouse.Db.Repository
{

    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DogsHouseDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(string connectionString)
        {
            _context = new DogsHouseDbContext(connectionString);
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
