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

        // Lista em memória para facilitar a navegação mestre-detalhe
        private List<OrderViewModel> _activeOrders = new List<OrderViewModel>();

        public TableMonitorForm(IOrderService orderService)
        {
            InitializeComponent();
            _orderService = orderService;

            // Configura o evento de seleção da tabela
            dgvTables.SelectionChanged += DgvTables_SelectionChanged;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                CarregarMonitor();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CarregarMonitor();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarregarMonitor()
        {
            try
            {
                // Busca dados atualizados do serviço
                _activeOrders = _orderService.GetOpenOrdersWithDetails<OrderViewModel>().ToList();

                // Monta a lista resumida para o Grid da Esquerda (Mestre)
                var tablesDisplay = _activeOrders.Select(o => new
                {
                    Id = o.Id, // Oculto, mas útil para chave
                    Mesa = o.TableNumber,
                    Garcom = o.Waiter != null ? o.Waiter.Name : "N/A"
                }).OrderBy(x => x.Mesa).ToList();

                dgvTables.DataSource = tablesDisplay;

                // Oculta coluna ID se desejar
                if (dgvTables.Columns["Id"] != null) dgvTables.Columns["Id"].Visible = false;

                // Se houver mesas, seleciona a primeira automaticamente
                if (dgvTables.Rows.Count > 0)
                {
                    dgvTables.Rows[0].Selected = true;
                    AtualizarDetalhes(0);
                }
                else
                {
                    // Limpa detalhes se não houver mesas
                    dgvDetails.DataSource = null;
                    lblTotalValue.Text = "R$ 0,00";
                }
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
                    // CORREÇÃO AQUI: Convertendo explicitamente double para decimal
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
                lblTotalValue.Text = calculatedTotal.ToString("C2");
            }
        }
    }
}