

using System.Linq.Expressions;
using MH.Application.Enum;

namespace MH.Application.Response;

public class Response
{
    public Response() => Expression.Empty();

    public Response(ResponseStatus status, string message)
    {
        Status = status;
        Message = message;
    }

    public ResponseStatus? Status { get; init; }
    public string? Message { get; init; }
}