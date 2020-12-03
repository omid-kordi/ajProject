using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ajWebSite.Common.DTOs;

namespace ajWebSite.API.Modules
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app/*, ILoggerManager logger*/)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        //logger.LogError($"Something went wrong: {contextFeature.Error}");

                        var result = JsonConvert.SerializeObject(new ExceptionDetail()
                        {
                            Code = context.Response.StatusCode,
                            Message = "Internal Server Error.",
//#if DEBUG
                            Detail = contextFeature.Error.Message + ">" + contextFeature.Error.InnerException?.Message
//#endif
                        });
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync(result);
                    }
                });
            });
        }
    }
}
