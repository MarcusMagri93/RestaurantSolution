using System;

namespace Restaurant.Domain.Base
{
    public abstract class BaseEntity<TID> : IBaseEntity
    {
        // Propriedade Id com tipo genérico
        public TID Id { get; set; } = default!;

        // Construtor sem Id (criação de novo objeto)
        protected BaseEntity()
        {
        }

        // Construtor com Id (carregamento ou testes)
        protected BaseEntity(TID id)
        {
            Id = id;
        }
    }
}