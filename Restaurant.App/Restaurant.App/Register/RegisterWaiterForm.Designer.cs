using System.Windows.Forms;
using ReaLTaiizor.Controls;

namespace Restaurant.App.Register
{
    // A classe Designer deve herdar do BaseForm (que é MaterialForm)
    partial class RegisterWaiterForm
    {
        private System.ComponentModel.IContainer components = null;

        // Componentes específicos para o cadastro de Garçom
        protected MaterialTextBoxEdit txtWaiterName;
        protected MaterialMaskedTextBox txtRegistration;
        protected MaterialLabel lblWaiterName;
        protected MaterialLabel lblRegistration;

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
            this.txtWaiterName = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.txtRegistration = new ReaLTaiizor.Controls.MaterialMaskedTextBox();
            this.lblWaiterName = new ReaLTaiizor.Controls.MaterialLabel();
            this.lblRegistration = new ReaLTaiizor.Controls.MaterialLabel();

            // Chamada do InitializeComponent da classe base (que configura o tabControl, botões, etc.)
            base.InitializeComponent();

            // Configuração dos controles específicos
            // 
            // lblWaiterName
            // 
            this.lblWaiterName.AutoSize = true;
            this.lblWaiterName.Location = new System.Drawing.Point(50, 50);
            this.lblWaiterName.Size = new System.Drawing.Size(100, 20);
            this.lblWaiterName.Text = "Nome do Garçom:";
            this.lblWaiterName.Name = "lblWaiterName";
            this.tabPageCadastro.Controls.Add(this.lblWaiterName);
            // 
            // txtWaiterName
            // 
            this.txtWaiterName.Location = new System.Drawing.Point(50, 75);
            this.txtWaiterName.Size = new System.Drawing.Size(400, 36);
            this.txtWaiterName.Name = "txtWaiterName";
            this.tabPageCadastro.Controls.Add(this.txtWaiterName);
            // 
            // lblRegistration
            // 
            this.lblRegistration.AutoSize = true;
            this.lblRegistration.Location = new System.Drawing.Point(50, 120);
            this.lblRegistration.Size = new System.Drawing.Size(120, 20);
            this.lblRegistration.Text = "Nº de Registro:";
            this.lblRegistration.Name = "lblRegistration";
            this.tabPageCadastro.Controls.Add(this.lblRegistration);
            // 
            // txtRegistration
            // 
            this.txtRegistration.Location = new System.Drawing.Point(50, 145);
            this.txtRegistration.Size = new System.Drawing.Size(200, 36);
            this.txtRegistration.Name = "txtRegistration";
            this.tabPageCadastro.Controls.Add(this.txtRegistration);

            this.tabPageCadastro.ResumeLayout(false);
            this.tabPageCadastro.PerformLayout();
        }

        #endregion
    }
}