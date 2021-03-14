using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetWebApi.Error
{
    public enum ApiResponseStatus
    {
        Success= 200,
        Error= 401
    }
    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorWrappingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                var response = new { Status = ApiResponseStatus.Error , Exception= ex};
                
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
