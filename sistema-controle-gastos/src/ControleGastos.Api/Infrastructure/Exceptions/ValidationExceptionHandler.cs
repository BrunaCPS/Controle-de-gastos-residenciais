using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace ControleGastos.Api.Infrastructure.Exceptions;

public sealed class ValidationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
        {
            return false;
        }

        var errors = validationException.Errors
            .GroupBy(x => x.PropertyName)
            .ToDictionary(
                group => group.Key,
                group => group.Select(x => x.ErrorMessage).Distinct().ToArray());

        var result = Results.ValidationProblem(errors);
        await result.ExecuteAsync(httpContext);

        return true;
    }
}
