using ReaLTaiizor.Controls;
using System.Drawing;

namespace Restaurant.App
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected MaterialButton btnMenuProduct;
        protected MaterialButton btnMenuListProducts;
        protected MaterialButton btnMenuWaiter;
        protected MaterialButton btnMenuOrder;
        protected MaterialButton btnMonitor; // <--- NOVO BOTÃO

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
            btnMenuProduct = new MaterialButton();
            btnMenuListProducts = new MaterialButton();
            btnMenuWaiter = new MaterialButton();
            btnMenuOrder = new MaterialButton();
            btnMonitor = new MaterialButton();
            SuspendLayout();
            // 
            // btnMenuProduct
            // 
            btnMenuProduct.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMenuProduct.Density = MaterialButton.MaterialButtonDensity.Default;
            btnMenuProduct.Depth = 0;
            btnMenuProduct.HighEmphasis = true;
            btnMenuProduct.Icon = null;
            btnMenuProduct.IconType = MaterialButton.MaterialIconType.Rebase;
            btnMenuProduct.Location = new Point(20, 125);
            btnMenuProduct.Margin = new Padding(4, 8, 4, 8);
            btnMenuProduct.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnMenuProduct.Name = "btnMenuProduct";
            btnMenuProduct.NoAccentTextColor = Color.Empty;
            btnMenuProduct.Size = new Size(185, 36);
            btnMenuProduct.TabIndex = 0;
            btnMenuProduct.Text = "Cadastrar Produtos";
            btnMenuProduct.Type = MaterialButton.MaterialButtonType.Contained;
            btnMenuProduct.UseAccentColor = false;
            btnMenuProduct.Click += MenuProduct_Click;
            // 
            // btnMenuListProducts
            // 
            btnMenuListProducts.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMenuListProducts.Density = MaterialButton.MaterialButtonDensity.Default;
            btnMenuListProducts.Depth = 0;
            btnMenuListProducts.HighEmphasis = true;
            btnMenuListProducts.Icon = null;
            btnMenuListProducts.IconType = MaterialButton.MaterialIconType.Rebase;
            btnMenuListProducts.Location = new Point(240, 125);
            btnMenuListProducts.Margin = new Padding(4, 8, 4, 8);
            btnMenuListProducts.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnMenuListProducts.Name = "btnMenuListProducts";
            btnMenuListProducts.NoAccentTextColor = Color.Empty;
            btnMenuListProducts.Size = new Size(150, 36);
            btnMenuListProducts.TabIndex = 1;
            btnMenuListProducts.Text = "Listar Produtos";
            btnMenuListProducts.Type = MaterialButton.MaterialButtonType.Contained;
            btnMenuListProducts.UseAccentColor = false;
            btnMenuListProducts.Click += MenuListProducts_Click;
            // 
            // btnMenuWaiter
            // 
            btnMenuWaiter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMenuWaiter.Density = MaterialButton.MaterialButtonDensity.Default;
            btnMenuWaiter.Depth = 0;
            btnMenuWaiter.HighEmphasis = true;
            btnMenuWaiter.Icon = null;
            btnMenuWaiter.IconType = MaterialButton.MaterialIconType.Rebase;
            btnMenuWaiter.Location = new Point(20, 200);
            btnMenuWaiter.Margin = new Padding(4, 8, 4, 8);
            btnMenuWaiter.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnMenuWaiter.Name = "btnMenuWaiter";
            btnMenuWaiter.NoAccentTextColor = Color.Empty;
            btnMenuWaiter.Size = new Size(178, 36);
            btnMenuWaiter.TabIndex = 2;
            btnMenuWaiter.Text = "Cadastrar Garçons";
            btnMenuWaiter.Type = MaterialButton.MaterialButtonType.Contained;
            btnMenuWaiter.UseAccentColor = false;
            btnMenuWaiter.Click += MenuWaiter_Click;
            // 
            // btnMenuOrder
            // 
            btnMenuOrder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMenuOrder.Density = MaterialButton.MaterialButtonDensity.Default;
            btnMenuOrder.Depth = 0;
            btnMenuOrder.HighEmphasis = true;
            btnMenuOrder.Icon = null;
            btnMenuOrder.IconType = MaterialButton.MaterialIconType.Rebase;
            btnMenuOrder.Location = new Point(20, 275);
            btnMenuOrder.Margin = new Padding(4, 8, 4, 8);
            btnMenuOrder.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnMenuOrder.Name = "btnMenuOrder";
            btnMenuOrder.NoAccentTextColor = Color.Empty;
            btnMenuOrder.Size = new Size(165, 36);
            btnMenuOrder.TabIndex = 3;
            btnMenuOrder.Text = "Gerenciar Pedidos";
            btnMenuOrder.Type = MaterialButton.MaterialButtonType.Contained;
            btnMenuOrder.UseAccentColor = false;
            btnMenuOrder.Click += MenuOrder_Click;
            // 
            // btnMonitor
            // 
            btnMonitor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMonitor.Density = MaterialButton.MaterialButtonDensity.Default;
            btnMonitor.Depth = 0;
            btnMonitor.HighEmphasis = true;
            btnMonitor.Icon = null;
            btnMonitor.IconType = MaterialButton.MaterialIconType.Rebase;
            btnMonitor.Location = new Point(20, 350);
            btnMonitor.Margin = new Padding(4, 8, 4, 8);
            btnMonitor.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnMonitor.Name = "btnMonitor";
            btnMonitor.NoAccentTextColor = Color.Empty;
            btnMonitor.Size = new Size(158, 36);
            btnMonitor.TabIndex = 4;
            btnMonitor.Text = "Monitorar Mesas";
            btnMonitor.Type = MaterialButton.MaterialButtonType.Contained;
            btnMonitor.UseAccentColor = false;
            btnMonitor.Click += btnMonitor_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 750);
            Controls.Add(btnMenuProduct);
            Controls.Add(btnMenuListProducts);
            Controls.Add(btnMenuWaiter);
            Controls.Add(btnMenuOrder);
            Controls.Add(btnMonitor);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Padding = new Padding(3, 80, 3, 4);
            Text = "Menu Principal";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}