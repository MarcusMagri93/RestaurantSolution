using FluentValidation;
using Restaurant.Domain.Entities;

namespace Restaurant.Services.Validators
{
    public class DrinkValidator : AbstractValidator<Drink>
    {
        public DrinkValidator()
        {
            // Como Drink herda de Product, muitas regras são as mesmas.
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome da bebida é obrigatório.");

            RuleFor(c => c.Price)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");

            // Adicione aqui regras específicas para Bebidas, se houver.
        }
    }
}