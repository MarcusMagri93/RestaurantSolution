using System.Windows.Forms;
using ReaLTaiizor.Controls;

namespace Restaurant.App.Base
{
    partial class BaseForm
    {
        private System.ComponentModel.IContainer components = null;

        // DECLARAÇÃO CORRIGIDA: Usando System.Windows.Forms.TabPage
        protected MaterialTabControl tabControlCadastro;
        protected System.Windows.Forms.TabPage tabPageCadastro; // <--- CORRIGIDO
        protected System.Windows.Forms.TabPage tabPageConsulta; // <--- CORRIGIDO
        protected DataGridView dataGridViewConsulta;
        protected MaterialButton btnSalvar;
        protected MaterialButton btnCancelar;


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
            tabControlCadastro = new MaterialTabControl();
            tabPageCadastro = new System.Windows.Forms.TabPage();
            tabPageConsulta = new System.Windows.Forms.TabPage();
            dataGridViewConsulta = new DataGridView();
            btnSalvar = new MaterialButton();
            btnCancelar = new MaterialButton();
            tabControlCadastro.SuspendLayout();
            tabPageConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewConsulta).BeginInit();
            SuspendLayout();
            // 
            // tabControlCadastro
            // 
            tabControlCadastro.Controls.Add(tabPageCadastro);
            tabControlCadastro.Controls.Add(tabPageConsulta);
            tabControlCadastro.Depth = 0;
            tabControlCadastro.Location = new Point(-1, 136);
            tabControlCadastro.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            tabControlCadastro.Multiline = true;
            tabControlCadastro.Name = "tabControlCadastro";
            tabControlCadastro.SelectedIndex = 0;
            tabControlCadastro.Size = new Size(699, 424);
            tabControlCadastro.TabIndex = 0;
            // 
            // tabPageCadastro
            // 
            tabPageCadastro.Location = new Point(4, 24);
            tabPageCadastro.Name = "tabPageCadastro";
            tabPageCadastro.Size = new Size(687, 472);
            tabPageCadastro.TabIndex = 0;
            tabPageCadastro.Text = "Cadastro";
            // 
            // tabPageConsulta
            // 
            tabPageConsulta.Controls.Add(dataGridViewConsulta);
            tabPageConsulta.Location = new Point(4, 24);
            tabPageConsulta.Name = "tabPageConsulta";
            tabPageConsulta.Size = new Size(691, 396);
            tabPageConsulta.TabIndex = 1;
            tabPageConsulta.Text = "Consulta";
            tabPageConsulta.Enter += tabPageConsulta_Enter;
            // 
            // dataGridViewConsulta
            // 
            dataGridViewConsulta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewConsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewConsulta.Location = new Point(5, 41);
            dataGridViewConsulta.Name = "dataGridViewConsulta";
            dataGridViewConsulta.Size = new Size(681, 350);
            dataGridViewConsulta.TabIndex = 0;
            dataGridViewConsulta.CellDoubleClick += dataGridViewConsulta_CellDoubleClick;
            // 
            // btnSalvar
            // 
            btnSalvar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSalvar.Density = MaterialButton.MaterialButtonDensity.Default;
            btnSalvar.Depth = 0;
            btnSalvar.HighEmphasis = true;
            btnSalvar.Icon = null;
            btnSalvar.IconType = MaterialButton.MaterialIconType.Rebase;
            btnSalvar.Location = new Point(525, 19);
            btnSalvar.Margin = new Padding(4, 6, 4, 6);
            btnSalvar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnSalvar.Name = "btnSalvar";
            btnSalvar.NoAccentTextColor = Color.Empty;
            btnSalvar.Size = new Size(76, 36);
            btnSalvar.TabIndex = 1;
            btnSalvar.Text = "Salvar";
            btnSalvar.Type = MaterialButton.MaterialButtonType.Contained;
            btnSalvar.UseAccentColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancelar.Density = MaterialButton.MaterialButtonDensity.Default;
            btnCancelar.Depth = 0;
            btnCancelar.HighEmphasis = true;
            btnCancelar.Icon = null;
            btnCancelar.IconType = MaterialButton.MaterialIconType.Rebase;
            btnCancelar.Location = new Point(612, 19);
            btnCancelar.Margin = new Padding(4, 6, 4, 6);
            btnCancelar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnCancelar.Name = "btnCancelar";
            btnCancelar.NoAccentTextColor = Color.Empty;
            btnCancelar.Size = new Size(96, 36);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Type = MaterialButton.MaterialButtonType.Contained;
            btnCancelar.UseAccentColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 562);
            Controls.Add(tabControlCadastro);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Name = "BaseForm";
            Padding = new Padding(3, 60, 3, 3);
            Text = "Base Form";
            tabControlCadastro.ResumeLayout(false);
            tabPageConsulta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewConsulta).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
    }
}