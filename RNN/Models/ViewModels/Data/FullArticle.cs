using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.Data
{
    public class FullArticle
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Paragraph { get; set; }
        public string Img { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public string HeadLine { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public int PageViews { get; set; }
        public string Caption { get; set; }
        public IEnumerable<string> Topics { get; set; }
        public string PrimaryTopic { get; set; }
    }
}
