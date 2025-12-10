using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System; // Adicionado: Essencial para EventArgs
using System.Windows.Forms; // Adicionado: Essencial para MessageBox, DialogResult, DataGridView, etc.

namespace Restaurant.App.Base // Certifique-se que o namespace está correto
{
    public partial class BaseForm : MaterialForm
    {
        #region Declarações
        protected bool IsAlteracao = false;

        #endregion

        #region Construtor
        public BaseForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos form
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Deseja realmente cancelar?", @"Restaurant App", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpaCampos();
                // Componente declarado no BaseForm.Designer.cs
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
            // Componente declarado no BaseForm.Designer.cs
            if (dataGridViewConsulta.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(@"Deseja realmente excluir?", @"Restaurant App", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Obtém o ID da linha selecionada
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
        #endregion

        #region Eventos CRUD
        protected void LimpaCampos()
        {
            IsAlteracao = false;
            // Componente declarado no BaseForm.Designer.cs
            foreach (var control in tabPageCadastro.Controls)
            {
                // Verificação e limpeza de componentes ReaLTaiizor
                if (control is MaterialTextBoxEdit materialTextBoxEdit)
                {
                    materialTextBoxEdit.Clear();
                }
                if (control is MaterialMaskedTextBox materialMaskedTextBox)
                {
                    materialMaskedTextBox.Clear();
                }
            }
        }

        // Métodos virtuais para implementação nas classes filhas
        protected virtual void CarregaGrid()
        {
        }

        protected virtual void Novo()
        {
            LimpaCampos();
            tabControlCadastro.SelectedIndex = 0;
            tabControlCadastro.Focus();
        }

        protected virtual void Salvar()
        {

        }

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

        protected virtual void Deletar(int id)
        {

        }

        // Usa o tipo DataGridViewRow, que exige o 'using System.Windows.Forms'
        protected virtual void CarregaRegistro(DataGridViewRow? linha)
        {

        }

        #endregion
    }
}