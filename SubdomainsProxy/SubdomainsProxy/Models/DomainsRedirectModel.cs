using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubdomainsProxy.Models
{
    public class DomainsRedirectModel
    {
        public class Domain
        {
            public string OriginalUrl { get; set; }
            public string RedirectUrl { get; set; }
        }

        public Domain[] Domains { get; set; }
    }
}
