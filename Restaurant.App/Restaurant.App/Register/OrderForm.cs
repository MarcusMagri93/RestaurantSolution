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

            // Garante que a aba inicial seja a de Cadastro
            this.tabControlCadastro.SelectedIndex = 0;
            CarregaCombos();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                this.tabControlCadastro.SelectedIndex = 0;
                LimpaCampos();
                _currentOrderId = 0; // Reseta para novo pedido
                dgvOrderItems.DataSource = null;
                IsAlteracao = false;
            }
        }

        private void CarregaCombos()
        {
            // Carrega Garçons
            var waiters = _waiterService.Get<WaiterViewModel>().ToList();
            cmbWaiter.DataSource = waiters;
            cmbWaiter.DisplayMember = "Name";
            cmbWaiter.ValueMember = "Id";

            // Carrega Produtos
            var products = _productService.Get<ProductViewModel>().ToList();
            cmbProduct.DataSource = products;
            cmbProduct.DisplayMember = "Name";
            cmbProduct.ValueMember = "Id";
        }

        protected override void CarregaGrid()
        {
            dataGridViewConsulta.DataSource = _baseOrderService.Get<OrderViewModel>();
        }

        private void CarregaItensPedido()
        {
            if (_currentOrderId == 0) return;

            try
            {
                // Busca o pedido detalhado para mostrar os itens no grid de baixo
                var order = _orderService.GetOrder(_currentOrderId);
                if (order != null && order.OrderItems != null)
                {
                    var itensGrid = order.OrderItems.Select(i => new
                    {
                        Id = i.Id,
                        Produto = i.Product != null ? i.Product.Name : "Produto " + i.ProductId,
                        Qtd = i.Quantity,
                        // PrecoUnit = i.Product?.Price ?? 0, // Opcional
                        Total = (i.Product?.Price ?? 0) * i.Quantity
                    }).ToList();

                    dgvOrderItems.DataSource = itensGrid;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // --- SALVAR (CABEÇALHO) ---
        protected override void Salvar()
        {
            try
            {
                // Validação básica manual
                if (string.IsNullOrEmpty(txtTableNumber.Text))
                {
                    MessageBox.Show("Informe o número da mesa.");
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

                CarregaGrid(); // Atualiza lista da aba de consulta
                // IMPORTANTE: Não limpamos os campos nem mudamos de aba aqui
                // para permitir que o usuário continue adicionando itens.
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

        // --- ADICIONAR ITEM (COM AUTO-SAVE) ---
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. AUTO-SAVE: Se o pedido não existe, cria ele agora
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

                    // Salva silenciosamente para gerar o ID
                    var savedOrder = _baseOrderService.Add<Order, OrderViewModel, OrderValidator>(order);
                    _currentOrderId = savedOrder.Id;
                    IsAlteracao = true;
                }

                // 2. Adiciona o Item
                if (cmbProduct.SelectedValue == null)
                {
                    MessageBox.Show("Selecione um produto.");
                    return;
                }

                int productId = (int)cmbProduct.SelectedValue;
                int quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 1 : int.Parse(txtQuantity.Text);

                _orderService.AddItemToOrder(_currentOrderId, productId, quantity);

                // 3. Atualiza as telas
                CarregaItensPedido(); // Atualiza o grid de itens
                CarregaGrid(); // Atualiza o total na lista de pedidos

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

                // Tenta selecionar o garçom no combo
                if (linha.Cells["WaiterId"].Value != null)
                    cmbWaiter.SelectedValue = (int)linha.Cells["WaiterId"].Value;

                IsAlteracao = true;
                CarregaItensPedido();
            }
        }
    }
}