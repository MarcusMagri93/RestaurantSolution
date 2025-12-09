using FluentValidation;
using Restaurant.Domain.Entities;

namespace Restaurant.Services.Validators
{
    public class FoodValidator : AbstractValidator<Food>
    {
        public FoodValidator()
        {
            // Como Food herda de Product.
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome do prato/comida é obrigatório.");

            RuleFor(c => c.Price)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");

            // Adicione aqui regras específicas para Comida, se houver.
        }
    }
}