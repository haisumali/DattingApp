using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using API.Errors;

namespace API.MiddleWare;

public class ExceptionMiddleWare(RequestDelegate next, ILogger<ExceptionMiddleWare> logger,
IHostEnvironment env)
{
    public object HttpStatus { get; private set; }

    public async Task InvokeAsync(HttpContext context){

    
    try
    {
        await next(context); 
    }
    catch (Exception ex)
    {
        
    logger.LogError(ex,ex.Message);
        context.Response.ContentType="application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = env.IsDevelopment()
        ? new ApiExceptions(context.Response.StatusCode,ex.Message,ex.StackTrace)
        : new ApiExceptions(context.Response.StatusCode,ex.Message,"Internal server Error");
    
    var options = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
     
     var json = JsonSerializer.Serialize(response,options);
    }
       

    }

}
