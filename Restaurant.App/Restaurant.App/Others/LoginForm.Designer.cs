using System.Windows.Forms;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;

namespace Restaurant.App.Others
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected MaterialTextBoxEdit txtRegistration;
        protected MaterialTextBoxEdit txtPassword;
        protected MaterialButton btnLogin;
        protected MaterialLabel lblRegistration;
        protected MaterialLabel lblPassword;
        protected MaterialButton btnRegister;

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
            txtRegistration = new MaterialTextBoxEdit();
            txtPassword = new MaterialTextBoxEdit();
            btnLogin = new MaterialButton();
            lblRegistration = new MaterialLabel();
            lblPassword = new MaterialLabel();
            btnRegister = new MaterialButton();
            SuspendLayout();
            // 
            // txtRegistration
            // 
            txtRegistration.AnimateReadOnly = false;
            txtRegistration.AutoCompleteMode = AutoCompleteMode.None;
            txtRegistration.AutoCompleteSource = AutoCompleteSource.None;
            txtRegistration.BackgroundImageLayout = ImageLayout.None;
            txtRegistration.CharacterCasing = CharacterCasing.Normal;
            txtRegistration.Depth = 0;
            txtRegistration.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtRegistration.HideSelection = true;
            txtRegistration.LeadingIcon = null;
            txtRegistration.Location = new Point(50, 156);
            txtRegistration.Margin = new Padding(3, 4, 3, 4);
            txtRegistration.MaxLength = 32767;
            txtRegistration.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtRegistration.Name = "txtRegistration";
            txtRegistration.PasswordChar = '\0';
            txtRegistration.PrefixSuffixText = null;
            txtRegistration.ReadOnly = false;
            txtRegistration.RightToLeft = RightToLeft.No;
            txtRegistration.SelectedText = "";
            txtRegistration.SelectionLength = 0;
            txtRegistration.SelectionStart = 0;
            txtRegistration.ShortcutsEnabled = true;
            txtRegistration.Size = new Size(300, 48);
            txtRegistration.TabIndex = 1;
            txtRegistration.TabStop = false;
            txtRegistration.TextAlign = HorizontalAlignment.Left;
            txtRegistration.TrailingIcon = null;
            txtRegistration.UseSystemPasswordChar = false;
            // 
            // txtPassword
            // 
            txtPassword.AnimateReadOnly = false;
            txtPassword.AutoCompleteMode = AutoCompleteMode.None;
            txtPassword.AutoCompleteSource = AutoCompleteSource.None;
            txtPassword.BackgroundImageLayout = ImageLayout.None;
            txtPassword.CharacterCasing = CharacterCasing.Normal;
            txtPassword.Depth = 0;
            txtPassword.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPassword.HideSelection = true;
            txtPassword.LeadingIcon = null;
            txtPassword.Location = new Point(50, 256);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.MaxLength = 32767;
            txtPassword.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PrefixSuffixText = null;
            txtPassword.ReadOnly = false;
            txtPassword.RightToLeft = RightToLeft.No;
            txtPassword.SelectedText = "";
            txtPassword.SelectionLength = 0;
            txtPassword.SelectionStart = 0;
            txtPassword.ShortcutsEnabled = true;
            txtPassword.Size = new Size(300, 48);
            txtPassword.TabIndex = 3;
            txtPassword.TabStop = false;
            txtPassword.TextAlign = HorizontalAlignment.Left;
            txtPassword.TrailingIcon = null;
            txtPassword.UseSystemPasswordChar = false;
            // 
            // btnLogin
            // 
            btnLogin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLogin.Density = MaterialButton.MaterialButtonDensity.Default;
            btnLogin.Depth = 0;
            btnLogin.HighEmphasis = true;
            btnLogin.Icon = null;
            btnLogin.IconType = MaterialButton.MaterialIconType.Rebase;
            btnLogin.Location = new Point(260, 338);
            btnLogin.Margin = new Padding(4, 8, 4, 8);
            btnLogin.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnLogin.Name = "btnLogin";
            btnLogin.NoAccentTextColor = Color.Empty;
            btnLogin.Size = new Size(77, 36);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "ENTRAR";
            btnLogin.Type = MaterialButton.MaterialButtonType.Contained;
            btnLogin.UseAccentColor = false;
            btnLogin.Click += LoginButton_Click;
            // 
            // lblRegistration
            // 
            lblRegistration.AutoSize = true;
            lblRegistration.Depth = 0;
            lblRegistration.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRegistration.Location = new Point(50, 125);
            lblRegistration.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblRegistration.Name = "lblRegistration";
            lblRegistration.Size = new Size(63, 19);
            lblRegistration.TabIndex = 0;
            lblRegistration.Text = "Registro:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Depth = 0;
            lblPassword.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPassword.Location = new Point(50, 225);
            lblPassword.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(50, 19);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Senha:";
            // 
            // btnRegister
            // 
            btnRegister.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRegister.Density = MaterialButton.MaterialButtonDensity.Default;
            btnRegister.Depth = 0;
            btnRegister.HighEmphasis = true;
            btnRegister.Icon = null;
            btnRegister.IconType = MaterialButton.MaterialIconType.Rebase;
            btnRegister.Location = new Point(90, 338);
            btnRegister.Margin = new Padding(4, 8, 4, 8);
            btnRegister.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnRegister.Name = "btnRegister";
            btnRegister.NoAccentTextColor = Color.Empty;
            btnRegister.Size = new Size(106, 36);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "CADASTRAR";
            btnRegister.Type = MaterialButton.MaterialButtonType.Contained;
            btnRegister.UseAccentColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 438);
            Controls.Add(lblRegistration);
            Controls.Add(txtRegistration);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            Padding = new Padding(3, 80, 3, 4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acesso ao Restaurante";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}