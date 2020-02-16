using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SubdomainsProxy.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SubdomainsProxy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(
            [FromServices] IConfiguration configuration)
        {
            var model = GetLinksOnServicesFromConfiguration(configuration);
            return View(model);
        }

        private LinksOnServicesViewModel GetLinksOnServicesFromConfiguration(IConfiguration configuration) //todo: add caching
        {
            return configuration.GetSection("LinksOnServices").Get<LinksOnServicesViewModel>();
        }
    }
}
