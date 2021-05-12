using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ShowCase.Exceptions.Handler
{
    public class ExceptionHandler
    {
        public static async Task Handle(HttpContext context)
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature.Error;

            var statusCode = HttpStatusCode.InternalServerError;

            switch (exception)
            {
                case null:
                    context.Response.StatusCode = (int)statusCode;
                    await context.Response.WriteAsJsonAsync(
                        new Error()
                        {
                            Code = 1,
                            Message = "Catch Exception is null"
                        });
                    break;

                case UserException:
                    statusCode = HttpStatusCode.OK;
                    break;
            }

            var error = new Error()
            {
                Code = exception is IError ? ((IError) exception).Code : 0,
                Message = exception.Message

            };

            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsJsonAsync(error);
        }
    }
}
