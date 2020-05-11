using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Messaging
{
    public class AddTopicToEntryRequest
    {
        public string Topic { get; set; }
        public int EntryId { get; set; }
        public bool SetPrimary { get; set; }
    }
}
