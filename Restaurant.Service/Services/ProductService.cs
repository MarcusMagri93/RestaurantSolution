// Restaurant.Service/Services/ProductService.cs
using AutoMapper;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Services.Services
{
    public class ProductService : BaseService<Product>, IProductService // <-- Adicione ', IProductService'
    {
        public ProductService(IBaseRepository<Product> baseRepository, IMapper mapper)
            : base(baseRepository, mapper)
        {
        }

        // Métodos IProductService (CRUD)
        public void Delete(int id) => base._baseRepository.Delete(id);
        public IList<Product> GetAll() => base._baseRepository.Select(tracking: false);
        public Product GetById(int id) => base._baseRepository.Select(id);
        public void Insert(Product product) => base._baseRepository.Insert(product);
        public void Update(Product product) => base._baseRepository.Update(product);
    }
}