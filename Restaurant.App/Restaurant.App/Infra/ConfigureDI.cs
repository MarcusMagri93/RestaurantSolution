using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Interfaces.Base;
using Restaurant.Repository.Context;
using Restaurant.Repository.Repositories;
using Restaurant.Repository.Repositories.Base;
using Restaurant.Services.Services;
using Restaurant.Services.Services.Base;
using Restaurant.Services.Validators;
using Restaurant.App.ViewModel;
using System.IO;
using System;
using System.Linq; // Necessário para o Select

namespace Restaurant.App.Infra
{
    public static class ConfigureDI
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            var dbConfigFile = "Config/DbConfig.txt";
            // Verifica se arquivo existe para evitar crash em tempo de design/execução inicial
            var strCon = File.Exists(dbConfigFile) ? File.ReadAllText(dbConfigFile) : "";

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddDbContext<RestaurantDbContext>(
                options =>
                {
                    options.LogTo(Console.WriteLine);
                    if (!string.IsNullOrEmpty(strCon))
                        options.UseMySQL(strCon);
                }
            );

            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<AbstractValidator<Food>, FoodValidator>();
            services.AddScoped<AbstractValidator<Waiter>, WaiterValidator>();
            services.AddScoped<AbstractValidator<Order>, OrderValidator>();
            services.AddScoped<AbstractValidator<Drink>, DrinkValidator>();

            // Configuração do AutoMapper com as melhorias
            services.AddSingleton(
                new MapperConfiguration(
                    config => {
                        // Mapeamento Etapa 1: Define o 'Type' baseado na classe
                        config.CreateMap<Product, ProductViewModel>()
                              .ForMember(dest => dest.Type, opt => opt.MapFrom(src =>
                                  src is Food ? "Comida" :
                                  src is Drink ? "Bebida" : "Outro"))
                              .ReverseMap();

                        config.CreateMap<Drink, DrinkViewModel>().ReverseMap();
                        config.CreateMap<Food, FoodViewModel>().ReverseMap();

                        // Mapeamento Etapa 2: Cria o resumo de produtos para a grade
                        config.CreateMap<Order, OrderViewModel>()
                              .ForMember(dest => dest.ProductsSummary, opt => opt.MapFrom(src =>
                                  src.OrderItems != null
                                  ? string.Join(", ", src.OrderItems.Select(i => $"{i.Product.Name} (x{i.Quantity})"))
                                  : string.Empty))
                              .ReverseMap();

                        config.CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
                        config.CreateMap<Waiter, WaiterViewModel>().ReverseMap();
                    },
                    NullLoggerFactory.Instance).CreateMapper()
                );

            return services;
        }
    }
}