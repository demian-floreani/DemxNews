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
        public ICollection<EntryToTopic> EntryToTopics { get; set; }
    }
}
