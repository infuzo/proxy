using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SubdomainsProxy.Models;

namespace SubdomainsProxy.Middlewares
{
    public class SubdomainsMiddleware
    {
        private readonly RequestDelegate next;

        public SubdomainsMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
        {
            var stringUrl = context.Request.GetDisplayUrl();
            var domainsToRedirect = configuration.GetSection("DomainsToRedirect").Get<DomainsRedirectModel>();
            foreach(var domain in domainsToRedirect.Domains)
            {
                if (stringUrl.StartsWith(domain.OriginalUrl))
                {
                    context.Response.Redirect(domain.RedirectUrl, false);
                    return;
                }
            }

            await next.Invoke(context);
        }
    }
}
