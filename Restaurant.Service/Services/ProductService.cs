using AutoMapper;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Interfaces.Base;
using Restaurant.Services.Services;
using Restaurant.Services.Services.Base;

namespace Restaurant.Services.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IBaseRepository<Product> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

    }
}