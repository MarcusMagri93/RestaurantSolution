using System;
using System.Linq;
using System.Windows.Forms;
using Restaurant.App.Base;
using Restaurant.App.ViewModel;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Services.Validators;

namespace Restaurant.App.Register
{
    public partial class OrderForm : BaseForm
    {
        // Serviço genérico para CRUD de Pedidos (usado para Get, Add, Update, Delete)
        private readonly IBaseService<Order> _baseOrderService;

        // Serviço específico para Pedidos (mantido caso precise de lógica de negócio)
        private readonly IOrderService _orderService;

        // Serviço genérico para carregar Garçons
        private readonly IBaseService<Waiter> _waiterService;

        private int _currentOrderId;

        // Injeção de dependência DUAL (BaseService para CRUD + Serviço específico + WaiterService)
        public OrderForm(
            IBaseService<Order> baseOrderService,
            IOrderService orderService,
            IBaseService<Waiter> waiterService)
        {
            InitializeComponent();
            _baseOrderService = baseOrderService;
            _orderService = orderService;
            _waiterService = waiterService;

            CarregaWaiters();
        }

        // Método auxiliar para popular o ComboBox de Garçons
        private void CarregaWaiters()
        {
            var waiters = _waiterService.Get<WaiterViewModel>().ToList();
            // Assumindo que você tem um ComboBox chamado cmbWaiter no seu designer
            cmbWaiter.DataSource = waiters;
            cmbWaiter.DisplayMember = "Name";
            cmbWaiter.ValueMember = "Id";
        }

        protected override void CarregaGrid()
        {
            // Usa o serviço base para obter dados
            dataGridViewConsulta.DataSource = _baseOrderService.Get<OrderViewModel>();
        }

        protected override void Salvar()
        {
            var newOrder = new Order()
            {
                // Propriedades do cabeçalho
                TableNumber = int.Parse(txtTableNumber.Text),
                WaiterId = (int)cmbWaiter.SelectedValue,

                // TotalAmount agora existe na Entidade (após a correção)
                TotalAmount = 0,
                IsPaid = false
            };

            try
            {
                if (IsAlteracao)
                {
                    newOrder.Id = _currentOrderId;
                    // Usa o serviço base para Update
                    _baseOrderService.Update<Order, OrderViewModel, OrderValidator>(newOrder);
                    MessageBox.Show("Pedido alterado com sucesso!");
                }
                else
                {
                    // Usa o serviço base para Add
                    _baseOrderService.Add<Order, OrderViewModel, OrderValidator>(newOrder);
                    MessageBox.Show("Novo pedido criado com sucesso!");
                }

                LimpaCampos();
                CarregaGrid();
                tabControlCadastro.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar pedido: {ex.Message}");
            }
        }

        protected override void Deletar(int id)
        {
            try
            {
                // Usa o serviço base para Delete
                _baseOrderService.Delete(id);
                MessageBox.Show("Pedido excluído com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir pedido: {ex.Message}");
            }
        }

        protected override void CarregaRegistro(DataGridViewRow? linha)
        {
            if (linha != null)
            {
                _currentOrderId = (int)linha.Cells["Id"].Value;
                txtTableNumber.Text = linha.Cells["TableNumber"].Value?.ToString();

                int waiterId = (int)linha.Cells["WaiterId"].Value;
                cmbWaiter.SelectedValue = waiterId;
            }
        }
    }
}