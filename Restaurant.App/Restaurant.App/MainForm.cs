using ReaLTaiizor.Forms; // Para manter o estilo Material
using Restaurant.App.Others;
using Restaurant.App.Register;
using System.Windows.Forms;

namespace Restaurant.App
{
    // O formulário principal deve herdar de MaterialForm
    public partial class MainForm : MaterialForm
    {
        // Injeção de dependência dos formulários filhos
        private readonly ProductForm _productForm;
        private readonly RegisterWaiterForm _registerWaiterForm;
        private readonly OrderForm _orderForm;

        // O MainForm recebe as instâncias dos Forms via DI
        public MainForm(
            ProductForm productForm,
            RegisterWaiterForm registerWaiterForm,
            OrderForm orderForm)
        {
            InitializeComponent();
            _productForm = productForm;
            _registerWaiterForm = registerWaiterForm;
            _orderForm = orderForm;

            this.Text = "Sistema de Gestão de Restaurante";
        }

        // Exemplo de método para abrir o formulário de Produto
        private void MenuProduct_Click(object sender, System.EventArgs e)
        {
            _productForm.ShowDialog();
        }

        // Exemplo de método para abrir o formulário de Garçom
        private void MenuWaiter_Click(object sender, System.EventArgs e)
        {
            _registerWaiterForm.ShowDialog();
        }

        // Exemplo de método para abrir o formulário de Pedido
        private void MenuOrder_Click(object sender, System.EventArgs e)
        {
            _orderForm.ShowDialog();
        }
    }
}