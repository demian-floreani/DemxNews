using Microsoft.EntityFrameworkCore;
using RNN.Data.Impl;
using RNN.Data.Repositories;
using RNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Data.Repositories.Impl
{
    public class EntryToTopicRepository : Repository<EntryToTopic>, IEntryToTopicRepository
    {
        public EntryToTopicRepository(IUnitOfWork uow) : base(uow) { }

        public async Task<EntryToTopic> FindByKey(int entry, int topic)
        {
            return await FindBy(et => et.EntryId == entry && et.TopicId == topic)
                .FirstOrDefaultAsync();
        }
    }
}
