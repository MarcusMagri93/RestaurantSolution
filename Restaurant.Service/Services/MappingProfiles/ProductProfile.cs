using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurant.App.ViewModels; // Garanta que este using exista

namespace Restaurant.Service.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Mapeamento de Entidade -> ViewModel
            CreateMap<Product, ProductModel>();

            // Mapeamento de ViewModel -> Entidade
            CreateMap<ProductModel, Product>();

            // Mapeamento para as classes derivadas (TPH)
            CreateMap<Food, ProductModel>();
            CreateMap<Drink, ProductModel>();
        }
    }
}