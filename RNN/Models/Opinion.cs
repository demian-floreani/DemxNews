using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models
{
    public class Opinion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Paragraph { get; set; }
        public string Img { get; set; }
        public string Body { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public bool IsFeatured { get; set; }

        public ICollection<OpinionToTopic> OpinionToTopic { get; set; }
    }
}
