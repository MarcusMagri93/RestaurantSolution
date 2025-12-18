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

            // Configurar Serviços
            var services = new ServiceCollection();
            ConfigureServices(services);

            // Construir o Provedor de Serviços 
            var serviceProvider = services.BuildServiceProvider();

            // Obter o Formulário de Login 
            var loginForm = serviceProvider.GetRequiredService<LoginForm>();

            // Executar o Login
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Se o login for bem-sucedido, rodar MainForm
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureApplicationServices();

            services.AddSingleton<MainForm>();

            services.AddTransient<LoginForm>();
            services.AddTransient<RegisterWaiterForm>();
            services.AddTransient<ProductForm>();
            services.AddTransient<OrderForm>();
        }
    }
}