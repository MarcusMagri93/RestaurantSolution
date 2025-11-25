using Restaurant.Domain.Entities;
using System.Collections.Generic;

namespace Restaurant.Domain.Interfaces
{
    // Esta interface define os casos de uso para a entidade Product
    public interface IProductService
    {
        void Insert(Product product);
        void Update(Product product);
        void Delete(int id);
        Product GetById(int id);
        IList<Product> GetAll();
    }
}