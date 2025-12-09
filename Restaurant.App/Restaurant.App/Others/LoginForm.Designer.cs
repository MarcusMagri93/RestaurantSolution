using System.Windows.Forms;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;

namespace Restaurant.App.Others
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        // Componentes de Login
        protected MaterialTextBoxEdit txtRegistration;
        protected MaterialTextBoxEdit txtPassword;
        protected MaterialButton btnLogin;
        protected MaterialLabel lblRegistration;
        protected MaterialLabel lblPassword;

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
            this.txtRegistration = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.txtPassword = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.btnLogin = new ReaLTaiizor.Controls.MaterialButton();
            this.lblRegistration = new ReaLTaiizor.Controls.MaterialLabel();
            this.lblPassword = new ReaLTaiizor.Controls.MaterialLabel();

            this.SuspendLayout();

            // 
            // lblRegistration
            // 
            this.lblRegistration.AutoSize = true;
            this.lblRegistration.Location = new System.Drawing.Point(50, 100);
            this.lblRegistration.Size = new System.Drawing.Size(80, 20);
            this.lblRegistration.Text = "Registro:";
            this.Controls.Add(this.lblRegistration);

            // 
            // txtRegistration
            // 
            this.txtRegistration.Location = new System.Drawing.Point(50, 125);
            this.txtRegistration.Size = new System.Drawing.Size(300, 36);
            this.txtRegistration.Name = "txtRegistration";
            this.Controls.Add(this.txtRegistration);

            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(50, 180);
            this.lblPassword.Size = new System.Drawing.Size(55, 20);
            this.lblPassword.Text = "Senha:";
            this.Controls.Add(this.lblPassword);

            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(50, 205);
            this.txtPassword.Size = new System.Drawing.Size(300, 36);
            this.txtPassword.PasswordChar = '●'; // Esconde a senha
            this.txtPassword.Name = "txtPassword";
            this.Controls.Add(this.txtPassword);

            // 
            // btnLogin
            // 
            this.btnLogin.Text = "Entrar";
            this.btnLogin.Location = new System.Drawing.Point(250, 270);
            this.btnLogin.Size = new System.Drawing.Size(100, 40);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Click += new System.EventHandler(this.LoginButton_Click);
            this.Controls.Add(this.btnLogin);

            // 
            // LoginForm (MaterialForm)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Text = "Acesso ao Restaurante";
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}