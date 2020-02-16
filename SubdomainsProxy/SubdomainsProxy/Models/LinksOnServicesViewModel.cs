namespace SubdomainsProxy.Models
{
    public class LinksOnServicesViewModel
    {
        public class Link {
            public string Uri { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool Enabled { get; set; }
        }

        public Link[] Links { get; set; } 
    }
}
