using AutoMapper;
using FluentValidation; // NECESSÁRIO para registrar Validadores
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Interfaces.Base; // NECESSÁRIO para IBaseService, IOrderService, IProductService
using Restaurant.Repository.Context;
using Restaurant.Repository.Repositories;
using Restaurant.Repository.Repositories.Base;
using Restaurant.Services.Services;
using Restaurant.Services.Services.Base;
using Restaurant.Services.Validators; // NECESSÁRIO para encontrar os Validadores
using Restaurant.App.ViewModel;
using System.IO;
using System;

namespace Restaurant.App.Infra
{
    public static class ConfigureDI
    {
        // CORREÇÃO 1: O método foi renomeado para evitar conflito de nomes
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            // data base config (Mantendo a lógica de leitura do seu arquivo)
            var dbConfigFile = "Config/DbConfig.txt";
            var strCon = File.ReadAllText(dbConfigFile);

            // Adicionado IBaseRepository/BaseRepository usando typeof para o genérico
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddDbContext<RestaurantDbContext>(
                options =>
                {
                    options.LogTo(Console.WriteLine);
                    options.UseMySQL(strCon);
                }
            );

            // ----------------------------------------------------
            // 1. REPOSITÓRIOS (Genéricos)
            // ----------------------------------------------------
            // services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>)); // Já registrado acima

            // ----------------------------------------------------
            // 2. SERVICES (Genéricos e Específicos)
            // ----------------------------------------------------
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            // CORREÇÃO 3: Os tipos agora devem ser reconhecidos (usando Restaurant.Domain.Interfaces.Base;)
            // E Service/Implementation estão em Restaurant.Domain.Interfaces.Base/Restaurant.Services.Services
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>(); // Inclusão do ProductService (que precisa do IProductService)

            // ----------------------------------------------------
            // 3. VALIDATORS (Agora registrado com a classe base AbstractValidator<TEntity>)
            // ----------------------------------------------------
            services.AddScoped<AbstractValidator<Food>, FoodValidator>();
            services.AddScoped<AbstractValidator<Waiter>, WaiterValidator>();
            services.AddScoped<AbstractValidator<Order>, OrderValidator>();
            // Adicione os validadores para Drink e Product/Food aqui, se necessário.

            // ----------------------------------------------------
            // 4. AUTOMAPPER
            // ----------------------------------------------------
            services.AddSingleton(
                new MapperConfiguration(
                    config => {
                        config.CreateMap<Product, ProductViewModel>().ReverseMap();
                        config.CreateMap<Drink, DrinkViewModel>().ReverseMap();
                        config.CreateMap<Food, FoodViewModel>().ReverseMap();
                        config.CreateMap<Order, OrderViewModel>().ReverseMap();
                        config.CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
                        config.CreateMap<Waiter, WaiterViewModel>().ReverseMap();
                    },
                    NullLoggerFactory.Instance).CreateMapper()
                );

            return services;
        }
    }
}