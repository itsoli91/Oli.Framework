using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Oli.Framework.Core.Dto;

namespace Oli.Framework.Core.Exceptions.Middleware
{
    public static class ExceptionHandlerExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var ex = contextFeature.Error;



                        logger.LogError($"Internal Server Error: {contextFeature.Error}");

                        //if (ex is IApplicationException ||
                        //    ex is IDomainException ||
                        //    ex is IPresentationException)
                        //{
                        //    errorResponse = new ErrorResponseDto(ex.HResult, ex.Message);
                        //}


                        var errorResponse =
                            new ErrorResponseDto(context.Response.StatusCode, "Internal Server Error...");

                        await context.Response.WriteAsync(errorResponse.ToString()).ConfigureAwait(false);
                    }
                });
            });
        }
    }
}