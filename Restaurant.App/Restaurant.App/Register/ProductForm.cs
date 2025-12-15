using Restaurant.App.Base;
using Restaurant.App.ViewModel;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Services.Validators;
using System;
using System.Windows.Forms;
using System.Linq;
using FluentValidation;

namespace Restaurant.App.Register
{
    public partial class ProductForm : BaseForm
    {
        private readonly IBaseService<Product> _productService;
        private readonly IBaseService<Food> _foodService;
        private readonly IBaseService<Drink> _drinkService;

        public ProductForm(
            IBaseService<Product> productService,
            IBaseService<Food> foodService,
            IBaseService<Drink> drinkService)
        {
            InitializeComponent();
            _productService = productService;
            _foodService = foodService;
            _drinkService = drinkService;

            UpdateVisibility();
        }

        private void Type_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility();
        }

        private void UpdateVisibility()
        {
            bool isFood = radFood.Checked;

            lblWeight.Visible = isFood;
            txtWeight.Visible = isFood;
            lblIngredients.Visible = isFood;
            txtIngredients.Visible = isFood;

            lblVolume.Visible = !isFood;
            txtVolume.Visible = !isFood;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                this.tabControlCadastro.SelectedIndex = 0;
                LimpaCampos();
                IsAlteracao = false;
                radFood.Checked = true;

                // Força o carregamento da grid para garantir que as colunas novas apareçam
                CarregaGrid();
            }
        }

        protected override void CarregaGrid()
        {
            // Truque para forçar o DataGridView a reconhecer as novas colunas (Type)
            dataGridViewConsulta.DataSource = null;
            dataGridViewConsulta.AutoGenerateColumns = true;
            dataGridViewConsulta.DataSource = _productService.Get<ProductViewModel>();
            dataGridViewConsulta.Refresh();
        }

        protected override void Salvar()
        {
            try
            {
                string nomeProduto = txtProductName.Text.Trim();

                var produtosExistentes = _productService.Get<ProductViewModel>();

                bool produtoJaExiste = produtosExistentes.Any(p =>
                    p.Name.Equals(nomeProduto, StringComparison.OrdinalIgnoreCase) &&
                    (!IsAlteracao || p.Id != (int)dataGridViewConsulta.SelectedRows[0].Cells["Id"].Value)
                );

                if (produtoJaExiste)
                {
                    MessageBox.Show(
                        $"Já existe um produto chamado '{nomeProduto}'.\nO sistema não aceita nomes repetidos.",
                        "Duplicidade Encontrada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (radFood.Checked)
                {
                    var food = new Food
                    {
                        Name = nomeProduto,
                        Price = string.IsNullOrEmpty(txtPrice.Text) ? 0 : double.Parse(txtPrice.Text),
                        Weight = string.IsNullOrEmpty(txtWeight.Text) ? 0 : double.Parse(txtWeight.Text),
                        Ingredients = txtIngredients.Text
                    };

                    if (IsAlteracao && dataGridViewConsulta.SelectedRows.Count > 0)
                        food.Id = (int)dataGridViewConsulta.SelectedRows[0].Cells["Id"].Value;

                    if (IsAlteracao)
                    {
                        _foodService.Update<Food, ProductViewModel, FoodValidator>(food);
                        MessageBox.Show("Prato atualizado!");
                    }
                    else
                    {
                        _foodService.Add<Food, ProductViewModel, FoodValidator>(food);
                        MessageBox.Show("Prato cadastrado!");
                    }
                }
                else
                {
                    var drink = new Drink
                    {
                        Name = nomeProduto,
                        Price = string.IsNullOrEmpty(txtPrice.Text) ? 0 : double.Parse(txtPrice.Text),
                        Volume = string.IsNullOrEmpty(txtVolume.Text) ? 0 : int.Parse(txtVolume.Text)
                    };

                    if (IsAlteracao && dataGridViewConsulta.SelectedRows.Count > 0)
                        drink.Id = (int)dataGridViewConsulta.SelectedRows[0].Cells["Id"].Value;

                    if (IsAlteracao)
                    {
                        _drinkService.Update<Drink, ProductViewModel, DrinkValidator>(drink);
                        MessageBox.Show("Bebida atualizada!");
                    }
                    else
                    {
                        _drinkService.Add<Drink, ProductViewModel, DrinkValidator>(drink);
                        MessageBox.Show("Bebida cadastrada!");
                    }
                }

                LimpaCampos();
                CarregaGrid();
                tabControlCadastro.SelectedIndex = 1;
            }
            catch (ValidationException vex)
            {
                var errors = string.Join("\n", vex.Errors);
                MessageBox.Show(errors, "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("Duplicate entry"))
                {
                    MessageBox.Show("O Banco de Dados bloqueou este cadastro pois o nome já existe.", "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Erro ao salvar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override void Deletar(int id)
        {
            try
            {
                _productService.Delete(id);
                MessageBox.Show("Produto excluído!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir: {ex.Message}");
            }
            finally
            {
                CarregaGrid();
            }
        }

        protected override void CarregaRegistro(DataGridViewRow? linha)
        {
            if (linha != null)
            {
                txtProductName.Text = linha.Cells["Name"].Value?.ToString();
                txtPrice.Text = linha.Cells["Price"].Value?.ToString();

                // Nota: O grid simples pode não ter todas as colunas de Food/Drink (peso/volume),
                // então ao editar, talvez precise buscar o objeto completo pelo ID se quiser preencher tudo.
                // Mas para o nome e preço (básico) já funciona.
            }
        }
    }
}