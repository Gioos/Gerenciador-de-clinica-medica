using FluentValidation;
using GerenciadorDeClinica.Application.Models.InputModels;

namespace GerenciadorDeClinica.Application.Validators
{
    public class CreateMedicoValidator : AbstractValidator<CreateMedicoInputModel>
    {
        public CreateMedicoValidator() 
        {
            RuleFor(RuleFor => RuleFor.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(3, 80).WithMessage("O nome deve ter entre 3 e 80 caracteres.");

            RuleFor(m => m.CRM)
                .NotEmpty().WithMessage("O CRM é obrigatório.")
                .Length(5, 10).WithMessage("O CRM deve ter entre 5 e 10 caracteres.");
        }
    }
}
