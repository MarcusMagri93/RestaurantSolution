using Restaurant.Domain.Entities;
using Restaurant.App.Register; // Para o RegisterWaiterForm
using Restaurant.App.ViewModel; // Para o WaiterViewModel (se usado no login)
using ReaLTaiizor.Forms;
using System;
using System.Windows.Forms;
using System.Linq;
using Restaurant.Domain.Base; // Para o IBaseService

namespace Restaurant.App.Others
{
    // O LoginForm precisa do formulário de cadastro e do serviço de garçom
    public partial class LoginForm : MaterialForm
    {
        private readonly RegisterWaiterForm _registerForm;
        private readonly IBaseService<Waiter> _waiterService;

        // Construtor: Injeta o formulário de cadastro (que será aberto) e o serviço de login
        public LoginForm(RegisterWaiterForm registerForm, IBaseService<Waiter> waiterService)
        {
            InitializeComponent();
            _registerForm = registerForm;
            _waiterService = waiterService;
        }

        // ------------------------------------------------------------------
        // IMPLEMENTAÇÃO FALTANTE PARA RESOLVER O ERRO DE COMPILAÇÃO
        // ------------------------------------------------------------------
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Abre o formulário de cadastro como um diálogo modal
            _registerForm.ShowDialog();

            // Opcional: Limpar os campos após o retorno
            txtRegistration.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        // ------------------------------------------------------------------
        // Lógica de Login (Implementação de LoginButton_Click)
        // ------------------------------------------------------------------
        private void LoginButton_Click(object sender, EventArgs e)
        {
            var registration = txtRegistration.Text;
            var password = txtPassword.Text;

            try
            {
                // Buscar o garçom pelo registro (usando o método Get do BaseService)
                // Usamos o ViewModel para buscar os dados de login
                var waiter = _waiterService.Get<WaiterViewModel>()
                                          .FirstOrDefault(w => w.Registration == registration);

                if (waiter != null && waiter.Password == password)
                {
                    MessageBox.Show($"Bem-vindo(a), {waiter.Name}!", "Login Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK; // Indica sucesso
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Registro ou senha inválidos.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro durante o login: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lembre-se de que o método LoginButton_Click deve ser o método que está 
        // ligado ao evento Click do seu btnLogin no Designer.
    }
}