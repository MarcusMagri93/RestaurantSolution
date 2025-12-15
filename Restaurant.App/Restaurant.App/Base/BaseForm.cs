using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System;
using System.Windows.Forms;

namespace Restaurant.App.Base
{
    public partial class BaseForm : MaterialForm
    {
        protected bool IsAlteracao = false;

        public BaseForm()
        {
            InitializeComponent();
            // Associa o evento de mudança de aba
            tabControlCadastro.SelectedIndexChanged += TabControlCadastro_SelectedIndexChanged;
        }

        // --- Oculta botões na aba de consulta ---
        private void TabControlCadastro_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Aba 0 = Cadastro (Botões visíveis)
            // Aba 1 = Consulta (Botões invisíveis)
            bool isCadastro = tabControlCadastro.SelectedIndex == 0;

            btnSalvar.Visible = isCadastro;
            btnCancelar.Visible = isCadastro;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Deseja realmente cancelar?", @"Restaurant App", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpaCampos();
                tabControlCadastro.SelectedIndex = 1;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridViewConsulta.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(@"Deseja realmente excluir?", @"Restaurant App", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = (int)dataGridViewConsulta.SelectedRows[0].Cells["Id"].Value;
                    Deletar(id);
                    CarregaGrid();
                }
            }
            else
            {
                MessageBox.Show(@"Selecione algum registro!", @"Restaurant App", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tabPageConsulta_Enter(object sender, EventArgs e)
        {
            CarregaGrid();
        }
        private void dataGridViewConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Editar();
        }

        protected void LimpaCampos()
        {
            IsAlteracao = false;
            foreach (var control in tabPageCadastro.Controls)
            {
                if (control is MaterialTextBoxEdit materialTextBoxEdit) materialTextBoxEdit.Clear();
                if (control is MaterialMaskedTextBox materialMaskedTextBox) materialMaskedTextBox.Clear();
            }
        }

        protected virtual void CarregaGrid() { }
        protected virtual void Novo()
        {
            LimpaCampos();
            tabControlCadastro.SelectedIndex = 0;
            tabControlCadastro.Focus();
        }
        protected virtual void Salvar() { }
        protected virtual void Editar()
        {
            if (dataGridViewConsulta.SelectedRows.Count > 0)
            {
                IsAlteracao = true;
                var linha = dataGridViewConsulta.SelectedRows[0];
                CarregaRegistro(linha);
                tabControlCadastro.SelectedIndex = 0;
                tabControlCadastro.Focus();
            }
            else
            {
                MessageBox.Show(@"Selecione algum registro!", @"Restaurant App", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        protected virtual void Deletar(int id) { }
        protected virtual void CarregaRegistro(DataGridViewRow? linha) { }
    }
}