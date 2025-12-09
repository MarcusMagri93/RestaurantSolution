using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Base;
//using Restaurant.Domain.Interfaces.Base;
using Restaurant.Repository.Context;
using System.Linq;

namespace Restaurant.Repository.Repositories.Base
{
    // A implementação do Repositório Genérico
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity<int>
    {
        protected readonly RestaurantDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(RestaurantDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            _dbSet.Add(obj);
            _context.SaveChanges(); // Simplificado para fins de compilação
        }

        public void Update(TEntity obj)
        {
            _dbSet.Update(obj);
            _context.SaveChanges(); // Simplificado para fins de compilação
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges(); // Simplificado para fins de compilação
            }
        }

        public IQueryable<TEntity> Get()
        {
            return _dbSet.AsQueryable();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }
    }
}