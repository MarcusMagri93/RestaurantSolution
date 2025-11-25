using Microsoft.Extensions.DependencyInjection;
using Restaurant.App.Infra; // Importa nossa classe de configuração
using System;
using System.Windows.Forms;

namespace Restaurant.App
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // CHAMA A CONFIGURAÇÃO DA ARQUITETURA
            ConfigureDI.ConfigureServices();

            // INICIA O FORMULÁRIO PRINCIPAL
            // Recupera o Form1.cs usando o ServiceProvider para injetar dependências (se Form1 precisar de IService)
            var formPrincipal = ConfigureDI.serviceProvider.GetRequiredService<Form1>();

            Application.Run(formPrincipal);
        }
    }
}