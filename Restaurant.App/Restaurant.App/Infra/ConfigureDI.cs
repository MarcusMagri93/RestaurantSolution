using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Restaurant.App.Others; // <--- IMPORTANTE: Namespace do novo form
using Restaurant.App.Register;
using Restaurant.App.ViewModel;
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
using System;
using System.IO;
using System.Linq;

namespace Restaurant.App.Infra
{
    public static class ConfigureDI
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            var dbConfigFile = "Config/DbConfig.txt";
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

            services.AddSingleton(
                new MapperConfiguration(config => {
                    config.CreateMap<Product, ProductViewModel>()
                          .ForMember(dest => dest.Type, opt => opt.MapFrom(src =>
                              src is Food ? "Comida" :
                              src is Drink ? "Bebida" : "Outro"))
                          .ReverseMap();

                    config.CreateMap<Food, ProductViewModel>().IncludeBase<Product, ProductViewModel>();
                    config.CreateMap<Drink, ProductViewModel>().IncludeBase<Product, ProductViewModel>();

                    config.CreateMap<Drink, DrinkViewModel>().ReverseMap();
                    config.CreateMap<Food, FoodViewModel>().ReverseMap();

                    config.CreateMap<Order, OrderViewModel>()
                          .ForMember(dest => dest.ProductsSummary, opt => opt.MapFrom(src =>
                              src.OrderItems != null && src.OrderItems.Any()
                              ? string.Join(", ", src.OrderItems.Select(i => $"{i.Product.Name} (x{i.Quantity})"))
                              : ""))
                          .ReverseMap();

                    config.CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
                    config.CreateMap<Waiter, WaiterViewModel>().ReverseMap();
                }).CreateMapper()
            );

            // Views
            services.AddSingleton<MainForm>();
            services.AddTransient<LoginForm>();
            services.AddTransient<RegisterWaiterForm>();
            services.AddTransient<ProductForm>();
            services.AddTransient<OrderForm>();
            services.AddTransient<TableMonitorForm>(); // <--- NOVO REGISTRO

            return services;
        }
    }
}