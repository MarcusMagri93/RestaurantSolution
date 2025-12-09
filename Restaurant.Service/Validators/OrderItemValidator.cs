using FluentValidation;
using Restaurant.Domain.Entities;

namespace Restaurant.Services.Validators
{
    public class OrderItemValidator : AbstractValidator<OrderItem>
    {
        public OrderItemValidator()
        {
            RuleFor(c => c.ProductId)
                .GreaterThan(0).WithMessage("O item deve estar associado a um produto.");

            RuleFor(c => c.Quantity)
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");
        }
    }
}