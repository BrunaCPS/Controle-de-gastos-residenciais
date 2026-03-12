using FluentValidation;

namespace ControleGastos.Application;
public sealed class CadastrarPessoaCommandValidator : AbstractValidator<CadastrarPessoaCommand>
{
    public CadastrarPessoaCommandValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("O nome da pessoa é obrigatório e deve conter no máximo 200 caracteres.");

        RuleFor(x => x.Idade)
            .GreaterThan(0)
            .WithMessage("A idade da pessoa deve ser maior que 0.");
    }
}