using System.Collections.Generic;

namespace Restaurant.Domain.Base
{
    // Generics: <TEntity> define que esta interface pode funcionar com qualquer Entidade.
    // where TEntity : IBaseEntity: Restrição para garantir que TEntity é uma classe de domínio.
    public interface IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        // Métodos de Controle do Entity Framework Core
        void ClearChangeTracker();
        void AttachObject(object obj); // Renomeei AtachObjectct para AttachObject (corrigindo um provável erro de digitação)

        // Métodos de Inserção, Atualização e Deleção (CRUD)
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);

        // Métodos de Seleção (Consulta)
        IList<TEntity> Select(bool tracking = true, IList<string>? includes = null);
        TEntity Select(object id, bool tracking = true, IList<string>? includes = null);
    }
}