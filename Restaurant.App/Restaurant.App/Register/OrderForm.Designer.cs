using System.Windows.Forms;
using ReaLTaiizor.Controls;

namespace Restaurant.App.Register
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;

        // Cabeçalho
        protected MaterialTextBoxEdit txtTableNumber;
        protected MaterialComboBox cmbWaiter;
        protected MaterialLabel lblTableNumber;
        protected MaterialLabel lblWaiter;

        // Adição de Itens (NOVOS)
        protected MaterialComboBox cmbProduct;
        protected MaterialLabel lblProduct;
        protected MaterialTextBoxEdit txtQuantity;
        protected MaterialLabel lblQuantity;
        protected MaterialButton btnAddItem;

        // Lista de Itens
        protected DataGridView dgvOrderItems;
        protected MaterialLabel lblOrderItems;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtTableNumber = new MaterialTextBoxEdit();
            this.cmbWaiter = new MaterialComboBox();
            this.lblTableNumber = new MaterialLabel();
            this.lblWaiter = new MaterialLabel();
            this.dgvOrderItems = new DataGridView();
            this.lblOrderItems = new MaterialLabel();
            this.btnAddItem = new MaterialButton();

            // Novos Componentes
            this.cmbProduct = new MaterialComboBox();
            this.lblProduct = new MaterialLabel();
            this.txtQuantity = new MaterialTextBoxEdit();
            this.lblQuantity = new MaterialLabel();

            // NÃO chame base.InitializeComponent() aqui para evitar duplicação visual do pai

            this.tabPageCadastro.SuspendLayout();
            this.SuspendLayout();

            // 1. MESA
            this.lblTableNumber.AutoSize = true;
            this.lblTableNumber.Location = new System.Drawing.Point(20, 20);
            this.lblTableNumber.Text = "Número da Mesa:";
            this.tabPageCadastro.Controls.Add(this.lblTableNumber);

            this.txtTableNumber.Location = new System.Drawing.Point(20, 45);
            this.txtTableNumber.Size = new System.Drawing.Size(150, 36);
            this.tabPageCadastro.Controls.Add(this.txtTableNumber);

            // 2. GARÇOM
            this.lblWaiter.AutoSize = true;
            this.lblWaiter.Location = new System.Drawing.Point(200, 20);
            this.lblWaiter.Text = "Garçom:";
            this.tabPageCadastro.Controls.Add(this.lblWaiter);

            this.cmbWaiter.Location = new System.Drawing.Point(200, 45);
            this.cmbWaiter.Size = new System.Drawing.Size(250, 36);
            this.tabPageCadastro.Controls.Add(this.cmbWaiter);

            // 3. PRODUTO (NOVO)
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(20, 100);
            this.lblProduct.Text = "Produto:";
            this.tabPageCadastro.Controls.Add(this.lblProduct);

            this.cmbProduct.Location = new System.Drawing.Point(20, 125);
            this.cmbProduct.Size = new System.Drawing.Size(300, 36);
            this.tabPageCadastro.Controls.Add(this.cmbProduct);

            // 4. QUANTIDADE (NOVO)
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(340, 100);
            this.lblQuantity.Text = "Qtd:";
            this.tabPageCadastro.Controls.Add(this.lblQuantity);

            this.txtQuantity.Location = new System.Drawing.Point(340, 125);
            this.txtQuantity.Size = new System.Drawing.Size(100, 36);
            this.txtQuantity.Text = "1"; // Valor padrão
            this.tabPageCadastro.Controls.Add(this.txtQuantity);

            // 5. BOTÃO ADICIONAR
            this.btnAddItem.Text = "Adicionar Item";
            this.btnAddItem.Location = new System.Drawing.Point(460, 120);
            this.btnAddItem.Size = new System.Drawing.Size(150, 40);
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click); // Evento Importante
            this.tabPageCadastro.Controls.Add(this.btnAddItem);

            // 6. GRID DE ITENS
            this.lblOrderItems.AutoSize = true;
            this.lblOrderItems.Location = new System.Drawing.Point(20, 180);
            this.lblOrderItems.Text = "Itens do Pedido:";
            this.tabPageCadastro.Controls.Add(this.lblOrderItems);

            this.dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(20, 205);
            this.dgvOrderItems.Size = new System.Drawing.Size(640, 200);
            this.dgvOrderItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.tabPageCadastro.Controls.Add(this.dgvOrderItems);

            this.Text = "Gerenciamento de Pedidos";

            this.tabPageCadastro.ResumeLayout(false);
            this.tabPageCadastro.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}