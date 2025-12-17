using Microsoft.Extensions.DependencyInjection;
using Restaurant.App.Infra;
using System;
using System.Windows.Forms;
using Restaurant.App.Others;
using Restaurant.App.Register;

namespace Restaurant.App
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Configurar Serviços
            var services = new ServiceCollection();
            ConfigureServices(services);

            // 2. Construir o Provedor de Serviços (Service Provider)
            var serviceProvider = services.BuildServiceProvider();

            // 3. Obter o Formulário de Login (Transient)
            var loginForm = serviceProvider.GetRequiredService<LoginForm>();

            // 4. Executar o Login
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // 5. Se o login for bem-sucedido, obter e rodar o MainForm (Singleton)
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            //Chamando o novo nome do método de extensão
            services.ConfigureApplicationServices();


            // Singleton: O formulário principal (Menu)
            services.AddSingleton<MainForm>();

            // Transient: Formulários de CRUD e Login
            services.AddTransient<LoginForm>();
            services.AddTransient<RegisterWaiterForm>();
            services.AddTransient<ProductForm>();
            services.AddTransient<OrderForm>();
        }
    }
}