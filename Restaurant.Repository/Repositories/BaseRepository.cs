using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Base;
using Restaurant.Repository.Context; // Adicione este using
using System.Collections.Generic;
using System.Linq; // Necessário para IQueryable e ToList()

namespace Restaurant.Repository.Repositories
{
    // A classe implementa IBaseRepository e usa IBaseEntity como restrição
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IBaseEntity // Restrição IBaseEntity é necessária aqui
    {
        protected readonly RestaurantDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(RestaurantDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>(); // Inicializa o DbSet
        }

        // --- Implementações da Interface IBaseRepository ---

        // Deve ser PUBLIC
        public void AttachObject(object obj) => _context.Attach(obj);

        // Deve ser PUBLIC
        public void ClearChangeTracker() => _context.ChangeTracker.Clear();

        // Deve ser PUBLIC
        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        // Deve ser PUBLIC (Implementação básica de Update)
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        // Deve ser PUBLIC
        public void Delete(object id)
        {
            var entityToDelete = _dbSet.Find(id); // Usa Find
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
                _context.SaveChanges();
            }
        }

        // Deve ser PUBLIC (Seleção por ID)
        public TEntity Select(object id, bool tracking = true, IList<string>? includes = null)
        {
            // Nota: Se a sua IBaseRepository usar generics, você precisa garantir que o tipo seja int.
            // Aqui, usamos Find(id) que aceita o 'object id' do IBaseRepository.
            return _dbSet.Find(id);
        }

        // Deve ser PUBLIC (Seleção de todos)
        public IList<TEntity> Select(bool tracking = true, IList<string>? includes = null)
        {
            // Implementação para retornar todos
            IQueryable<TEntity> query = _dbSet;
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.ToList();
        }
    }
}