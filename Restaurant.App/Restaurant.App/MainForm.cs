using ReaLTaiizor.Forms; // Para manter o estilo Material
using Restaurant.App.Others;
using Restaurant.App.Register;
using System.Windows.Forms;

namespace Restaurant.App
{
    public partial class MainForm : MaterialForm
    {
        private readonly ProductForm _productForm;
        private readonly RegisterWaiterForm _registerWaiterForm;
        private readonly OrderForm _orderForm;

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

        // Abre para CADASTRO (Aba 0)
        private void MenuProduct_Click(object sender, System.EventArgs e)
        {
            _productForm.TabIndexInicial = 0; // Define aba de Cadastro
            _productForm.ShowDialog();
        }

        // NOVO: Abre para LISTAGEM (Aba 1)
        private void MenuListProducts_Click(object sender, System.EventArgs e)
        {
            _productForm.TabIndexInicial = 1; // Define aba de Consulta
            _productForm.ShowDialog();
        }

        private void MenuWaiter_Click(object sender, System.EventArgs e)
        {
            _registerWaiterForm.ShowDialog();
        }

        private void MenuOrder_Click(object sender, System.EventArgs e)
        {
            _orderForm.ShowDialog();
        }
    }
}