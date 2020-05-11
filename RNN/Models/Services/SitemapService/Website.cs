using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.Services.SitemapService
{
    public class Page
    {
        public string Url { get; set; }
        public DateTime LastModified { get; set; }
    }

    public class Website
    {
        public string RootUrl { get; set; }
        public IEnumerable<Page> Pages { get; set; }
    }
}
