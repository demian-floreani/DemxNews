using RNN.Data.Impl;
using RNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Data.Repositories.Impl
{
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        public TopicRepository(RNNContext context) : base(context) { }

    }
}
