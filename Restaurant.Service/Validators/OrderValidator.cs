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

            // REMOVIDO: A regra que exigia itens ao criar o pedido.
            // Agora permitimos criar o pedido vazio para depois adicionar os itens.
            // RuleFor(c => c.OrderItems)
            //    .NotEmpty().WithMessage("Um pedido deve ter pelo menos um item.");
        }
    }
}