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

        protected MaterialButton btnClose;
        protected MaterialButton btnCloseBill;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            grpMesas = new System.Windows.Forms.GroupBox();
            dgvTables = new DataGridView();
            grpDetalhes = new System.Windows.Forms.GroupBox();
            dgvDetails = new DataGridView();
            lblTotalLabel = new MaterialLabel();
            lblTotalValue = new MaterialLabel();
            btnClose = new MaterialButton();
            btnCloseBill = new MaterialButton();
            lblDailyRevenue = new MaterialButton();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            grpMesas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTables).BeginInit();
            grpDetalhes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(7, 93);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(grpMesas);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(grpDetalhes);
            splitContainer1.Panel2.Controls.Add(lblTotalLabel);
            splitContainer1.Panel2.Controls.Add(lblTotalValue);
            splitContainer1.Size = new Size(901, 427);
            splitContainer1.SplitterDistance = 343;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // grpMesas
            // 
            grpMesas.Controls.Add(dgvTables);
            grpMesas.Dock = DockStyle.Fill;
            grpMesas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpMesas.Location = new Point(0, 0);
            grpMesas.Margin = new Padding(3, 4, 3, 4);
            grpMesas.Name = "grpMesas";
            grpMesas.Padding = new Padding(3, 4, 3, 4);
            grpMesas.Size = new Size(343, 427);
            grpMesas.TabIndex = 0;
            grpMesas.TabStop = false;
            grpMesas.Text = "Mesas Abertas";
            // 
            // dgvTables
            // 
            dgvTables.AllowUserToAddRows = false;
            dgvTables.AllowUserToDeleteRows = false;
            dgvTables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTables.Dock = DockStyle.Fill;
            dgvTables.Location = new Point(3, 27);
            dgvTables.Margin = new Padding(3, 4, 3, 4);
            dgvTables.MultiSelect = false;
            dgvTables.Name = "dgvTables";
            dgvTables.ReadOnly = true;
            dgvTables.RowHeadersVisible = false;
            dgvTables.RowHeadersWidth = 51;
            dgvTables.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTables.Size = new Size(337, 396);
            dgvTables.TabIndex = 0;
            // 
            // grpDetalhes
            // 
            grpDetalhes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDetalhes.Controls.Add(dgvDetails);
            grpDetalhes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpDetalhes.Location = new Point(3, 0);
            grpDetalhes.Margin = new Padding(3, 4, 3, 4);
            grpDetalhes.Name = "grpDetalhes";
            grpDetalhes.Padding = new Padding(3, 4, 3, 4);
            grpDetalhes.Size = new Size(542, 347);
            grpDetalhes.TabIndex = 0;
            grpDetalhes.TabStop = false;
            grpDetalhes.Text = "Consumo da Mesa";
            // 
            // dgvDetails
            // 
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AllowUserToDeleteRows = false;
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetails.Dock = DockStyle.Fill;
            dgvDetails.Location = new Point(3, 27);
            dgvDetails.Margin = new Padding(3, 4, 3, 4);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.ReadOnly = true;
            dgvDetails.RowHeadersVisible = false;
            dgvDetails.RowHeadersWidth = 51;
            dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetails.Size = new Size(536, 316);
            dgvDetails.TabIndex = 0;
            // 
            // lblTotalLabel
            // 
            lblTotalLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalLabel.AutoSize = true;
            lblTotalLabel.Depth = 0;
            lblTotalLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTotalLabel.Location = new Point(282, 367);
            lblTotalLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblTotalLabel.Name = "lblTotalLabel";
            lblTotalLabel.Size = new Size(107, 19);
            lblTotalLabel.TabIndex = 1;
            lblTotalLabel.Text = "Total da Mesa:";
            // 
            // lblTotalValue
            // 
            lblTotalValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalValue.AutoSize = true;
            lblTotalValue.Depth = 0;
            lblTotalValue.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTotalValue.Location = new Point(419, 360);
            lblTotalValue.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(54, 19);
            lblTotalValue.TabIndex = 2;
            lblTotalValue.Text = "R$ 0,00";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClose.Density = MaterialButton.MaterialButtonDensity.Default;
            btnClose.Depth = 0;
            btnClose.HighEmphasis = true;
            btnClose.Icon = null;
            btnClose.IconType = MaterialButton.MaterialIconType.Rebase;
            btnClose.Location = new Point(844, 552);
            btnClose.Margin = new Padding(5, 8, 5, 8);
            btnClose.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnClose.Name = "btnClose";
            btnClose.NoAccentTextColor = Color.Empty;
            btnClose.Size = new Size(64, 36);
            btnClose.TabIndex = 1;
            btnClose.Text = "Sair";
            btnClose.Type = MaterialButton.MaterialButtonType.Outlined;
            btnClose.UseAccentColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnCloseBill
            // 
            btnCloseBill.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCloseBill.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCloseBill.Density = MaterialButton.MaterialButtonDensity.Default;
            btnCloseBill.Depth = 0;
            btnCloseBill.HighEmphasis = true;
            btnCloseBill.Icon = null;
            btnCloseBill.IconType = MaterialButton.MaterialIconType.Rebase;
            btnCloseBill.Location = new Point(358, 552);
            btnCloseBill.Margin = new Padding(5, 8, 5, 8);
            btnCloseBill.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnCloseBill.Name = "btnCloseBill";
            btnCloseBill.NoAccentTextColor = Color.Empty;
            btnCloseBill.Size = new Size(120, 36);
            btnCloseBill.TabIndex = 0;
            btnCloseBill.Text = "FECHAR MESA";
            btnCloseBill.Type = MaterialButton.MaterialButtonType.Contained;
            btnCloseBill.UseAccentColor = true;
            btnCloseBill.Click += btnCloseBill_Click;
            // 
            // lblDailyRevenue
            // 
            lblDailyRevenue.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblDailyRevenue.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            lblDailyRevenue.Density = MaterialButton.MaterialButtonDensity.Default;
            lblDailyRevenue.Depth = 0;
            lblDailyRevenue.HighEmphasis = true;
            lblDailyRevenue.Icon = null;
            lblDailyRevenue.IconType = MaterialButton.MaterialIconType.Rebase;
            lblDailyRevenue.Location = new Point(570, 552);
            lblDailyRevenue.Margin = new Padding(5, 8, 5, 8);
            lblDailyRevenue.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblDailyRevenue.Name = "lblDailyRevenue";
            lblDailyRevenue.NoAccentTextColor = Color.Empty;
            lblDailyRevenue.Size = new Size(174, 36);
            lblDailyRevenue.TabIndex = 2;
            lblDailyRevenue.Text = "TOTAL DO DIA: R$ 0,00";
            lblDailyRevenue.Type = MaterialButton.MaterialButtonType.Contained;
            lblDailyRevenue.UseAccentColor = true;
            // 
            // TableMonitorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(lblDailyRevenue);
            Controls.Add(btnCloseBill);
            Controls.Add(splitContainer1);
            Controls.Add(btnClose);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TableMonitorForm";
            Padding = new Padding(3, 85, 3, 4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Monitoramento de Mesas";
            WindowState = FormWindowState.Maximized;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            grpMesas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTables).EndInit();
            grpDetalhes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected MaterialButton lblDailyRevenue;
    }
}