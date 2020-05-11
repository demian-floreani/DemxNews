using RNN.Models.Services.SitemapService;
using RNN.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace RNN.Services
{
    public interface ISitemapService
    {
        XmlDocument GenerateSitemap(IEnumerable<Page> pages);

        void PingGoogle();
    }
}
