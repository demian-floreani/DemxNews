using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models
{
    public class SubjectToTopic
    {
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
