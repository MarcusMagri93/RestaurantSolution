using System.Windows.Forms;
using ReaLTaiizor.Controls;

namespace Restaurant.App.Base // Confirme este namespace
{
    partial class BaseForm
    {
        private System.ComponentModel.IContainer components = null;

        // DECLARAÇÃO CORRIGIDA: Usando o nome totalmente qualificado System.Windows.Forms.TabPage
        protected MaterialTabControl tabControlCadastro;
        protected System.Windows.Forms.TabPage tabPageCadastro;
        protected System.Windows.Forms.TabPage tabPageConsulta;
        protected DataGridView dataGridViewConsulta;
        protected MaterialButton btnSalvar;
        protected MaterialButton btnCancelar;
        protected MaterialButton btnNovo;
        protected MaterialButton btnEditar;
        protected MaterialButton btnExcluir;


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
            // INICIALIZAÇÃO CORRIGIDA: Usando o nome totalmente qualificado
            this.tabControlCadastro = new ReaLTaiizor.Controls.MaterialTabControl();
            this.tabPageCadastro = new System.Windows.Forms.TabPage(); // CORRIGIDO
            this.tabPageConsulta = new System.Windows.Forms.TabPage(); // CORRIGIDO
            this.dataGridViewConsulta = new System.Windows.Forms.DataGridView();
            this.btnSalvar = new ReaLTaiizor.Controls.MaterialButton();
            this.btnCancelar = new ReaLTaiizor.Controls.MaterialButton();
            this.btnNovo = new ReaLTaiizor.Controls.MaterialButton();
            this.btnEditar = new ReaLTaiizor.Controls.MaterialButton();
            this.btnExcluir = new ReaLTaiizor.Controls.MaterialButton();

            // Suspender Layout (Melhor prática)
            this.tabControlCadastro.SuspendLayout();
            this.tabPageConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsulta)).BeginInit();
            this.SuspendLayout();

            // 
            // tabControlCadastro
            // 
            this.tabControlCadastro.Controls.Add(this.tabPageCadastro);
            this.tabControlCadastro.Controls.Add(this.tabPageConsulta);
            this.tabControlCadastro.Location = new System.Drawing.Point(3, 64);
            this.tabControlCadastro.Size = new System.Drawing.Size(794, 533);
            this.tabControlCadastro.SelectedIndex = 0;
            this.tabControlCadastro.Name = "tabControlCadastro";
            // 
            // tabPageCadastro
            // 
            this.tabPageCadastro.Location = new System.Drawing.Point(4, 25);
            this.tabPageCadastro.Size = new System.Drawing.Size(786, 504);
            this.tabPageCadastro.Text = "Cadastro";
            this.tabPageCadastro.Name = "tabPageCadastro";
            // 
            // tabPageConsulta
            // 
            this.tabPageConsulta.Controls.Add(this.dataGridViewConsulta);
            this.tabPageConsulta.Controls.Add(this.btnExcluir);
            this.tabPageConsulta.Controls.Add(this.btnEditar);
            this.tabPageConsulta.Controls.Add(this.btnNovo);
            this.tabPageConsulta.Location = new System.Drawing.Point(4, 25);
            this.tabPageConsulta.Size = new System.Drawing.Size(786, 504);
            this.tabPageConsulta.Text = "Consulta";
            this.tabPageConsulta.Name = "tabPageConsulta";
            this.tabPageConsulta.Enter += new System.EventHandler(this.tabPageConsulta_Enter);
            // 
            // dataGridViewConsulta
            // 
            this.dataGridViewConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConsulta.Location = new System.Drawing.Point(6, 44);
            this.dataGridViewConsulta.Size = new System.Drawing.Size(774, 454);
            this.dataGridViewConsulta.Name = "dataGridViewConsulta";
            this.dataGridViewConsulta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewConsulta_CellDoubleClick);
            // 
            // Botões do MaterialForm (Topo)
            // 
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Location = new System.Drawing.Point(600, 20);
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.Name = "btnSalvar";

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(700, 20);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.Name = "btnCancelar";

            // Botões da TabPage Consulta
            // 
            this.btnNovo.Text = "Novo";
            this.btnNovo.Location = new System.Drawing.Point(6, 6);
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.Name = "btnNovo";

            this.btnEditar.Text = "Editar";
            this.btnEditar.Location = new System.Drawing.Point(100, 6);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.btnEditar.Name = "btnEditar";

            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Location = new System.Drawing.Point(200, 6);
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            this.btnExcluir.Name = "btnExcluir";


            // 
            // BaseForm (MaterialForm)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);

            this.Controls.Add(this.tabControlCadastro);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);

            this.Text = "Base Form";

            // Continuar Layout
            this.tabControlCadastro.ResumeLayout(false);
            this.tabPageConsulta.ResumeLayout(false);
            this.tabPageConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}