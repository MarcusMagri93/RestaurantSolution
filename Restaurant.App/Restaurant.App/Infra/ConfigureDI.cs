using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Domain.Base;
using Restaurant.Repository.Context;
using Restaurant.Repository.Repositories;
// REMOVEMOS: using Restaurant.Service.Interfaces; // Isso causava o erro CS0234
using Restaurant.Service.Services;
using Restaurant.Domain.Interfaces;// <-- ESTE USING BASTA para Interfaces e Classes
using AutoMapper;
using System;
using System.Linq;

namespace Restaurant.App.Infra
{
    internal static class ConfigureDI
    {
        public static ServiceProvider serviceProvider = default!;

        public static void ConfigureServices()
        {
            var services = new ServiceCollection();
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=RestaurantDB;Trusted_Connection=True;MultipleActiveResultSets=true";

            // 1. Configuração do DbContext
            services.AddDbContext<RestaurantDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            // Adiciona o Formulário Principal (Form1) ao DI
            services.AddScoped<Form1>();

            // 2. Registro do AutoMapper
            services.AddAutoMapper(typeof(ProductService).Assembly);

            // 3. Registro do Repositório Genérico
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // 4. Registro dos Serviços Específicos: IOrderService e IProductService
            // O compilador agora encontra IProductService e ProductService no mesmo using (Services)
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();

            serviceProvider = services.BuildServiceProvider();
        }
    }
}