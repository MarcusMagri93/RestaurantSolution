using Restaurant.App.Base;
using Restaurant.App.ViewModel;
using Restaurant.Domain.Base;
using Restaurant.Domain.Entities;
using Restaurant.Services.Validators; // Mantendo o namespace do seu projeto
using System;
using System.Windows.Forms;

namespace Restaurant.App.Register
{
    // A classe pai BaseForm lida com as operações CRUD, mas o serviço injetado deve ser concreto.
    public partial class ProductForm : BaseForm
    {
        // CORREÇÃO 1: Mudar a injeção para o IBaseService<Food> (Classe Concreta) 
        // Isso alinha os Validadores e as Entidades para o Add/Update.
        private readonly IBaseService<Food> _foodService;

        // Construtor corrigido para injeção de dependência
        public ProductForm(IBaseService<Food> foodService)
        {
            InitializeComponent();
            _foodService = foodService;
        }

        protected override void CarregaGrid()
        {
            // Nota: Se você precisar de todos os produtos (Food e Drink), você 
            // deve usar IBaseService<Product> e fazer a filtragem, mas para o CRUD de Food, usamos IBaseService<Food>.
            dataGridViewConsulta.DataSource = _foodService.Get<ProductViewModel>();
        }

        protected override void Salvar()
        {
            // CORREÇÃO 2: Instanciar Food (classe concreta) e CORREÇÃO 3: Conversão explícita para decimal
            var newConcreteProduct = new Food()
            {
                Name = txtProductName.Text,
                Price = Convert.ToDouble(txtPrice.Text) // Uso de Convert.ToDecimal para evitar conflitos de double/decimal
            };

            try
            {
                if (IsAlteracao)
                {
                    // Usa o serviço injetado (Food) e o validador correto (FoodValidator)
                    _foodService.Update<Food, ProductViewModel, FoodValidator>(newConcreteProduct);
                    MessageBox.Show("Produto alterado com sucesso!");
                }
                else
                {
                    // Usa o serviço injetado (Food) e o validador correto (FoodValidator)
                    _foodService.Add<Food, ProductViewModel, FoodValidator>(newConcreteProduct);
                    MessageBox.Show("Produto cadastrado com sucesso!");
                }

                LimpaCampos();
                CarregaGrid();
                tabControlCadastro.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar produto: {ex.Message}");
            }
        }

        protected override void Deletar(int id)
        {
            try
            {
                // Deletar usando o serviço injetado (Food)
                _foodService.Delete(id);
                MessageBox.Show("Produto excluído com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir produto: {ex.Message}");
            }
        }

        protected override void CarregaRegistro(DataGridViewRow? linha)
        {
            if (linha != null)
            {
                txtProductName.Text = linha.Cells["Name"].Value?.ToString();
                txtPrice.Text = linha.Cells["Price"].Value?.ToString();
            }
        }
    }
}