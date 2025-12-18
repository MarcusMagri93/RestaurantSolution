using FluentValidation;
using System.Collections.Generic;

namespace Restaurant.Domain.Base 
{
    public interface IBaseService<TEntity>
        where TEntity : BaseEntity<int> 
    {
        TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>;

        TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>;

        void Delete(int id);

        IList<TOutputModel> Get<TOutputModel>() where TOutputModel : class;
        TOutputModel GetById<TOutputModel>(int id) where TOutputModel : class;

        TEntity GetById(int id); 
    }
}