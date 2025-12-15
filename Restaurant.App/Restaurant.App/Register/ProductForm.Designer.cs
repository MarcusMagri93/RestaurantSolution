using System.Windows.Forms;
using ReaLTaiizor.Controls;

namespace Restaurant.App.Register
{
    partial class ProductForm
    {
        private System.ComponentModel.IContainer components = null;

        // Componentes Padrão
        protected MaterialTextBoxEdit txtProductName;
        protected MaterialTextBoxEdit txtPrice;
        protected MaterialLabel lblProductName;
        protected MaterialLabel lblPrice;

        // Novos Componentes (Radio e Específicos)
        protected MaterialRadioButton radFood;
        protected MaterialRadioButton radDrink;
        protected MaterialLabel lblType;
        protected MaterialTextBoxEdit txtWeight;
        protected MaterialLabel lblWeight;
        protected MaterialTextBoxEdit txtIngredients;
        protected MaterialLabel lblIngredients;
        protected MaterialTextBoxEdit txtVolume;
        protected MaterialLabel lblVolume;

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
            this.radFood = new ReaLTaiizor.Controls.MaterialRadioButton();
            this.radDrink = new ReaLTaiizor.Controls.MaterialRadioButton();
            this.lblType = new ReaLTaiizor.Controls.MaterialLabel();
            this.txtWeight = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.lblWeight = new ReaLTaiizor.Controls.MaterialLabel();
            this.txtIngredients = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.lblIngredients = new ReaLTaiizor.Controls.MaterialLabel();
            this.txtVolume = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.lblVolume = new ReaLTaiizor.Controls.MaterialLabel();

            // IMPORTANTE: NÃO CHAME base.InitializeComponent() AQUI.
            // O construtor do BaseForm já o chamou. Chamar de novo causa erros visuais.

            this.tabPageCadastro.SuspendLayout();
            this.SuspendLayout();

            // 1. Título da Janela
            this.Text = "Cadastro de Produtos"; // <--- Corrige o nome "Base Form"

            // 2. SELEÇÃO DE TIPO
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(50, 20);
            this.lblType.Text = "Tipo de Produto:";
            this.tabPageCadastro.Controls.Add(this.lblType);

            this.radFood.AutoSize = true;
            this.radFood.Location = new System.Drawing.Point(50, 45);
            this.radFood.Text = "Comida (Prato)";
            this.radFood.Checked = true;
            this.radFood.CheckedChanged += new System.EventHandler(this.Type_CheckedChanged);
            this.tabPageCadastro.Controls.Add(this.radFood);

            this.radDrink.AutoSize = true;
            this.radDrink.Location = new System.Drawing.Point(200, 45);
            this.radDrink.Text = "Bebida";
            this.radDrink.CheckedChanged += new System.EventHandler(this.Type_CheckedChanged);
            this.tabPageCadastro.Controls.Add(this.radDrink);

            // 3. CAMPOS COMUNS
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(50, 90);
            this.lblProductName.Text = "Nome:";
            this.tabPageCadastro.Controls.Add(this.lblProductName);

            this.txtProductName.Location = new System.Drawing.Point(50, 115);
            this.txtProductName.Size = new System.Drawing.Size(400, 36);
            this.tabPageCadastro.Controls.Add(this.txtProductName);

            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(470, 90);
            this.lblPrice.Text = "Preço (R$):";
            this.tabPageCadastro.Controls.Add(this.lblPrice);

            this.txtPrice.Location = new System.Drawing.Point(470, 115);
            this.txtPrice.Size = new System.Drawing.Size(150, 36);
            this.tabPageCadastro.Controls.Add(this.txtPrice);

            // 4. CAMPOS DE COMIDA
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(50, 170);
            this.lblWeight.Text = "Peso (kg):";
            this.tabPageCadastro.Controls.Add(this.lblWeight);

            this.txtWeight.Location = new System.Drawing.Point(50, 195);
            this.txtWeight.Size = new System.Drawing.Size(150, 36);
            this.tabPageCadastro.Controls.Add(this.txtWeight);

            this.lblIngredients.AutoSize = true;
            this.lblIngredients.Location = new System.Drawing.Point(220, 170);
            this.lblIngredients.Text = "Ingredientes:";
            this.tabPageCadastro.Controls.Add(this.lblIngredients);

            this.txtIngredients.Location = new System.Drawing.Point(220, 195);
            this.txtIngredients.Size = new System.Drawing.Size(400, 36);
            this.tabPageCadastro.Controls.Add(this.txtIngredients);

            // 5. CAMPOS DE BEBIDA (Invisíveis inicialmente)
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(50, 170);
            this.lblVolume.Text = "Volume (ml):";
            this.lblVolume.Visible = false;
            this.tabPageCadastro.Controls.Add(this.lblVolume);

            this.txtVolume.Location = new System.Drawing.Point(50, 195);
            this.txtVolume.Size = new System.Drawing.Size(150, 36);
            this.txtVolume.Visible = false;
            this.tabPageCadastro.Controls.Add(this.txtVolume);

            this.tabPageCadastro.ResumeLayout(false);
            this.tabPageCadastro.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}