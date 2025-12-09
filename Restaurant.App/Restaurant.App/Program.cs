using Microsoft.Extensions.DependencyInjection;
using Restaurant.App.Infra; // Onde ConfigureDI está
using Restaurant.App.Others;
using Restaurant.App.Register;
using System;
using System.Windows.Forms;

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
            // Adiciona serviços de DI do projeto (Entities, Services, Repositories, etc.)
            services.ConfigureDI();

            // Registra Formulários (Views) - DI

            // Singleton: O formulário principal deve ser Singleton, pois só existe uma instância dele
            services.AddSingleton<MainForm>();

            // Transient: Formulários que podem ser abertos várias vezes (ou um de cada vez)
            services.AddTransient<LoginForm>();
            services.AddTransient<RegisterWaiterForm>();
            services.AddTransient<ProductForm>();
            services.AddTransient<OrderForm>();

            // OBS: Adicione aqui qualquer outro formulário ou serviço que você precise registrar
        }
    }
}