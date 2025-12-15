using ReaLTaiizor.Controls;
using System.Drawing;

namespace Restaurant.App
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Componentes do menu
        protected MaterialButton btnMenuProduct;
        protected MaterialButton btnMenuListProducts; // <--- NOVO BOTÃO
        protected MaterialButton btnMenuWaiter;
        protected MaterialButton btnMenuOrder;

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
            this.btnMenuProduct = new ReaLTaiizor.Controls.MaterialButton();
            this.btnMenuListProducts = new ReaLTaiizor.Controls.MaterialButton();
            this.btnMenuWaiter = new ReaLTaiizor.Controls.MaterialButton();
            this.btnMenuOrder = new ReaLTaiizor.Controls.MaterialButton();

            this.SuspendLayout();

            // 
            // btnMenuProduct (Cadastrar)
            // 
            this.btnMenuProduct.Text = "Cadastrar Produtos";
            this.btnMenuProduct.Location = new Point(20, 100);
            this.btnMenuProduct.Size = new Size(200, 40);
            this.btnMenuProduct.Click += new System.EventHandler(this.MenuProduct_Click);
            this.Controls.Add(this.btnMenuProduct);

            // 
            // btnMenuListProducts (Listar) - NOVO
            // 
            this.btnMenuListProducts.Text = "Listar Produtos";
            // Posicionado ao lado do cadastro (20 + 200 + 20 de margem = 240)
            this.btnMenuListProducts.Location = new Point(240, 100);
            this.btnMenuListProducts.Size = new Size(200, 40);
            this.btnMenuListProducts.Click += new System.EventHandler(this.MenuListProducts_Click);
            this.Controls.Add(this.btnMenuListProducts);

            // 
            // btnMenuWaiter
            // 
            this.btnMenuWaiter.Text = "Cadastrar Garçons";
            this.btnMenuWaiter.Location = new Point(20, 160);
            this.btnMenuWaiter.Size = new Size(200, 40);
            this.btnMenuWaiter.Click += new System.EventHandler(this.MenuWaiter_Click);
            this.Controls.Add(this.btnMenuWaiter);

            // 
            // btnMenuOrder
            // 
            this.btnMenuOrder.Text = "Gerenciar Pedidos";
            this.btnMenuOrder.Location = new Point(20, 220);
            this.btnMenuOrder.Size = new Size(200, 40);
            this.btnMenuOrder.Click += new System.EventHandler(this.MenuOrder_Click);
            this.Controls.Add(this.btnMenuOrder);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 600);
            this.Text = "Menu Principal";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}