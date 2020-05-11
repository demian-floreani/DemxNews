using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RNN.Models.Services.SitemapService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace RNN.Services.Impl
{
    public class SitemapService : ISitemapService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public SitemapService(
            IWebHostEnvironment hostingEnvironment,
            IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        public XmlDocument GenerateSitemap(IEnumerable<Page> pages)
        {
            if(!_hostingEnvironment.IsProduction())
            {
                return null;
            }

            XmlDocument document = new XmlDocument();

            var urlSet = document.CreateElement("urlset");
            urlSet.SetAttribute("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");

            var root = document.CreateElement("url");

            var rootUrl = _configuration["SiteUrl"];

            root.AppendChild(AddNode(document, "loc", rootUrl));

            urlSet.AppendChild(root);

            foreach (var page in pages)
            {
                var url = document.CreateElement("url");

                url.AppendChild(AddNode(document, "loc", String.Concat(rootUrl, page.Url)));

                if (page.LastModified != null && page.LastModified != DateTime.MinValue)
                {
                    url.AppendChild(AddNode(document, "lastmod", XmlConvert.ToString(page.LastModified, XmlDateTimeSerializationMode.Local)));
                }

                urlSet.AppendChild(url);
            }

            document.AppendChild(document.CreateXmlDeclaration("1.0", "UTF-8", null));
            document.AppendChild(urlSet);

            return document;
        }

        private static XmlElement AddNode(XmlDocument document, string name, string value)
        {
            var node = document.CreateElement(name);

            node.AppendChild(document.CreateTextNode(value));

            return node;
        }

        public void PingGoogle()
        {
            if (!_hostingEnvironment.IsProduction())
            {
                return;
            }

            //var ping = new System.Net.NetworkInformation.Ping();

            //var result = ping.Send("http://www.google.com/ping?sitemap=" + _configuration["SiteUrl"] + "/sitemap.xml");
            
        }
    }
}
