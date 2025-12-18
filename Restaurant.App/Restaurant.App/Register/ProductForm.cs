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

        public int TabIndexInicial { get; set; } = 0;

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

        // LÓGICA DE INTERFACE DINÂMICA
        // Esconde ou mostra campos dependendo se é Comida ou Bebida
        private void UpdateVisibility()
        {
            bool isFood = radFood.Checked;

            // Campos específicos de Comida (Peso e Ingredientes)
            lblWeight.Visible = isFood;
            txtWeight.Visible = isFood;
            lblIngredients.Visible = isFood;
            txtIngredients.Visible = isFood;

            // Campo específico de Bebida (Volume)
            lblVolume.Visible = !isFood;
            txtVolume.Visible = !isFood;
        }

        protected override void CarregaGrid()
        {
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

                // VALIDAÇÃO DE DUPLICIDADE MANUAL
                var produtosExistentes = _productService.Get<ProductViewModel>();
                bool produtoJaExiste = produtosExistentes.Any(p =>
                    p.Name.Equals(nomeProduto, StringComparison.OrdinalIgnoreCase) &&
                    (!IsAlteracao || p.Id != (int)dataGridViewConsulta.SelectedRows[0].Cells["Id"].Value)
                );

                if (produtoJaExiste)
                {
                    MessageBox.Show($"Já existe um produto chamado '{nomeProduto}'.", "Duplicidade", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // POLIMORFISMO NA PRÁTICA
                // Se Food estiver marcado, usamos o _foodService
                if (radFood.Checked)
                {
                    var food = new Food
                    {
                        Name = nomeProduto,
                        Price = string.IsNullOrEmpty(txtPrice.Text) ? 0 : double.Parse(txtPrice.Text),
                        Weight = string.IsNullOrEmpty(txtWeight.Text) ? 0 : double.Parse(txtWeight.Text),
                        Ingredients = txtIngredients.Text
                    };

                    if (IsAlteracao)
                    {
                        food.Id = (int)dataGridViewConsulta.SelectedRows[0].Cells["Id"].Value;
                        _foodService.Update<Food, ProductViewModel, FoodValidator>(food);
                    }
                    else
                    {
                        _foodService.Add<Food, ProductViewModel, FoodValidator>(food);
                    }
                }
                // Se não, usamos o _drinkService
                else
                {
                    var drink = new Drink
                    {
                        Name = nomeProduto,
                        Price = string.IsNullOrEmpty(txtPrice.Text) ? 0 : double.Parse(txtPrice.Text),
                        Volume = string.IsNullOrEmpty(txtVolume.Text) ? 0 : int.Parse(txtVolume.Text)
                    };

                    if (IsAlteracao)
                    {
                        drink.Id = (int)dataGridViewConsulta.SelectedRows[0].Cells["Id"].Value;
                        _drinkService.Update<Drink, ProductViewModel, DrinkValidator>(drink);
                    }
                    else
                    {
                        _drinkService.Add<Drink, ProductViewModel, DrinkValidator>(drink);
                    }
                }

                LimpaCampos();
                CarregaGrid();
                tabControlCadastro.SelectedIndex = 1;
            }
            catch (ValidationException vex)
            {
                // Erros de validação (preço negativo)
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
                MessageBox.Show("Produto excluído com sucesso!");
            }
            catch (Exception ex)
            {
                // INTEGRIDADE REFERENCIAL:
                // Se o produto já foi vendido o banco impede a exclusão.
                if (ex.InnerException != null && ex.InnerException.Message.Contains("DELETE statement conflicted"))
                {
                    MessageBox.Show("Não é possível excluir este produto pois ele já foi vendido em pedidos anteriores.", "Bloqueio de Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Não foi possível excluir o produto. Detalhes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                CarregaGrid();
            }
        }
    }
}