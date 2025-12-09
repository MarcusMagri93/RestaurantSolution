using AutoMapper;
using FluentValidation;
using Restaurant.Domain.Base; // NOVO: Referencia o IBaseService e IBaseRepository
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Services.Services.Base
{
    // A implementação DEVE ter a restrição WHERE para satisfazer a injeção do IBaseRepository
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : BaseEntity<int> // <--- RESTRIÇÃO ESSENCIAL
    {
        // Nota: IBaseRepository está no namespace Restaurant.Domain.Base
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        // O construtor injeta o Repositório e o AutoMapper
        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // ... (Implementação dos métodos CRUD, Get, Update, Delete)

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

        // ... (Implementação completa do CRUD como fornecido anteriormente)
        // [Os outros métodos devem ser copiados da versão anterior do BaseService.cs que te forneci]

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