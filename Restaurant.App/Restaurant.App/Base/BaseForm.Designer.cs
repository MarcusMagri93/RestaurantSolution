using System.Windows.Forms;
using ReaLTaiizor.Controls;
using System.Drawing;

namespace Restaurant.App.Base
{
    partial class BaseForm
    {
        private System.ComponentModel.IContainer components = null;

        // Os componentes são declarados como 'protected' para que os filhos possam Herdá-los. 
        protected MaterialTabControl tabControlCadastro;
        protected System.Windows.Forms.TabPage tabPageCadastro;
        protected System.Windows.Forms.TabPage tabPageConsulta;
        protected DataGridView dataGridViewConsulta;
        protected MaterialButton btnSalvar;
        protected MaterialButton btnCancelar;
        protected MaterialButton btnExcluir;

        // Método que limpa os recursos da memória ao fechar o formulário.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // Este método configura todos os controles visuais. 
        // Ele é chamado no construtor da classe BaseForm.cs.
        protected void InitializeComponent()
        {
            tabControlCadastro = new MaterialTabControl();
            tabPageCadastro = new System.Windows.Forms.TabPage();
            tabPageConsulta = new System.Windows.Forms.TabPage();
            dataGridViewConsulta = new DataGridView();
            btnSalvar = new MaterialButton();
            btnCancelar = new MaterialButton();
            btnExcluir = new MaterialButton();
            tabControlCadastro.SuspendLayout();
            tabPageConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewConsulta).BeginInit();
            SuspendLayout();

            // tabControlCadastro
            tabControlCadastro.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlCadastro.Controls.Add(tabPageCadastro);
            tabControlCadastro.Controls.Add(tabPageConsulta);
            tabControlCadastro.Depth = 0;
            tabControlCadastro.Location = new Point(3, 80);
            tabControlCadastro.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            tabControlCadastro.Multiline = true;
            tabControlCadastro.Name = "tabControlCadastro";
            tabControlCadastro.SelectedIndex = 0;
            tabControlCadastro.Size = new Size(794, 665);
            tabControlCadastro.TabIndex = 0;

            // tabPageConsulta
            // Vincula o evento 'Enter' (quando o usuário clica na aba) ao método da classe base.
            tabPageConsulta.Controls.Add(dataGridViewConsulta);
            tabPageConsulta.Location = new Point(4, 29);
            tabPageConsulta.Name = "tabPageConsulta";
            tabPageConsulta.Size = new Size(786, 632);
            tabPageConsulta.TabIndex = 1;
            tabPageConsulta.Text = "Consulta";
            tabPageConsulta.Enter += tabPageConsulta_Enter;

            // dataGridViewConsulta
            dataGridViewConsulta.AllowUserToAddRows = false;
            dataGridViewConsulta.AllowUserToDeleteRows = false;
            dataGridViewConsulta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewConsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewConsulta.Location = new Point(6, 6);
            dataGridViewConsulta.MultiSelect = false;
            dataGridViewConsulta.Name = "dataGridViewConsulta";
            dataGridViewConsulta.ReadOnly = true;
            dataGridViewConsulta.RowHeadersWidth = 51;
            dataGridViewConsulta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewConsulta.Size = new Size(774, 620);
            dataGridViewConsulta.TabIndex = 0;
            // Evento de clique duplo para abrir o modo de edição.
            dataGridViewConsulta.CellDoubleClick += dataGridViewConsulta_CellDoubleClick;

            // btnSalvar
            btnSalvar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalvar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSalvar.Density = MaterialButton.MaterialButtonDensity.Default;
            btnSalvar.Depth = 0;
            btnSalvar.HighEmphasis = true;
            btnSalvar.Location = new Point(600, 30);
            btnSalvar.Margin = new Padding(4, 6, 4, 6);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(76, 36);
            btnSalvar.TabIndex = 1;
            btnSalvar.Text = "Salvar";
            btnSalvar.Type = MaterialButton.MaterialButtonType.Contained;
            btnSalvar.UseAccentColor = false;
            btnSalvar.Click += btnSalvar_Click;

            // Configuração do formulário base (MaterialForm)
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 749);
            Controls.Add(btnExcluir);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Controls.Add(tabControlCadastro);
            Name = "BaseForm";
            Padding = new Padding(3, 80, 3, 3);
            StartPosition = FormStartPosition.CenterScreen;
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