using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Repository.Context;
using Restaurant.Repository.Repositories.Base; // Adicionado para BaseRepository
using Restaurant.Services.Services;
using Restaurant.Services.Services.Base; // Adicionado para BaseService
using Restaurant.App.ViewModel;
using System.IO; // Para File
using System; // Para Console

namespace Restaurant.App.Infra
{
    // Classe de Extensão DEVE ser estática
    public static class ConfigureDI
    {
        // CORREÇÃO: Método de extensão! O nome deve ser ConfigureDI e deve ter 'this IServiceCollection services'
        public static IServiceCollection ConfigureDI(this IServiceCollection services)
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
                    // Aqui você pode precisar de um using para o driver MySQL (ex: MySql.EntityFrameworkCore)
                    options.UseMySQL(strCon);
                }
            );

            #region Repository
            // Registros de Repositórios (IBaseRepository)
            // Estes registros não são mais necessários se você usou services.AddScoped(typeof(IBaseRepository<>)...
            /*
            services.AddScoped<IBaseRepository<Product>, BaseRepository<Product>>();
            services.AddScoped<IBaseRepository<Drink>, BaseRepository<Drink>>();
            services.AddScoped<IBaseRepository<Food>, BaseRepository<Food>>();
            services.AddScoped<IBaseRepository<Order>, BaseRepository<Order>>();
            services.AddScoped<IBaseRepository<OrderItem>, BaseRepository<OrderItem>>();
            services.AddScoped<IBaseRepository<Waiter>, BaseRepository<Waiter>>();
            */
            #endregion

            #region Service
            // Serviços genéricos (IBaseService -> BaseService)
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            // Serviços Específicos
            services.AddScoped<IOrderService, OrderService>();
            // services.AddScoped<IProductService, ProductService>(); // Removido IProductService pois ele não existe no pattern original
            #endregion

            // Configuração do AutoMapper
            services.AddSingleton(
                new MapperConfiguration(
                    config => {
                        // Mapeamentos Entidade -> ViewModel
                        config.CreateMap<Product, ProductViewModel>().ReverseMap();
                        config.CreateMap<Drink, DrinkViewModel>().ReverseMap(); // Se DrinkViewModel existir
                        config.CreateMap<Food, FoodViewModel>().ReverseMap();   // Se FoodViewModel existir
                        config.CreateMap<Order, OrderViewModel>().ReverseMap();
                        config.CreateMap<OrderItem, OrderItemViewModel>().ReverseMap(); // Se OrderItemViewModel existir
                        config.CreateMap<Waiter, WaiterViewModel>().ReverseMap();

                    },
                    NullLoggerFactory.Instance).CreateMapper()
                );

            // Você precisará adicionar os registradores de Validadores FluentValidation aqui
            // services.AddScoped<IValidator<Food>, FoodValidator>(); etc.

            return services;
        }
    }
}