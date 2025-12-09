using FluentValidation;
using Restaurant.Domain.Entities;

namespace Restaurant.Services.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .Length(3, 50).WithMessage("O nome deve ter entre 3 e 50 caracteres.");

            RuleFor(c => c.Price)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");
        }
    }
}