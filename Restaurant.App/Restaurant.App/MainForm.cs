using ReaLTaiizor.Forms;
using Restaurant.App.Others;
using Restaurant.App.Register;
using Microsoft.Extensions.DependencyInjection; 

namespace Restaurant.App
{
    public partial class MainForm : MaterialForm
    {
        private readonly IServiceProvider _serviceProvider;

        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            this.Text = "Sistema de Gestão de Restaurante";
        }

        // Abre qualquer Fomr
        private void OpenForm<T>(Action<T>? configure = null) where T : Form
        {
            // Create Scope garante que o banco e os serviços usados sejam fechados junto com a janela 
            using (var scope = _serviceProvider.CreateScope())
            {
                // Busca o formulário solicitado
                var form = scope.ServiceProvider.GetRequiredService<T>();

                configure?.Invoke(form);

                form.ShowDialog();
            }
        }


        private void MenuProduct_Click(object sender, EventArgs e)
        {
            // Abre na aba cadastro (0)
            OpenForm<ProductForm>(f => f.TabIndexInicial = 0);
        }

        private void MenuListProducts_Click(object sender, EventArgs e)
        {
            // Abre na aba consulta (1)
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