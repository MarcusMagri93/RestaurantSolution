using System;

namespace Restaurant.Domain.Base
{
    // Classe Abstrata com Generics <TID> para o Id, mas implementando a IBaseEntity sem Generics.
    public abstract class BaseEntity<TID> : IBaseEntity
    {
        // Propriedade Id com tipo genérico.
        public TID Id { get; set; } = default!;

        // Construtor sem Id (para o Entity Framework ou criação de novo objeto)
        protected BaseEntity()
        {
        }

        // Construtor com Id (para carregamento ou testes)
        protected BaseEntity(TID id)
        {
            Id = id;
        }
    }
}