using System.Windows.Forms;
using ReaLTaiizor.Controls;

namespace Restaurant.App.Register
{
    // A classe Designer é parcial e deve corresponder à classe principal OrderForm
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;

        // Componentes específicos para o cabeçalho do Pedido
        protected MaterialTextBoxEdit txtTableNumber;
        protected MaterialComboBox cmbWaiter;
        protected MaterialLabel lblTableNumber;
        protected MaterialLabel lblWaiter;

        // Componente para a lista de itens do pedido
        protected DataGridView dgvOrderItems;
        protected MaterialLabel lblOrderItems;
        protected MaterialButton btnAddItem; // Botão para adicionar itens

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
            this.txtTableNumber = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.cmbWaiter = new ReaLTaiizor.Controls.MaterialComboBox();
            this.lblTableNumber = new ReaLTaiizor.Controls.MaterialLabel();
            this.lblWaiter = new ReaLTaiizor.Controls.MaterialLabel();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.lblOrderItems = new ReaLTaiizor.Controls.MaterialLabel();
            this.btnAddItem = new ReaLTaiizor.Controls.MaterialButton();

            // Chamada do InitializeComponent da classe base (IMPORTANTE!)
            base.InitializeComponent();

            // Configuração dos controles específicos

            // 
            // lblTableNumber
            // 
            this.lblTableNumber.AutoSize = true;
            this.lblTableNumber.Location = new System.Drawing.Point(50, 50);
            this.lblTableNumber.Size = new System.Drawing.Size(120, 20);
            this.lblTableNumber.Text = "Número da Mesa:";
            this.lblTableNumber.Name = "lblTableNumber";
            this.tabPageCadastro.Controls.Add(this.lblTableNumber);

            // 
            // txtTableNumber
            // 
            this.txtTableNumber.Location = new System.Drawing.Point(50, 75);
            this.txtTableNumber.Size = new System.Drawing.Size(150, 36);
            this.txtTableNumber.Name = "txtTableNumber";
            this.tabPageCadastro.Controls.Add(this.txtTableNumber);

            // 
            // lblWaiter
            // 
            this.lblWaiter.AutoSize = true;
            this.lblWaiter.Location = new System.Drawing.Point(250, 50);
            this.lblWaiter.Size = new System.Drawing.Size(70, 20);
            this.lblWaiter.Text = "Garçom:";
            this.lblWaiter.Name = "lblWaiter";
            this.tabPageCadastro.Controls.Add(this.lblWaiter);

            // 
            // cmbWaiter
            // 
            this.cmbWaiter.Location = new System.Drawing.Point(250, 75);
            this.cmbWaiter.Size = new System.Drawing.Size(250, 36);
            this.cmbWaiter.Name = "cmbWaiter";
            this.tabPageCadastro.Controls.Add(this.cmbWaiter);

            // 
            // lblOrderItems
            // 
            this.lblOrderItems.AutoSize = true;
            this.lblOrderItems.Location = new System.Drawing.Point(50, 150);
            this.lblOrderItems.Size = new System.Drawing.Size(125, 20);
            this.lblOrderItems.Text = "Itens do Pedido:";
            this.lblOrderItems.Name = "lblOrderItems";
            this.tabPageCadastro.Controls.Add(this.lblOrderItems);

            // 
            // btnAddItem
            // 
            this.btnAddItem.Text = "Adicionar Item";
            this.btnAddItem.Location = new System.Drawing.Point(500, 145);
            this.btnAddItem.Size = new System.Drawing.Size(150, 40);
            this.btnAddItem.Name = "btnAddItem";
            // Você pode adicionar um evento click aqui se quiser que o botão funcione
            // this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            this.tabPageCadastro.Controls.Add(this.btnAddItem);

            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(50, 190);
            this.dgvOrderItems.Size = new System.Drawing.Size(700, 250);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.tabPageCadastro.Controls.Add(this.dgvOrderItems);

            // Finaliza o layout da TabPage Cadastro
            this.tabPageCadastro.ResumeLayout(false);
            this.tabPageCadastro.PerformLayout();
        }

        #endregion
    }
}