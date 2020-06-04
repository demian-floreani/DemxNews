using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.Data
{
    public class BasicArticle
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Paragraph { get; set; }
        public string Img { get; set; }
        public string HeadLine { get; set; }
        public DateTime LastModified { get; set; }
        public string PrimaryTopic { get; set; }
        public string Caption { get; set; }
    }
}
