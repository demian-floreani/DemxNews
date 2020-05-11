using Microsoft.EntityFrameworkCore;
using RNN.Data;
using RNN.Data.Repositories;
using RNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Services.Impl
{
    public class TopicService : ITopicService
    {
        private ITopicRepository _topicRepository { get; set; }

        public TopicService(
            ITopicRepository topicRepository
            )
        {
            _topicRepository = topicRepository;
        }

        IEnumerable<Topic> ITopicService.GetAllTopics()
        {
            return _topicRepository.QueryAll();
        }

        public Task<Topic> GetById(int topicId)
        {
            return _topicRepository
                .FindBy(t => t.Id == topicId)
                .FirstOrDefaultAsync();
        }
    }
}
