using Restaurant.Domain.Base;

namespace Restaurant.Domain.Entities
{
    public class Waiter : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Registration { get; set; } = string.Empty; // Matrícula ou código de acesso

        // Construtor Vazio (Padrão do Professor)
        public Waiter()
        {
        }

        // Construtor para Criação
        public Waiter(string name, string registration)
        {
            Name = name;
            Registration = registration;
        }

        // Construtor Completo com Id (para Carregamento)
        public Waiter(int id, string name, string registration) : base(id)
        {
            Name = name;
            Registration = registration;
        }
    }
}