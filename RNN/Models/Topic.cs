using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public ICollection<SubjectToTopic> SubjectToTopic { get; set; }
        //public ICollection<PostToTopic> PostToTopic { get; set; }
        public ICollection<EntryToTopic> ArticleToTopic { get; set; }

        //public ICollection<OpinionToTopic> OpinionToTopic { get; set; }
    }
}
