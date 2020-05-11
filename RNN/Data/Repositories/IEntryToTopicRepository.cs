using RNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Data.Repositories
{
    public interface IEntryToTopicRepository : IRepository<EntryToTopic>
    {
        Task<EntryToTopic> FindByKey(int entry, int topic);
    }
}
