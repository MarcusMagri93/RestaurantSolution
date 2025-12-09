using System;
using System.Windows.Forms;
using Restaurant.App.Base;
using Restaurant.App.ViewModel;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Services.Validators; // Mantendo o namespace que você está usando

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
        }

        // Implementação dos métodos virtuais do BaseForm

        protected override void CarregaGrid()
        {
            // Carrega a lista de garçons para o DataGridView
            dataGridViewConsulta.DataSource = _waiterService.Get<WaiterViewModel>();
        }

        protected override void Salvar()
        {
            // CORREÇÃO 1: Usando Registration (e não RegistrationNumber)
            // CORREÇÃO 2: Removendo IsActive (propriedade que não existe na sua entidade)
            var newWaiter = new Waiter()
            {
                Name = txtWaiterName.Text,
                Registration = txtRegistration.Text // CORRIGIDO: Usando 'Registration'
                // IsActive não existe, foi removido
            };

            try
            {
                if (IsAlteracao)
                {
                    // Lógica para obter o Id do registro selecionado se estiver em alteração
                    // newWaiter.Id = (int)dataGridViewConsulta.SelectedRows[0].Cells["Id"].Value;
                    _waiterService.Update<Waiter, WaiterViewModel, WaiterValidator>(newWaiter);
                    MessageBox.Show("Garçom alterado com sucesso!");
                }
                else
                {
                    _waiterService.Add<Waiter, WaiterViewModel, WaiterValidator>(newWaiter);
                    MessageBox.Show("Garçom cadastrado com sucesso!");
                }

                LimpaCampos();
                CarregaGrid();
                tabControlCadastro.SelectedIndex = 1; // Volta para a aba de consulta
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar garçom: {ex.Message}");
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
                MessageBox.Show($"Erro ao excluir garçom: {ex.Message}");
            }
        }

        protected override void CarregaRegistro(DataGridViewRow? linha)
        {
            if (linha != null)
            {
                // CORREÇÃO: Usando Registration
                txtWaiterName.Text = linha.Cells["Name"].Value?.ToString();
                txtRegistration.Text = linha.Cells["Registration"].Value?.ToString(); // CORRIGIDO: Usando 'Registration'
            }
        }
    }
}