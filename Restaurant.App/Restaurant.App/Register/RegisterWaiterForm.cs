using Restaurant.App.Base;
using Restaurant.App.ViewModel;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Services.Validators;
using FluentValidation;

namespace Restaurant.App.Register
{
    public partial class RegisterWaiterForm : BaseForm
    {
        private readonly IBaseService<Waiter> _waiterService;

        public RegisterWaiterForm(IBaseService<Waiter> waiterService)
        {
            InitializeComponent();
            _waiterService = waiterService;

            this.tabControlCadastro.SelectedIndex = 0;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                this.tabControlCadastro.SelectedIndex = 0;
                LimpaCampos();
                IsAlteracao = false;

                GerarProximoRegistro();
            }
        }

        // LÓGICA DE AUTO-INCREMENTO 
        private void GerarProximoRegistro()
        {
            try
            {
                // Busca todos os garçons 
                var waiters = _waiterService.Get<WaiterViewModel>();
                int proximoRegistro = 1; // Valor inicial padrão

                if (waiters != null && waiters.Any())
                {
                    // LINQ: 
                    // Select: conversão de string para int 
                    // DefaultIfEmpty(0): assume 0 se estiver vazia 
                    // Max(): maior número de registro
                    int maxRegistro = waiters
                        .Select(w => int.TryParse(w.Registration, out int n) ? n : 0)
                        .DefaultIfEmpty(0)
                        .Max();

                    proximoRegistro = maxRegistro + 1;
                }

                txtRegistration.Text = proximoRegistro.ToString();
                txtRegistration.Enabled = false; 
            }
            catch
            {
                // Se falhar, será 1
                txtRegistration.Text = "1";
            }
        }

        protected override void Novo()
        {
            base.Novo();
            GerarProximoRegistro();
        }

        protected override void CarregaGrid()
        {
            dataGridViewConsulta.DataSource = _waiterService.Get<WaiterViewModel>();
        }

        // transfere os dados da tela para obj no banco 
        private void FormToObject(Waiter waiter)
        {
            waiter.Name = txtWaiterName.Text;
            waiter.Registration = txtRegistration.Text;
            waiter.Password = txtPassword.Text;
        }

        protected override void Salvar()
        {
            var waiter = new Waiter();
            FormToObject(waiter);

            if (IsAlteracao && dataGridViewConsulta.SelectedRows.Count > 0)
            {
                var selectedId = (int)dataGridViewConsulta.SelectedRows[0].Cells["Id"].Value;
                waiter.Id = selectedId;
            }

            try
            {
                if (IsAlteracao)
                {
                    _waiterService.Update<Waiter, WaiterViewModel, WaiterValidator>(waiter);
                    MessageBox.Show("Garçom alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _waiterService.Add<Waiter, WaiterViewModel, WaiterValidator>(waiter);
                    MessageBox.Show($"Garçom cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpaCampos();
                CarregaGrid();
                GerarProximoRegistro(); 
            }
            catch (ValidationException vex)
            {
                // Captura erros de preenchimento 
                var errors = string.Join("\n", vex.Errors);
                MessageBox.Show(errors, "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("Duplicate entry"))
                {
                    MessageBox.Show("O registro calculado já existe. O sistema tentará gerar um novo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    GerarProximoRegistro();
                }
                else
                {
                    MessageBox.Show($"Erro ao salvar garçom: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override void Deletar(int id)
        {
            try
            {
                _waiterService.Delete(id);
                MessageBox.Show("Garçom excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir garçom: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CarregaGrid();
                if (!IsAlteracao) GerarProximoRegistro();
            }
        }

        protected override void CarregaRegistro(DataGridViewRow? linha)
        {
            if (linha != null)
            {
                txtWaiterName.Text = linha.Cells["Name"].Value?.ToString();
                txtRegistration.Text = linha.Cells["Registration"].Value?.ToString();

                txtRegistration.Enabled = false;
            }
        }
    }
}