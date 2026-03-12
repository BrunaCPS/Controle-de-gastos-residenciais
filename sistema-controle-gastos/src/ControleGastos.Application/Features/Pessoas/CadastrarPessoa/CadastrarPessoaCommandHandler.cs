using ControleGastos.Application.Abstractions.Repositories;
using ControleGastos.Domain;
using MediatR;

namespace ControleGastos.Application.Features.Pessoas.CadastrarPessoa;

public sealed class CadastrarPessoaCommandHandler(IRepositoryBase<Pessoa> _pessoaRepository) : IRequestHandler<CadastrarPessoaCommand, CadastrarPessoaResponse>
{
    public async Task<CadastrarPessoaResponse> Handle(CadastrarPessoaCommand request, CancellationToken cancellationToken)
    {
        var pessoa = new Pessoa
        {
            Nome = request.Nome,
            Idade = request.Idade
        };

        await _pessoaRepository.AddAsync(pessoa, cancellationToken);
        await _pessoaRepository.SaveChangesAsync(cancellationToken);

        return new CadastrarPessoaResponse(pessoa);
    }
}