using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System;
using System.Windows.Forms;

namespace Restaurant.App.Base
{
    public partial class BaseForm : MaterialForm
    {
        // IsAlteracao -> false(Novo registro) true(Alteração)
        protected bool IsAlteracao = false;

        public BaseForm()
        {
            InitializeComponent();
            tabControlCadastro.SelectedIndexChanged += TabControlCadastro_SelectedIndexChanged;
        }

        // Cadastro (índice 0) ou Consulta (índice 1).
        private void TabControlCadastro_SelectedIndexChanged(object? sender, EventArgs e)
        {
            bool isCadastro = tabControlCadastro.SelectedIndex == 0;

            btnSalvar.Visible = isCadastro;
            btnCancelar.Visible = isCadastro;

            btnExcluir.Visible = !isCadastro;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        protected virtual void Cancelar()
        {
            if (MessageBox.Show(@"Deseja realmente cancelar?", @"Restaurant App", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpaCampos();
                tabControlCadastro.SelectedIndex = 1; // Retorna para a aba de listagem.
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Verifica se o usuário selecionou uma linha na grade antes de excluir.
            if (dataGridViewConsulta.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(@"Deseja realmente excluir este registro?", @"Restaurant App", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Recupera o ID da linha selecionada para passar ao serviço de deletar.
                    int id = (int)dataGridViewConsulta.SelectedRows[0].Cells["Id"].Value;
                    Deletar(id);
                    CarregaGrid(); // Atualiza a lista após a exclusão.
                }
            }
            else
            {
                MessageBox.Show(@"Selecione um registro na lista para excluir!", @"Restaurant App", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            foreach (Control control in tabPageCadastro.Controls)
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
                CarregaRegistro(linha); // Preenche os campos do cadastro com os dados da linha.
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