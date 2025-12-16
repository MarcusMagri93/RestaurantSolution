using System;
using System.Windows.Forms;
using System.Linq; // Necessário para calcular o Max()
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

                // Gera o número automaticamente ao abrir a tela
                GerarProximoRegistro();
            }
        }

        // --- NOVA LÓGICA: AUTO-INCREMENTO DO CAMPO REGISTRO ---
        private void GerarProximoRegistro()
        {
            try
            {
                var waiters = _waiterService.Get<WaiterViewModel>();
                int proximoRegistro = 1; // Padrão se não houver ninguém

                if (waiters != null && waiters.Any())
                {
                    // Tenta converter os registros existentes para número e pega o maior
                    int maxRegistro = waiters
                        .Select(w => int.TryParse(w.Registration, out int n) ? n : 0)
                        .DefaultIfEmpty(0)
                        .Max();

                    proximoRegistro = maxRegistro + 1;
                }

                txtRegistration.Text = proximoRegistro.ToString();
                txtRegistration.Enabled = false; // Bloqueia para o usuário não mudar
            }
            catch
            {
                // Fallback de segurança
                txtRegistration.Text = "1";
            }
        }

        protected override void Novo()
        {
            base.Novo();
            // Ao clicar no botão Novo, gera o próximo número
            GerarProximoRegistro();
        }

        protected override void CarregaGrid()
        {
            dataGridViewConsulta.DataSource = _waiterService.Get<WaiterViewModel>();
        }

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
                    MessageBox.Show($"Garçom cadastrado com sucesso!\nRegistro Gerado: {waiter.Registration}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpaCampos();
                CarregaGrid();

                // Gera o próximo número para o próximo cadastro imediato
                GerarProximoRegistro();
            }
            catch (ValidationException vex)
            {
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