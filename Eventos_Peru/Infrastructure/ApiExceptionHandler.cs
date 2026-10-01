using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Eventos_Peru.Core.Core.Exceptions;
namespace Eventos_Peru.Infrastructure;
public class ApiExceptionHandler(ILogger<ApiExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        var status = StatusCodes.Status500InternalServerError;
        var message = "No se pudo completar la operación. Revisa el registro del servidor.";
        if (exception is ReglaNegocioException)
        {
            status = StatusCodes.Status400BadRequest;
            message = exception.Message;
        }
        else if (exception is DbUpdateException { InnerException: SqlException sql } && sql.Number is 2601 or 2627 or 547)
        {
            status = StatusCodes.Status409Conflict;
            message = "La operación entra en conflicto con un registro existente o una restricción de la base de datos.";
        }
        if (status == 500) logger.LogError(exception, "Error al procesar {Path}", context.Request.Path);
        context.Response.StatusCode = status;
        await context.Response.WriteAsJsonAsync(new ProblemDetails { Status = status, Title = message }, cancellationToken);
        return true;
    }
}
