using FluentValidation;
using Restaurant.Domain.Entities; // Garanta que este using está correto

namespace Restaurant.Services.Validators
{
    public class WaiterValidator : AbstractValidator<Waiter>
    {
        public WaiterValidator()
        {
            // Validações obrigatórias
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome do garçom é obrigatório.")
                .Length(5, 100).WithMessage("O nome deve ter entre 5 e 100 caracteres.");

            RuleFor(c => c.Registration)
                .NotEmpty().WithMessage("O número de registro é obrigatório.");


            RuleFor(c => c.Orders)
                .NotNull().WithMessage("A lista de pedidos não pode ser nula.");
        }
    }
}