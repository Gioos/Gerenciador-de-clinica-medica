using FluentValidation;
using GerenciadorDeClinica.Application.Models.InputModels;

namespace GerenciadorDeClinica.Application.Validators
{
    public class CreatePacienteValidator : AbstractValidator<CreatePacienteInputModel>
    {
        public CreatePacienteValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(3, 80).WithMessage("O nome deve ter entre 3 e 80 caracteres.");

            RuleFor(p => p.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Length(11).WithMessage("O CPF deve ter 11 caracteres.");

        }
    }
}
