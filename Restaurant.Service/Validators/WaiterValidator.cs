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


            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Sua senha não poder ser vazia")
                .MinimumLength(8).WithMessage("Sua senha deve ter no mínimo 8 caracteres.")
                .MaximumLength(16).WithMessage("Sua senha deve ter no máximo 16 caracteres.")
                .Matches(@"[A-Z]+").WithMessage("Sua senha deve conter pelo menos uma letra maiúscula.")
                .Matches(@"[a-z]+").WithMessage("Sua senha deve conter pelo menos uma letra minúscula.")
                .Matches(@"[0-9]+").WithMessage("Sua senha deve conter pelo menos um número.")
                .Matches(@"[\!\?\*\.\@]+").WithMessage("Sua senha deve conter pelo menos um caractere especial (! ? * .).");
        }
    }
}