using System.Windows.Forms;
using ReaLTaiizor.Controls;

namespace Restaurant.App.Others
{
    partial class TableMonitorForm
    {
        private System.ComponentModel.IContainer components = null;

        protected SplitContainer splitContainer1;
        protected System.Windows.Forms.GroupBox grpMesas;
        protected DataGridView dgvTables;
        protected System.Windows.Forms.GroupBox grpDetalhes;
        protected DataGridView dgvDetails;
        protected MaterialLabel lblTotalLabel;
        protected MaterialLabel lblTotalValue;

        protected MaterialButton btnRefresh;
        protected MaterialButton btnClose;
        protected MaterialButton btnCloseBill; // <--- NOVO

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpMesas = new System.Windows.Forms.GroupBox();
            this.dgvTables = new System.Windows.Forms.DataGridView();
            this.grpDetalhes = new System.Windows.Forms.GroupBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.lblTotalLabel = new ReaLTaiizor.Controls.MaterialLabel();
            this.lblTotalValue = new ReaLTaiizor.Controls.MaterialLabel();
            this.btnRefresh = new ReaLTaiizor.Controls.MaterialButton();
            this.btnClose = new ReaLTaiizor.Controls.MaterialButton();
            this.btnCloseBill = new ReaLTaiizor.Controls.MaterialButton(); // <--- Inicializa

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpMesas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
            this.grpDetalhes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();

            // splitContainer1
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 70);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add(this.grpMesas);
            this.splitContainer1.Panel2.Controls.Add(this.grpDetalhes);
            this.splitContainer1.Panel2.Controls.Add(this.lblTotalLabel);
            this.splitContainer1.Panel2.Controls.Add(this.lblTotalValue);
            this.splitContainer1.Size = new System.Drawing.Size(788, 320);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;

            // grpMesas
            this.grpMesas.Controls.Add(this.dgvTables);
            this.grpMesas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMesas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpMesas.Location = new System.Drawing.Point(0, 0);
            this.grpMesas.Name = "grpMesas";
            this.grpMesas.Size = new System.Drawing.Size(300, 320);
            this.grpMesas.TabIndex = 0;
            this.grpMesas.TabStop = false;
            this.grpMesas.Text = "Mesas Abertas";

            // dgvTables
            this.dgvTables.AllowUserToAddRows = false;
            this.dgvTables.AllowUserToDeleteRows = false;
            this.dgvTables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTables.Location = new System.Drawing.Point(3, 21);
            this.dgvTables.MultiSelect = false;
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.ReadOnly = true;
            this.dgvTables.RowHeadersVisible = false;
            this.dgvTables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTables.Size = new System.Drawing.Size(294, 296);
            this.dgvTables.TabIndex = 0;

            // grpDetalhes
            this.grpDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetalhes.Controls.Add(this.dgvDetails);
            this.grpDetalhes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDetalhes.Location = new System.Drawing.Point(3, 0);
            this.grpDetalhes.Name = "grpDetalhes";
            this.grpDetalhes.Size = new System.Drawing.Size(478, 260);
            this.grpDetalhes.TabIndex = 0;
            this.grpDetalhes.TabStop = false;
            this.grpDetalhes.Text = "Consumo da Mesa";

            // dgvDetails
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(3, 21);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(472, 236);
            this.dgvDetails.TabIndex = 0;

            // Labels e Botões
            this.lblTotalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Location = new System.Drawing.Point(250, 275);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(107, 19);
            this.lblTotalLabel.Text = "Total da Mesa:";

            this.lblTotalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotalValue.Location = new System.Drawing.Point(370, 270);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(71, 24);
            this.lblTotalValue.Text = "R$ 0,00";

            // btnCloseBill
            this.btnCloseBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseBill.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCloseBill.Location = new System.Drawing.Point(440, 405);
            this.btnCloseBill.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCloseBill.Name = "btnCloseBill";
            this.btnCloseBill.Size = new System.Drawing.Size(130, 36);
            this.btnCloseBill.Text = "FECHAR MESA";
            this.btnCloseBill.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCloseBill.UseAccentColor = true;
            this.btnCloseBill.Click += new System.EventHandler(this.btnCloseBill_Click);

            // btnRefresh
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.Location = new System.Drawing.Point(580, 405);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 36);
            this.btnRefresh.Text = "Atualizar";
            this.btnRefresh.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnClose
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Location = new System.Drawing.Point(690, 405);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 36);
            this.btnClose.Text = "Sair";
            this.btnClose.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCloseBill);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Name = "TableMonitorForm";
            this.Text = "Monitoramento de Mesas";

            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpMesas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
            this.grpDetalhes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}