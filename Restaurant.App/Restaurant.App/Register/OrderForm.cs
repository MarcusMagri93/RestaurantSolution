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

            // Define a aba inicial mas NÃO carrega os combos aqui
            this.tabControlCadastro.SelectedIndex = 0;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                CarregaCombos();
                this.tabControlCadastro.SelectedIndex = 0;
                LimpaCampos();
                _currentOrderId = 0;
                dgvOrderItems.DataSource = null;
                IsAlteracao = false;
                CarregaGrid();
            }
        }

        private void CarregaCombos()
        {
            var waiters = _waiterService.Get<WaiterViewModel>().ToList();
            cmbWaiter.DataSource = waiters;
            cmbWaiter.DisplayMember = "Name";
            cmbWaiter.ValueMember = "Id";

            var products = _productService.Get<ProductViewModel>().ToList();
            cmbProduct.DataSource = products;
            cmbProduct.DisplayMember = "Name";
            cmbProduct.ValueMember = "Id";
        }

        protected override void CarregaGrid()
        {
            dataGridViewConsulta.DataSource = null;
            dataGridViewConsulta.AutoGenerateColumns = true;
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
                        Total = ((decimal)(i.Product?.Price ?? 0)) * i.Quantity // Conversão para decimal
                    }).ToList();

                    dgvOrderItems.DataSource = itensGrid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar itens: " + ex.Message);
            }
        }

        // --- LÓGICA DE PREVENÇÃO DE DUPLICIDADE ---
        private bool VerificarMesaOcupada(int tableNumber)
        {
            // Busca se existe algum pedido NÃO PAGO para esta mesa
            var pedidoExistente = _orderService.GetOpenOrders()
                                               .FirstOrDefault(o => o.TableNumber == tableNumber);

            if (pedidoExistente != null && pedidoExistente.Id != _currentOrderId)
            {
                var confirm = MessageBox.Show(
                    $"A Mesa {tableNumber} já possui um pedido aberto (Nº {pedidoExistente.Id}).\n\nDeseja carregar este pedido existente para continuar lançando itens nele?",
                    "Mesa Ocupada",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // Carrega o pedido existente
                    _currentOrderId = pedidoExistente.Id;
                    IsAlteracao = true;

                    // Preenche os campos
                    txtTableNumber.Text = pedidoExistente.TableNumber.ToString();
                    if (pedidoExistente.WaiterId > 0) cmbWaiter.SelectedValue = pedidoExistente.WaiterId;

                    CarregaItensPedido();
                    return true; // Indica que recuperamos um existente
                }
                else
                {
                    return false; // Usuário cancelou
                }
            }
            return false; // Mesa livre
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

                int tableNum = int.Parse(txtTableNumber.Text);

                // Se for novo pedido, verifica se a mesa já está ocupada
                if (_currentOrderId == 0)
                {
                    bool recuperou = VerificarMesaOcupada(tableNum);
                    if (recuperou) return; // Já carregou o existente, não precisa salvar novo agora
                }

                var order = new Order
                {
                    TableNumber = tableNum,
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
                // 1. AUTO-SAVE com Verificação
                if (_currentOrderId == 0)
                {
                    if (string.IsNullOrEmpty(txtTableNumber.Text) || cmbWaiter.SelectedValue == null)
                    {
                        MessageBox.Show("Preencha a Mesa e o Garçom para iniciar o pedido.");
                        return;
                    }

                    int tableNum = int.Parse(txtTableNumber.Text);

                    // Verifica mesa ocupada antes de criar
                    bool recuperou = VerificarMesaOcupada(tableNum);

                    if (!recuperou)
                    {
                        // Se não recuperou e não cancelou (ou seja, mesa livre), cria novo
                        // Mas se o usuário cancelou na msgbox, VerificarMesaOcupada retorna false?
                        // Ajuste lógico: Se existia e usuário disse NÃO, não devemos criar duplicado.
                        // Vamos simplificar: se existe, FORÇA o uso ou cancela.

                        var existe = _orderService.GetOpenOrders().Any(o => o.TableNumber == tableNum);
                        if (existe)
                        {
                            MessageBox.Show("Operação cancelada: Mesa já ocupada.");
                            return;
                        }

                        var order = new Order
                        {
                            TableNumber = tableNum,
                            WaiterId = (int)cmbWaiter.SelectedValue,
                            IsPaid = false,
                            TotalAmount = 0
                        };

                        var savedOrder = _baseOrderService.Add<Order, OrderViewModel, OrderValidator>(order);
                        _currentOrderId = savedOrder.Id;
                        IsAlteracao = true;
                    }
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
                tabControlCadastro.SelectedIndex = 0;
            }
        }
    }
}