using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models
{
    public class ArticleToTopic
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
