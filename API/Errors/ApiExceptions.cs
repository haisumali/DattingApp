using System;

namespace API.Errors;

public class ApiExceptions(int statusCode, string message, string? details)
{
    public int statusCode{get;set;} = statusCode;

    public String Message{get;set;} = message;

    public String? Details{get;set;} = details;

}
