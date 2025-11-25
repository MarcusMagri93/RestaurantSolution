using Restaurant.Domain.Base;

namespace Restaurant.Domain.Entities
{
    // Tornamos a classe PUBLIC (resolve o CS0053)
    public class OrderItem : BaseEntity<int>
    {
        // --- Propriedades da Entidade ---
        public int Quantity { get; set; }

        // Propriedade de Navegação: O produto que está sendo pedido.
        // O EF Core criará a chave estrangeira (ProductId) automaticamente.
        public Product Product { get; set; } = default!;

        // Propriedade de Navegação: Referência ao pedido pai.
        // O EF Core criará a chave estrangeira (OrderId) automaticamente.
        public Order Order { get; set; } = default!;

        // Construtor Vazio (Padrão para o Entity Framework Core)
        public OrderItem()
        {
        }

        // Construtor para Criação (Resolve o CS1729)
        // Usado no método Order.AddItem(product, quantity)
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        // --- Lógica de Domínio ---

        // Método CalculateSubtotal (Resolve o CS1061)
        public double CalculateSubtotal()
        {
            // Calcula o preço do item baseado no preço do produto e na quantidade.
            // Assumimos que a entidade Product tem uma propriedade Price pública.
            return Product.Price * Quantity;
        }
    }
}