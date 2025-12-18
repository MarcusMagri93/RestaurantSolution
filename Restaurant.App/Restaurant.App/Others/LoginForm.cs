using Restaurant.Domain.Entities;
using Restaurant.App.Register; 
using Restaurant.App.ViewModel; 
using ReaLTaiizor.Forms;
using System;
using System.Windows.Forms;
using System.Linq; 
using Restaurant.Domain.Base; 

namespace Restaurant.App.Others
{
    public partial class LoginForm : MaterialForm
    {
        private readonly RegisterWaiterForm _registerForm;
        private readonly IBaseService<Waiter> _waiterService;

        public LoginForm(RegisterWaiterForm registerForm, IBaseService<Waiter> waiterService)
        {
            InitializeComponent();
            _registerForm = registerForm; 
            _waiterService = waiterService; 
        }

        // Método Referente ao Botão Cadastrar
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Abre o formulário de 
            _registerForm.ShowDialog();

            // Limpa os campos 
            txtRegistration.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var registration = txtRegistration.Text;
            var password = txtPassword.Text;

            try
            {
                var waiter = _waiterService.Get<WaiterViewModel>()
                                          .FirstOrDefault(w => w.Registration == registration);

                // VALIDAÇÃO DE CREDENCIAIS:
                if (waiter != null && waiter.Password == password)
                {
                    MessageBox.Show($"Bem-vindo(a), {waiter.Name}!", "Login Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 'DialogResult.OK' informa ao Program.cs que o login deu certo e o MainForm pode ser aberto
                    this.DialogResult = DialogResult.OK;
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
    }
}