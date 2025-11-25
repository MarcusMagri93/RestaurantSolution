using AutoMapper;
using FluentValidation;
using Restaurant.Domain.Base;
 // Usaremos a IBaseRepository que está na Domain

namespace Restaurant.Service.Services
{
    // Implementa a interface genérica
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : IBaseEntity
    {
        // Injeção de Dependência dos Contratos
        protected readonly IBaseRepository<TEntity> _baseRepository;
        protected readonly IMapper _mapper;

        // Construtor que recebe as dependências (AutoMapper e Repositório)
        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        // Método de Attach (Controle do EF Core)
        public void AttachObject(object obj)
        {
            // Atenção: Usei AttachObject para corrigir o provável erro de digitação do professor
            // Se o método dele for AtachObjetct, use o nome dele.
            _baseRepository.AttachObject(obj);
        }

        // Método de Adição (CRUD)
        public TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            // 1. Mapeia InputModel (DTO) -> Entidade de Domínio
            var entity = _mapper.Map<TEntity>(inputModel);

            // 2. Valida a Entidade
            Validate(entity, Activator.CreateInstance<TValidator>());

            // 3. Insere no Banco de Dados
            _baseRepository.Insert(entity);

            // 4. Mapeia Entidade -> OutputModel (DTO) e retorna
            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }

        // Método de Deleção (CRUD)
        public void Delete(int id)
        {
            _baseRepository.Delete(id);
        }

        // Método de Consulta (Get All)
        public IEnumerable<TOutputModel> Get<TOutputModel>(bool tracking = true, IList<string>? includes = null) where TOutputModel : class
        {
            var entities = _baseRepository.Select(tracking, includes);
            var outputModel = entities.Select(s => _mapper.Map<TOutputModel>(s));
            return outputModel;
        }

        // Método de Consulta (Get By Id)
        public TOutputModel GetById<TOutputModel>(int id, bool tracking = true, IList<string>? includes = null) where TOutputModel : class
        {
            var entity = _baseRepository.Select(id, tracking, includes);
            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }

        // Método de Atualização (CRUD)
        public TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            var entity = _mapper.Map<TEntity>(inputModel);
            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(entity);
            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }

        // Método de Validação (Lógica Privada)
        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
            {
                throw new Exception("Objeto inválido!");
            }
            // Usa o FluentValidation para validar e lançar exceção automaticamente
            validator.ValidateAndThrow(obj);
        }
    }
}