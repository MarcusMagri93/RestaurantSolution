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

            // Força a aba de Cadastro a ser exibida
            this.tabControlCadastro.SelectedIndex = 0;
        }

        protected override void CarregaGrid()
        {
            dataGridViewConsulta.DataSource = _waiterService.Get<WaiterViewModel>();
        }

        // NOVO: Método para preencher a Entidade com dados do Formulário
        private void FormToObject(Waiter waiter)
        {
            // Capturando os campos do formulário (que são protected)
            waiter.Name = txtWaiterName.Text;
            waiter.Registration = txtRegistration.Text;
            waiter.Password = txtPassword.Text;

            // Outras propriedades obrigatórias da entidade, se houver:
            // waiter.CreatedAt = DateTime.Now; 
        }

        protected override void Salvar()
        {
            var waiter = new Waiter();
            FormToObject(waiter);

            // Se for alteração, o ID deve ser preenchido:
            if (IsAlteracao && dataGridViewConsulta.SelectedRows.Count > 0)
            {
                var selectedId = (int)dataGridViewConsulta.SelectedRows[0].Cells["Id"].Value;
                waiter.Id = selectedId;
            }

            try
            {
                if (IsAlteracao)
                {
                    // Chamada ALTERADA: Passa a Entidade (Waiter) em vez do InputModel
                    // Isso desabilita o AutoMapper, mas ativará o Validador.
                    _waiterService.Update<Waiter, WaiterViewModel, WaiterValidator>(waiter);
                    MessageBox.Show("Garçom alterado com sucesso!");
                }
                else
                {
                    // Chamada ALTERADA: Passa a Entidade (Waiter) em vez do InputModel
                    // Isso desabilita o AutoMapper, mas ativará o Validador.
                    _waiterService.Add<Waiter, WaiterViewModel, WaiterValidator>(waiter);
                    MessageBox.Show("Garçom cadastrado com sucesso!");
                }

                LimpaCampos();
                CarregaGrid();
                tabControlCadastro.SelectedIndex = 1;
            }
            // Captura de Validação (O método Add/Update do BaseService lança ValidationException)
            catch (ValidationException vex)
            {
                var errors = string.Join("\n", vex.Errors);
                MessageBox.Show(errors, "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Este catch capturará o erro de persistência ("Could not save changes...")
                MessageBox.Show($"Erro ao salvar garçom: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Deletar(int id)
        {
            try
            {
                _waiterService.Delete(id);
                MessageBox.Show("Garçom excluído com sucesso!");
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
                // Carrega os dados da linha selecionada para os campos
                txtWaiterName.Text = linha.Cells["Name"].Value?.ToString();
                txtRegistration.Text = linha.Cells["Registration"].Value?.ToString();
                // A senha nunca é carregada na ViewModel/Formulário por segurança
            }
        }
    }
}