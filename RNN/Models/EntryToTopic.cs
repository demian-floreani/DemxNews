using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models
{
    public class EntryToTopic
    {
        public int EntryId { get; set; }
        public Entry Entry { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
