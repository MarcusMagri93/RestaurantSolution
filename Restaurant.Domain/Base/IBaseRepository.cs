using System.Linq;
using Restaurant.Domain.Base; 


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