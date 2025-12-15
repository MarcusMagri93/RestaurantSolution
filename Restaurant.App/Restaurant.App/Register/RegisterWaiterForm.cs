using System;
using System.Windows.Forms;
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

        // Injeção de dependência no construtor
        public RegisterWaiterForm(IBaseService<Waiter> waiterService)
        {
            InitializeComponent();
            _waiterService = waiterService;

            // Define a aba inicial como "Cadastro" na primeira carga
            this.tabControlCadastro.SelectedIndex = 0;
        }

        // --- SOLUÇÃO DO PROBLEMA DE TELA ---
        // Este método roda toda vez que a janela se torna visível (quando você clica no menu).
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            // Se a janela estiver abrindo (Visible = true)
            if (this.Visible)
            {
                // Força a aba de Cadastro (índice 0)
                this.tabControlCadastro.SelectedIndex = 0;

                // Limpa os campos de texto (Nome, Registro, Senha)
                LimpaCampos();

                // Reseta a flag de edição para garantir que seja um NOVO cadastro
                IsAlteracao = false;
            }
        }

        protected override void CarregaGrid()
        {
            // Carrega a lista de garçons para o DataGridView
            dataGridViewConsulta.DataSource = _waiterService.Get<WaiterViewModel>();
        }

        // Método para preencher a Entidade com dados do Formulário
        private void FormToObject(Waiter waiter)
        {
            // Capturando os campos do formulário
            waiter.Name = txtWaiterName.Text;
            waiter.Registration = txtRegistration.Text;
            waiter.Password = txtPassword.Text;
        }

        protected override void Salvar()
        {
            var waiter = new Waiter();
            FormToObject(waiter);

            // Se for alteração, o ID deve ser preenchido
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
                    MessageBox.Show("Garçom cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpaCampos();
                CarregaGrid();
                // Vai para a aba de consulta após salvar com sucesso
                tabControlCadastro.SelectedIndex = 1;
            }
            catch (ValidationException vex)
            {
                // Erros de validação (regras de negócio)
                var errors = string.Join("\n", vex.Errors);
                MessageBox.Show(errors, "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // TRATAMENTO DE DUPLICIDADE
                if (ex.InnerException != null && ex.InnerException.Message.Contains("Duplicate entry"))
                {
                    MessageBox.Show(
                        "Já existe um garçom cadastrado com este número de Registro.\nPor favor, escolha outro.",
                        "Registro Duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                else
                {
                    // Erro genérico
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
            }
        }

        protected override void CarregaRegistro(DataGridViewRow? linha)
        {
            if (linha != null)
            {
                // Preenche os campos para edição
                txtWaiterName.Text = linha.Cells["Name"].Value?.ToString();
                txtRegistration.Text = linha.Cells["Registration"].Value?.ToString();
                // A senha não é carregada por segurança
            }
        }
    }
}