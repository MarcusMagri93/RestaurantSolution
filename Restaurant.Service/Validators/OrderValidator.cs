using FluentValidation;
using Restaurant.Domain.Entities;

namespace Restaurant.Services.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(c => c.TableNumber)
                .GreaterThan(0).WithMessage("O número da mesa deve ser válido.");

            RuleFor(c => c.WaiterId)
                .GreaterThan(0).WithMessage("O pedido deve estar associado a um garçom.");

            // Regra mais complexa: A lista de OrderItems não pode estar vazia.
            RuleFor(c => c.OrderItems)
                .NotEmpty().WithMessage("Um pedido deve ter pelo menos um item.");
        }
    }
}