using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.Forms
{
    public class CreateArticle
    {
        public string HeadLine { get; set; }
        public string Paragraph { get; set; }
        public IFormFile Img { get; set; }
        public string Body { get; set; }
        public int Rank { get; set; }
        public string PrimaryTopic { get; set; }
        public string Url { get; set; }
    }
}
