using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels
{
    public class CreateArticle : Entry
    {
        public int? TitleId { get; set; }
        public string Paragraph { get; set; }
        public IFormFile Img { get; set; }
        public string Body { get; set; }
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public int Rank { get; set; }
        public int? TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
