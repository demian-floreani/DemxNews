using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.Forms
{
    public class EditArticle
    {
        public int Id { get; set; }
        public string HeadLine { get; set; }
        public string Paragraph { get; set; }
        public string ImgUrl { get; set; }
        public IFormFile Img { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
        public int? PrimaryTopic { get; set; }
        public string Caption { get; set; }
    }
}
