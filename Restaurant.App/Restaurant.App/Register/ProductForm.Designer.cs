using System.Windows.Forms;
using ReaLTaiizor.Controls;

namespace Restaurant.App.Register
{
    // A classe Designer é parcial e deve corresponder à classe principal
    partial class ProductForm
    {
        private System.ComponentModel.IContainer components = null;

        // Componentes específicos para o cadastro de Produto
        protected MaterialTextBoxEdit txtProductName;
        protected MaterialTextBoxEdit txtPrice;
        protected MaterialLabel lblProductName;
        protected MaterialLabel lblPrice;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        protected void InitializeComponent()
        {
            this.txtProductName = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.txtPrice = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.lblProductName = new ReaLTaiizor.Controls.MaterialLabel();
            this.lblPrice = new ReaLTaiizor.Controls.MaterialLabel();

            // CHAME O INITIALIZE COMPONENT DA CLASSE BASE PRIMEIRO!
            // Isso garante que 'tabPageCadastro' seja inicializado antes de ser acessado.
            base.InitializeComponent();

            // Configuração dos controles específicos

            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(50, 50);
            this.lblProductName.Size = new System.Drawing.Size(100, 20);
            this.lblProductName.Text = "Nome do Produto:";
            this.lblProductName.Name = "lblProductName";
            // ADICIONANDO O CONTROLE À TABPAGE DA CLASSE BASE
            this.tabPageCadastro.Controls.Add(this.lblProductName);

            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(50, 75);
            this.txtProductName.Size = new System.Drawing.Size(400, 36);
            this.txtProductName.Name = "txtProductName";
            // ADICIONANDO O CONTROLE À TABPAGE DA CLASSE BASE
            this.tabPageCadastro.Controls.Add(this.txtProductName);

            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(50, 120);
            this.lblPrice.Size = new System.Drawing.Size(50, 20);
            this.lblPrice.Text = "Preço:";
            this.lblPrice.Name = "lblPrice";
            // ADICIONANDO O CONTROLE À TABPAGE DA CLASSE BASE
            this.tabPageCadastro.Controls.Add(this.lblPrice);

            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(50, 145);
            this.txtPrice.Size = new System.Drawing.Size(150, 36);
            this.txtPrice.Name = "txtPrice";
            // ADICIONANDO O CONTROLE À TABPAGE DA CLASSE BASE
            this.tabPageCadastro.Controls.Add(this.txtPrice);

            // Finaliza o layout da TabPage Cadastro
            this.tabPageCadastro.ResumeLayout(false);
            this.tabPageCadastro.PerformLayout();
        }

        #endregion
    }
}