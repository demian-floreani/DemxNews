using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Messaging
{
    public class SynchBodyRequest
    {
        public int EntryId { get; set; }
        public string Body { get; set; }
    }
}
