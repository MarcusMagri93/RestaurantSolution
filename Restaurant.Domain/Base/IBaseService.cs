using FluentValidation;
using Restaurant.Domain.Base;
using System.Collections.Generic;

namespace Restaurant.Domain.Base
{
    // A interface define o contrato genérico para todos os serviços.
    public interface IBaseService<TEntity> where TEntity : IBaseEntity
    {
        // CRUD Genérico (usando Generics para DTOs e Validators)
        TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>;

        TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>;

        void Delete(int id);

        // Consultas Genéricas
        TOutputModel GetById<TOutputModel>(int id, bool tracking = true, IList<string>? includes = null) where TOutputModel : class;
        IEnumerable<TOutputModel> Get<TOutputModel>(bool tracking = true, IList<string>? includes = null) where TOutputModel : class;

        // Métodos de Controle do Repositório (EF Core)
        void AttachObject(object obj);
    }
}