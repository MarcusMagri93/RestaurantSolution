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
        protected MaterialTextBoxEdit txtPassword;
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
            txtWaiterName = new MaterialTextBoxEdit();
            txtRegistration = new MaterialMaskedTextBox();
            lblWaiterName = new MaterialLabel();
            lblRegistration = new MaterialLabel();
            txtPassword = new MaterialTextBoxEdit();
            lblPassword = new MaterialLabel();
            tabControlCadastro.SuspendLayout();
            tabPageCadastro.SuspendLayout();
            SuspendLayout();
            // 
            // tabPageCadastro
            // 
            tabPageCadastro.Controls.Add(lblWaiterName);
            tabPageCadastro.Controls.Add(lblRegistration);
            tabPageCadastro.Controls.Add(txtRegistration);
            tabPageCadastro.Controls.Add(txtWaiterName);
            tabPageCadastro.Controls.Add(lblPassword);
            tabPageCadastro.Controls.Add(txtPassword);
            tabPageCadastro.Size = new Size(691, 396);
            // 
            // txtWaiterName
            // 
            txtWaiterName.AnimateReadOnly = false;
            txtWaiterName.AutoCompleteMode = AutoCompleteMode.None;
            txtWaiterName.AutoCompleteSource = AutoCompleteSource.None;
            txtWaiterName.BackgroundImageLayout = ImageLayout.None;
            txtWaiterName.CharacterCasing = CharacterCasing.Normal;
            txtWaiterName.Depth = 0;
            txtWaiterName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtWaiterName.HideSelection = true;
            txtWaiterName.LeadingIcon = null;
            txtWaiterName.Location = new Point(50, 45);
            txtWaiterName.MaxLength = 32767;
            txtWaiterName.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtWaiterName.Name = "txtWaiterName";
            txtWaiterName.PasswordChar = '\0';
            txtWaiterName.PrefixSuffixText = null;
            txtWaiterName.ReadOnly = false;
            txtWaiterName.RightToLeft = RightToLeft.No;
            txtWaiterName.SelectedText = "";
            txtWaiterName.SelectionLength = 0;
            txtWaiterName.SelectionStart = 0;
            txtWaiterName.ShortcutsEnabled = true;
            txtWaiterName.Size = new Size(400, 48);
            txtWaiterName.TabIndex = 1;
            txtWaiterName.TabStop = false;
            txtWaiterName.TextAlign = HorizontalAlignment.Left;
            txtWaiterName.TrailingIcon = null;
            txtWaiterName.UseSystemPasswordChar = false;
            // 
            // txtRegistration
            // 
            txtRegistration.AllowPromptAsInput = true;
            txtRegistration.AnimateReadOnly = false;
            txtRegistration.AsciiOnly = false;
            txtRegistration.BackgroundImageLayout = ImageLayout.None;
            txtRegistration.BeepOnError = false;
            txtRegistration.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtRegistration.Depth = 0;
            txtRegistration.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtRegistration.HidePromptOnLeave = false;
            txtRegistration.HideSelection = true;
            txtRegistration.InsertKeyMode = InsertKeyMode.Default;
            txtRegistration.LeadingIcon = null;
            txtRegistration.Location = new Point(50, 128);
            txtRegistration.Mask = "";
            txtRegistration.MaxLength = 32767;
            txtRegistration.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtRegistration.Name = "txtRegistration";
            txtRegistration.PasswordChar = '\0';
            txtRegistration.PrefixSuffixText = null;
            txtRegistration.PromptChar = '_';
            txtRegistration.ReadOnly = false;
            txtRegistration.RejectInputOnFirstFailure = false;
            txtRegistration.ResetOnPrompt = true;
            txtRegistration.ResetOnSpace = true;
            txtRegistration.RightToLeft = RightToLeft.No;
            txtRegistration.SelectedText = "";
            txtRegistration.SelectionLength = 0;
            txtRegistration.SelectionStart = 0;
            txtRegistration.ShortcutsEnabled = true;
            txtRegistration.Size = new Size(200, 48);
            txtRegistration.SkipLiterals = true;
            txtRegistration.TabIndex = 3;
            txtRegistration.TabStop = false;
            txtRegistration.TextAlign = HorizontalAlignment.Left;
            txtRegistration.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtRegistration.TrailingIcon = null;
            txtRegistration.UseSystemPasswordChar = false;
            txtRegistration.ValidatingType = null;
            // 
            // lblWaiterName
            // 
            lblWaiterName.AutoSize = true;
            lblWaiterName.Depth = 0;
            lblWaiterName.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblWaiterName.Location = new Point(50, 13);
            lblWaiterName.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblWaiterName.Name = "lblWaiterName";
            lblWaiterName.Size = new Size(129, 19);
            lblWaiterName.TabIndex = 0;
            lblWaiterName.Text = "Nome do Garçom:";
            // 
            // lblRegistration
            // 
            lblRegistration.AutoSize = true;
            lblRegistration.Depth = 0;
            lblRegistration.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRegistration.Location = new Point(50, 106);
            lblRegistration.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblRegistration.Name = "lblRegistration";
            lblRegistration.Size = new Size(106, 19);
            lblRegistration.TabIndex = 2;
            lblRegistration.Text = "Nº de Registro:";
            // 
            // txtPassword
            // 
            txtPassword.AnimateReadOnly = false;
            txtPassword.AutoCompleteMode = AutoCompleteMode.None;
            txtPassword.AutoCompleteSource = AutoCompleteSource.None;
            txtPassword.BackgroundImageLayout = ImageLayout.None;
            txtPassword.CharacterCasing = CharacterCasing.Normal;
            txtPassword.Depth = 0;
            txtPassword.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPassword.HideSelection = true;
            txtPassword.LeadingIcon = null;
            txtPassword.Location = new Point(50, 215);
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
            txtPassword.Size = new Size(200, 48);
            txtPassword.TabIndex = 5;
            txtPassword.TabStop = false;
            txtPassword.TextAlign = HorizontalAlignment.Left;
            txtPassword.TrailingIcon = null;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Depth = 0;
            lblPassword.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPassword.Location = new Point(50, 190);
            lblPassword.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(50, 19);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Senha:";
            // 
            // RegisterWaiterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            ClientSize = new Size(700, 562);
            Location = new Point(0, 0);
            Name = "RegisterWaiterForm";
            Text = "Cadastro de Garçom";
            tabControlCadastro.ResumeLayout(false);
            tabPageCadastro.ResumeLayout(false);
            tabPageCadastro.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}