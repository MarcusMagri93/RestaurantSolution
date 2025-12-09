using System.Linq;
using Restaurant.Domain.Base; // O namespace da sua entidade base

// Namespace CORRETO para o seu IBaseRepository
namespace Restaurant.Domain.Base
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity<int>
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(int id);

        IQueryable<TEntity> Get();
        TEntity GetById(int id);
    }
}