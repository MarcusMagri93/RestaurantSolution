using ReaLTaiizor.Forms;
using Restaurant.Domain.Interfaces.Base;
using Restaurant.App.ViewModel;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.App.Others
{
    public partial class TableMonitorForm : MaterialForm
    {
        private readonly IOrderService _orderService;
        // Lista local para armazenar os pedidos ativos e evitar consultas excessivas ao banco de dados
        private List<OrderViewModel> _activeOrders = new List<OrderViewModel>();

        public TableMonitorForm(IOrderService orderService)
        {
            InitializeComponent();
            _orderService = orderService;
            dgvTables.SelectionChanged += DgvTables_SelectionChanged;
        }

        // Disparado quando a janela está visível 
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                CarregarMonitor(); // Atualiza os dados sempre que a tela abrir.
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Lógica para encerrar uma conta.
        private void btnCloseBill_Click(object sender, EventArgs e)
        {
            if (dgvTables.SelectedRows.Count == 0) // Nenhuma mesa selecionada na hora de fechar a conta
            {
                MessageBox.Show("Selecione uma mesa para fechar a conta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Recupera o ID e o número da mesa 
            int orderId = (int)dgvTables.SelectedRows[0].Cells["Id"].Value;
            int tableNum = (int)dgvTables.SelectedRows[0].Cells["Mesa"].Value;

            if (MessageBox.Show($"Deseja realmente fechar a conta da Mesa {tableNum}?", "Confirmar Fechamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Marcar o pedido como pago e calcular o total final
                    _orderService.CloseBill(orderId);
                    MessageBox.Show($"Mesa {tableNum} fechada com sucesso!");
                    CarregarMonitor(); // Recarrega a tela 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao fechar mesa: " + ex.Message);
                }
            }
        }

        // Método que ataualiza os dados na página
        private void CarregarMonitor()
        {
            try
            {
                // Busca apenas as mesas ativas
                _activeOrders = _orderService.GetOpenOrdersWithDetails<OrderViewModel>().ToList();

                // Cria uma lista simplificada para exibir apenas as colunas necessárias na grade da esquerda.
                var tablesDisplay = _activeOrders.Select(o => new
                {
                    Id = o.Id,
                    Mesa = o.TableNumber,
                    Garcom = o.Waiter != null ? o.Waiter.Name : "N/A"
                }).OrderBy(x => x.Mesa).ToList();

                dgvTables.DataSource = tablesDisplay;
                if (dgvTables.Columns["Id"] != null) dgvTables.Columns["Id"].Visible = false; // Esconde o ID técnico do usuário.

                // Seleciona automaticamente a primeira mesa da lista, se houver.
                if (dgvTables.Rows.Count > 0)
                {
                    dgvTables.Rows[0].Selected = true;
                    AtualizarDetalhes(0);
                }
                else
                {
                    dgvDetails.DataSource = null;
                    lblTotalValue.Text = "R$ 0,00";
                }

                // Busca o faturamento acumulado do dia atual.
                decimal revenue = (decimal)_orderService.GetTotalRevenue(DateTime.Today);
                lblDailyRevenue.Text = $"Total do Dia: {revenue.ToString("C2")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar mesas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvTables_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTables.SelectedRows.Count > 0)
            {
                int index = dgvTables.SelectedRows[0].Index;
                AtualizarDetalhes(index);
            }
        }

        // Preenche a grade da direita com os itens consumidos pela mesa 
        private void AtualizarDetalhes(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= _activeOrders.Count) return;

            int orderId = (int)dgvTables.Rows[rowIndex].Cells["Id"].Value;
            var selectedOrder = _activeOrders.FirstOrDefault(o => o.Id == orderId);

            if (selectedOrder != null)
            {
                decimal calculatedTotal = 0;

                var itemsDisplay = selectedOrder.OrderItems.Select(i =>
                {
                    decimal unitPrice = i.Product != null ? (decimal)i.Product.Price : 0;
                    decimal subtotal = unitPrice * i.Quantity;
                    calculatedTotal += subtotal;

                    return new
                    {
                        Produto = i.Product != null ? i.Product.Name : "Desconhecido",
                        Qtd = i.Quantity,
                        Preco = unitPrice.ToString("C2"),
                        Subtotal = subtotal.ToString("C2")
                    };
                }).ToList();

                dgvDetails.DataSource = itemsDisplay;
                lblTotalValue.Text = calculatedTotal.ToString("C2"); // Formata como moeda (R$).
            }
        }
    }
}