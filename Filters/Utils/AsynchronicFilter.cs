using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Filters.Pages;

namespace Filters.Utils
{
    public class AsynchronicFilter : ResultFilterAttribute
    {
        async public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next) 
        {
             if (context.Controller is IndexModel)
            {
                var result = context.Result;
                var ip = context.HttpContext.Connection.RemoteIpAddress.ToString();


                if (result is PageResult)
                {
                    var page = ((PageResult)result);
                    page.ViewData["ip"] = ip;
                }
            }
            await next.Invoke();
        }
    }
}
