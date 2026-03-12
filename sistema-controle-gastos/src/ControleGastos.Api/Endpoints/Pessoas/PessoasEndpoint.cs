using ControleGastos.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.Api.Endpoints.Pessoas;
public static class PessoasEndpoints
{
    public static IEndpointRouteBuilder MapPessoasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/v1/pessoas")
                       .WithTags("Pessoas");

        group.MapPost("/", CadastrarPessoa)
             .WithName("CadastrarPessoa")
             .Produces<CadastrarPessoaResponse>(StatusCodes.Status201Created)
             .ProducesValidationProblem();

        return app;
    }

    private static async Task<IResult> CadastrarPessoa(
        [FromBody] CadastrarPessoaRequest request,
        IMediator mediator,
        CancellationToken ct)
    {
        var command = new CadastrarPessoaCommand(request.Nome, request.Idade);
        var result = await mediator.Send(command, ct);

        return Results.Created($"/v1/pessoas/{result}", result);
    }
}