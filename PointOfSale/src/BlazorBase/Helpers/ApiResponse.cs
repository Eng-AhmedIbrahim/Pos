﻿namespace BlazorBase.Helpers;

public class ApiResponse
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }

    public ApiResponse(int statusCode, string? message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }

    private static string? GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "A bad request, you have made",
            401 => "Authorized, you are not",
            404 => "Resource was not found",
            500 => "Errors are the path to the dark side. Errors in code are the path to the dark side",
            _ => null
        };
    }
}
