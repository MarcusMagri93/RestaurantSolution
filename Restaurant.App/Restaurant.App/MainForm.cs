using ReaLTaiizor.Forms;
using Restaurant.App.Others;
using Restaurant.App.Register;
using Microsoft.Extensions.DependencyInjection; // Necessário para criar escopos
using System;
using System.Windows.Forms;

namespace Restaurant.App
{
    public partial class MainForm : MaterialForm
    {
        // Em vez de guardar os formulários velhos, guardamos a "fábrica" de serviços
        private readonly IServiceProvider _serviceProvider;

        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            this.Text = "Sistema de Gestão de Restaurante";
        }

        // Método genérico para abrir qualquer formulário com dados frescos
        private void OpenForm<T>(Action<T>? configure = null) where T : Form
        {
            // Cria um "Escopo" novo. Tudo criado aqui (DbContext, Services, Forms) é novo.
            using (var scope = _serviceProvider.CreateScope())
            {
                var form = scope.ServiceProvider.GetRequiredService<T>();

                // Configura propriedades opcionais (ex: TabIndexInicial)
                configure?.Invoke(form);

                form.ShowDialog();
            } // Ao sair daqui, o DbContext e o Form são descartados corretamente.
        }

        private void MenuProduct_Click(object sender, EventArgs e)
        {
            OpenForm<ProductForm>(f => f.TabIndexInicial = 0);
        }

        private void MenuListProducts_Click(object sender, EventArgs e)
        {
            OpenForm<ProductForm>(f => f.TabIndexInicial = 1);
        }

        private void MenuWaiter_Click(object sender, EventArgs e)
        {
            OpenForm<RegisterWaiterForm>();
        }

        private void MenuOrder_Click(object sender, EventArgs e)
        {
            OpenForm<OrderForm>();
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            OpenForm<TableMonitorForm>();
        }
    }
}