using AutoMapper;
using FluentValidation;
using Restaurant.Domain.Base;


namespace Restaurant.Services.Services.Base
{
    // Classe genérica 
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : BaseEntity<int>
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // ADD
        public TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            if (inputModel == null) throw new ArgumentNullException(nameof(inputModel));

            var entity = _mapper.Map<TEntity>(inputModel);

            var validator = Activator.CreateInstance<TValidator>();
            validator.ValidateAndThrow(entity);

            _repository.Add(entity);

            return _mapper.Map<TOutputModel>(entity);
        }

        public TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            if (inputModel == null) throw new ArgumentNullException(nameof(inputModel));

            var entity = _mapper.Map<TEntity>(inputModel);

            var validator = Activator.CreateInstance<TValidator>();
            validator.ValidateAndThrow(entity);

            _repository.Update(entity);
            return _mapper.Map<TOutputModel>(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        // Recupera todos os registros e já os converte para ViewModels automaticamente
        public IList<TOutputModel> Get<TOutputModel>() where TOutputModel : class
        {
            var entities = _repository.Get().ToList();
            return _mapper.Map<IList<TOutputModel>>(entities);
        }

        public TOutputModel GetById<TOutputModel>(int id) where TOutputModel : class
        {
            var entity = _repository.GetById(id);
            return _mapper.Map<TOutputModel>(entity);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}