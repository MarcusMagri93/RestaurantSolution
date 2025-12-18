using Restaurant.Domain.Interfaces.Base;
using Restaurant.App.Base;
using Restaurant.App.ViewModel;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Services.Validators;

namespace Restaurant.App.Register
{
    public partial class OrderForm : BaseForm
    {
        // Definição dos serviços que serão injetados via construtor
        private readonly IBaseService<Order> _baseOrderService;
        private readonly IOrderService _orderService;
        private readonly IBaseService<Waiter> _waiterService;
        private readonly IBaseService<Product> _productService;

        // Variável que controla qual o pedido está a ser editado no momento (0 = Novo)
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

            // Define a aba inicial como "Cadastro"
            this.tabControlCadastro.SelectedIndex = 0;
        }

        // Janela Visíveis
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                CarregaCombos(); // Preenche os dropdowns de garçom e produto
                this.tabControlCadastro.SelectedIndex = 0;
                LimpaCampos();
                _currentOrderId = 0;
                dgvOrderItems.DataSource = null;
                IsAlteracao = false;
                CarregaGrid(); // Atualiza a aba de consulta
            }
        }

        // --- MÉTODOS DE APOIO À INTERFACE ---

        // Preenche as listas de seleção com dados do banco
        private void CarregaCombos()
        {
            // Busca todos os garçons e vincula ao componente da tela
            var waiters = _waiterService.Get<WaiterViewModel>().ToList();
            cmbWaiter.DataSource = waiters;
            cmbWaiter.DisplayMember = "Name"; 
            cmbWaiter.ValueMember = "Id";     

            // Busca todos os produtos para a seleção de itens
            var products = _productService.Get<ProductViewModel>().ToList();
            cmbProduct.DataSource = products;
            cmbProduct.DisplayMember = "Name";
            cmbProduct.ValueMember = "Id";
        }

        // Atualiza a grade secundária que mostra os itens do pedido atual
        private void CarregaItensPedido()
        {
            if (_currentOrderId == 0) return;

            try
            {
                // Busca o pedido detalhado através do serviço especializado
                var order = _orderService.GetOrder(_currentOrderId);
                if (order != null && order.OrderItems != null)
                {
                    var itensGrid = order.OrderItems.Select(i => new
                    {
                        Id = i.Id,
                        Produto = i.Product != null ? i.Product.Name : "Produto " + i.ProductId,
                        Qtd = i.Quantity,
                        // Cálculo em tempo real do subtotal da linha
                        Total = ((decimal)(i.Product?.Price ?? 0)) * i.Quantity
                    }).ToList();

                    dgvOrderItems.DataSource = itensGrid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar itens: " + ex.Message);
            }
        }

        // Verifica se uma mesa já tem uma conta aberta antes de iniciar uma nova
        private void CarregarPedidoSeExistir(int tableNumber)
        {
            var pedidoExistente = _orderService.GetOpenOrders()
                                               .FirstOrDefault(o => o.TableNumber == tableNumber);

            if (pedidoExistente != null)
            {
                _currentOrderId = pedidoExistente.Id;
                IsAlteracao = true;
                txtTableNumber.Text = pedidoExistente.TableNumber.ToString();
                if (pedidoExistente.WaiterId > 0)
                    cmbWaiter.SelectedValue = pedidoExistente.WaiterId;

                CarregaItensPedido(); // Carrega os itens já consumidos
            }
        }

        // --- LÓGICA DE SALVAMENTO E ITENS ---

        protected override void Salvar()
        {
            try
            {
                if (string.IsNullOrEmpty(txtTableNumber.Text)) { MessageBox.Show("Informe a mesa."); return; }
                if (cmbWaiter.SelectedValue == null) { MessageBox.Show("Selecione um garçom."); return; }

                int tableNum = int.Parse(txtTableNumber.Text);
                if (_currentOrderId == 0) CarregarPedidoSeExistir(tableNum);

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
                    MessageBox.Show("Pedido atualizado!");
                }
                else
                {
                    var savedOrder = _baseOrderService.Add<Order, OrderViewModel, OrderValidator>(order);
                    _currentOrderId = savedOrder.Id;
                    IsAlteracao = true;
                    MessageBox.Show($"Pedido #{savedOrder.Id} iniciado!");
                }
                CarregaGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}");
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                int tableNum = int.Parse(txtTableNumber.Text);
                if (_currentOrderId == 0) CarregarPedidoSeExistir(tableNum);

                // Se o pedido não existir, cria um automaticamente antes de adicionar o item
                if (_currentOrderId == 0)
                {
                    var order = new Order { TableNumber = tableNum, WaiterId = (int)cmbWaiter.SelectedValue };
                    var savedOrder = _baseOrderService.Add<Order, OrderViewModel, OrderValidator>(order);
                    _currentOrderId = savedOrder.Id;
                }

                int productId = (int)cmbProduct.SelectedValue;
                int quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 1 : int.Parse(txtQuantity.Text);

                // Delega para o serviço especializado a lógica de adicionar/somar itens
                _orderService.AddItemToOrder(_currentOrderId, productId, quantity);

                CarregaItensPedido(); 
                CarregaGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        // --- SOBRESCRITAS DO BASEFORM ---

        protected override void CarregaGrid()
        {
            dataGridViewConsulta.DataSource = _orderService.GetAllWithDetails<OrderViewModel>();
        }

        protected override void CarregaRegistro(DataGridViewRow? linha)
        {
            if (linha != null)
            {
                _currentOrderId = (int)linha.Cells["Id"].Value;
                txtTableNumber.Text = linha.Cells["TableNumber"].Value?.ToString();
                cmbWaiter.SelectedValue = (int)linha.Cells["WaiterId"].Value;
                IsAlteracao = true;
                CarregaItensPedido();
                tabControlCadastro.SelectedIndex = 0;
            }
        }

        protected override void Deletar(int id)
        {
            _baseOrderService.Delete(id);
            CarregaGrid();
        }
    }
}