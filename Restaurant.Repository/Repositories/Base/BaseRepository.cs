using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Base;
using Restaurant.Repository.Context;
using System;
using System.Linq;

namespace Restaurant.Repository.Repositories.Base
{
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
            try
            {
                _dbSet.Add(obj);
                _context.SaveChanges();
                // CORREÇÃO: Remove o objeto da memória após salvar para evitar conflitos
                _context.Entry(obj).State = EntityState.Detached;
            }
            catch (Exception)
            {
                _context.Entry(obj).State = EntityState.Detached;
                throw;
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                var local = _dbSet.Local.FirstOrDefault(entry => entry.Id.Equals(obj.Id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _dbSet.Update(obj);
                _context.SaveChanges();
                // CORREÇÃO: Remove o objeto da memória após atualizar
                _context.Entry(obj).State = EntityState.Detached;
            }
            catch (Exception)
            {
                _context.Entry(obj).State = EntityState.Detached;
                throw;
            }
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                try
                {
                    _dbSet.Remove(entity);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    _context.Entry(entity).State = EntityState.Unchanged;
                    throw;
                }
            }
        }

        public IQueryable<TEntity> Get()
        {
            return _dbSet.AsNoTracking();
        }

        public TEntity GetById(int id)
        {
            var entity = _dbSet.Find(id);

            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }
    }
}