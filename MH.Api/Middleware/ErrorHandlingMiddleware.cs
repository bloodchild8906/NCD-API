﻿using System.Net;
using MH.Application.Exception;
using Newtonsoft.Json;
using Serilog;

namespace MH.Api.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
            Log.Error($"Error - {ex}");
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError;
        if (ex is DomainException domEx)
        {
            code = (HttpStatusCode)domEx.ToHttpStatusCode();
        }

        var result = JsonConvert.SerializeObject(new { message = ex.ToString() });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}