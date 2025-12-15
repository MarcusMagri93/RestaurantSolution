using System;
using System.Linq;
using System.Windows.Forms;
using Restaurant.Domain.Interfaces.Base;
using Restaurant.App.Base;
using Restaurant.App.ViewModel;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Services.Validators;
using FluentValidation;
using System.Collections.Generic;

namespace Restaurant.App.Register
{
    public partial class OrderForm : BaseForm
    {
        private readonly IBaseService<Order> _baseOrderService;
        private readonly IOrderService _orderService;
        private readonly IBaseService<Waiter> _waiterService;
        private readonly IBaseService<Product> _productService;

        private int _currentOrderId = 0;

        public OrderForm(
            IBaseService<Order> baseOrderService,
            IOrderService orderService,
            IBaseService<Waiter> waiterService,
            IBaseService<Product> productService)
        {
            InitializeComponent();
            _baseOrderService = baseOrderService;
            _orderService = orderService;
            _waiterService = waiterService;
            _productService = productService;

            // Define a aba inicial mas NÃO carrega os combos aqui (para corrigir o bug)
            this.tabControlCadastro.SelectedIndex = 0;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                // Carrega os combos TODA VEZ que a tela aparece.
                // Isso resolve o problema do produto novo não aparecer.
                CarregaCombos();

                this.tabControlCadastro.SelectedIndex = 0;
                LimpaCampos();
                _currentOrderId = 0;
                dgvOrderItems.DataSource = null;
                IsAlteracao = false;

                CarregaGrid(); // Atualiza a lista de consultas
            }
        }

        private void CarregaCombos()
        {
            // Carrega Garçons
            var waiters = _waiterService.Get<WaiterViewModel>().ToList();
            cmbWaiter.DataSource = waiters;
            cmbWaiter.DisplayMember = "Name";
            cmbWaiter.ValueMember = "Id";

            // Carrega Produtos (Sempre atualizado do banco)
            var products = _productService.Get<ProductViewModel>().ToList();
            cmbProduct.DataSource = products;
            cmbProduct.DisplayMember = "Name";
            cmbProduct.ValueMember = "Id";
        }

        protected override void CarregaGrid()
        {
            // Reseta a fonte de dados para forçar a criação da coluna "ProductsSummary"
            dataGridViewConsulta.DataSource = null;
            dataGridViewConsulta.AutoGenerateColumns = true;

            // Usa o método que traz os detalhes para preencher o resumo
            dataGridViewConsulta.DataSource = _orderService.GetAllWithDetails<OrderViewModel>();
            dataGridViewConsulta.Refresh();
        }

        private void CarregaItensPedido()
        {
            if (_currentOrderId == 0) return;

            try
            {
                var order = _orderService.GetOrder(_currentOrderId);
                if (order != null && order.OrderItems != null)
                {
                    var itensGrid = order.OrderItems.Select(i => new
                    {
                        Id = i.Id,
                        Produto = i.Product != null ? i.Product.Name : "Produto " + i.ProductId,
                        Qtd = i.Quantity,
                        Total = (i.Product?.Price ?? 0) * i.Quantity
                    }).ToList();

                    dgvOrderItems.DataSource = itensGrid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar itens: " + ex.Message);
            }
        }

        protected override void Salvar()
        {
            try
            {
                if (string.IsNullOrEmpty(txtTableNumber.Text))
                {
                    MessageBox.Show("Informe o número da mesa.");
                    return;
                }

                if (cmbWaiter.SelectedValue == null)
                {
                    MessageBox.Show("Selecione um garçom.");
                    return;
                }

                var order = new Order
                {
                    TableNumber = int.Parse(txtTableNumber.Text),
                    WaiterId = (int)cmbWaiter.SelectedValue,
                    IsPaid = false,
                    TotalAmount = 0
                };

                if (IsAlteracao && _currentOrderId > 0)
                {
                    order.Id = _currentOrderId;
                    _baseOrderService.Update<Order, OrderViewModel, OrderValidator>(order);
                    MessageBox.Show("Dados do pedido atualizados!");
                }
                else
                {
                    var savedOrder = _baseOrderService.Add<Order, OrderViewModel, OrderValidator>(order);
                    _currentOrderId = savedOrder.Id;
                    IsAlteracao = true;
                    MessageBox.Show($"Pedido #{savedOrder.Id} iniciado! Agora adicione os itens.");
                }

                CarregaGrid();
            }
            catch (ValidationException vex)
            {
                var errors = string.Join("\n", vex.Errors);
                MessageBox.Show(errors, "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar pedido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentOrderId == 0)
                {
                    if (string.IsNullOrEmpty(txtTableNumber.Text) || cmbWaiter.SelectedValue == null)
                    {
                        MessageBox.Show("Preencha a Mesa e o Garçom para iniciar o pedido.");
                        return;
                    }

                    var order = new Order
                    {
                        TableNumber = int.Parse(txtTableNumber.Text),
                        WaiterId = (int)cmbWaiter.SelectedValue,
                        IsPaid = false,
                        TotalAmount = 0
                    };

                    var savedOrder = _baseOrderService.Add<Order, OrderViewModel, OrderValidator>(order);
                    _currentOrderId = savedOrder.Id;
                    IsAlteracao = true;
                }

                if (cmbProduct.SelectedValue == null)
                {
                    MessageBox.Show("Selecione um produto.");
                    return;
                }

                int productId = (int)cmbProduct.SelectedValue;
                int quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 1 : int.Parse(txtQuantity.Text);

                _orderService.AddItemToOrder(_currentOrderId, productId, quantity);

                CarregaItensPedido();
                CarregaGrid();

                MessageBox.Show("Item adicionado!");
            }
            catch (ValidationException vex)
            {
                MessageBox.Show(string.Join("\n", vex.Errors), "Validação");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar item: {ex.Message}");
            }
        }

        protected override void Deletar(int id)
        {
            try
            {
                _baseOrderService.Delete(id);
                MessageBox.Show("Pedido excluído!");
                CarregaGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir: {ex.Message}");
            }
        }

        protected override void CarregaRegistro(DataGridViewRow? linha)
        {
            if (linha != null)
            {
                _currentOrderId = (int)linha.Cells["Id"].Value;
                txtTableNumber.Text = linha.Cells["TableNumber"].Value?.ToString();

                if (linha.Cells["WaiterId"].Value != null)
                    cmbWaiter.SelectedValue = (int)linha.Cells["WaiterId"].Value;

                IsAlteracao = true;
                CarregaItensPedido();
                tabControlCadastro.SelectedIndex = 0; // Volta para aba de cadastro para ver os itens
            }
        }
    }
}