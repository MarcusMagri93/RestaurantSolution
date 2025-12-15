namespace Restaurant.App.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        // Melhoria Etapa 1: Propriedade para exibir o tipo na lista
        public string Type { get; set; } = string.Empty;
    }
}