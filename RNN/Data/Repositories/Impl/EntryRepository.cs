using RNN.Data.Impl;
using RNN.Data.Repositories;
using RNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Data.Repositories.Impl
{
    public class EntryRepository : Repository<Entry>, IEntryRepository
    {
        public EntryRepository(RNNContext context) : base(context) { }
    }
}
