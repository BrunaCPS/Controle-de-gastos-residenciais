using MediatR;
namespace ControleGastos.Application;

public sealed record CadastrarPessoaCommand(string Nome, int Idade) : IRequest<CadastrarPessoaResponse>;