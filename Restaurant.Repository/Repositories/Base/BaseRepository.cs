using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Base;
using Restaurant.Repository.Context;
using System;
using System.Linq;

namespace Restaurant.Repository.Repositories.Base
{
    // A implementação do Repositório Genérico com tratamento de "Estado Limpo"
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
            }
            catch (Exception)
            {
                // A MÁGICA ESTÁ AQUI:
                // Se der erro (ex: duplicado), removemos esse objeto da memória do EF.
                // Assim, na próxima tentativa, ele não atrapalha.
                _context.Entry(obj).State = EntityState.Detached;

                // Re-lançamos o erro para que o formulário mostre a mensagem (como já configuramos)
                throw;
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                // Desanexa qualquer entidade local que possa conflitar com a atualização
                var local = _dbSet.Local.FirstOrDefault(entry => entry.Id.Equals(obj.Id));
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _dbSet.Update(obj);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                // Se falhar, limpa o estado também
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