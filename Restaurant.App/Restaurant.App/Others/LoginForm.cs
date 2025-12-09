using System;
using System.Linq;
using System.Windows.Forms;
using ReaLTaiizor.Forms; // Para usar MaterialForm
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.App.ViewModel;

namespace Restaurant.App.Others
{
    // O LoginForm herda diretamente de MaterialForm ou Form, não de BaseForm
    public partial class LoginForm : MaterialForm
    {
        private readonly IBaseService<Waiter> _waiterService;

        // Injeção de dependência
        public LoginForm(IBaseService<Waiter> waiterService)
        {
            InitializeComponent();
            _waiterService = waiterService;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Assumindo que o WaiterViewModel tem uma propriedade Password
            var waiter = _waiterService.Get<WaiterViewModel>().FirstOrDefault(
                // Usa a propriedade corrigida 'Registration'
                w => w.Registration == txtRegistration.Text && w.Password == txtPassword.Text);

            if (waiter != null)
            {
                // Se você tiver uma classe de sessão (como UserSession no Bookly), use-a aqui.
                // UserSession.CurrentUser = waiter;
                MessageBox.Show($"Bem-vindo(a), {waiter.Name}!", "Login OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Registro ou senha inválidos.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}