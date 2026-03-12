namespace ControleGastos.Application;
public sealed record CadastrarPessoaRequest(
    string Nome,
    int Idade
);