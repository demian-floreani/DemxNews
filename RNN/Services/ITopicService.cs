using RNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Services
{
    public interface ITopicService
    {
        IEnumerable<Topic> GetAllTopics();

        Task<Topic> GetById(int topicId);
    }
}
