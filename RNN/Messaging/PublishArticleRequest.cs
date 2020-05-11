using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Messaging
{
    public class PublishArticleRequest
    {
        public int EntryId { get; set; }
        public bool IsPublished { get; set; }
    }
}
