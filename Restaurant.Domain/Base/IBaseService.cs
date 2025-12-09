using FluentValidation;
using System.Collections.Generic;

namespace Restaurant.Domain.Base // <-- Namespace confirmado pelo seu print
{
    // A interface IBaseService DEVE ter a mesma restrição de entidade
    public interface IBaseService<TEntity>
        where TEntity : BaseEntity<int> // <--- RESTRIÇÃO ESSENCIAL
    {
        // Métodos CRUD (usando ViewModels para entrada/saída)
        TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>;

        TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>;

        void Delete(int id);

        // Métodos de Consulta
        IList<TOutputModel> Get<TOutputModel>() where TOutputModel : class;
        TOutputModel GetById<TOutputModel>(int id) where TOutputModel : class;

        TEntity GetById(int id); // Para uso interno
    }
}