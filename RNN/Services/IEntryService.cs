using RNN.Models;
using RNN.Models.ViewModels;
using RNN.Models.ViewModels.Data;
using RNN.Models.ViewModels.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RNN.Services.Impl.EntryService;

namespace RNN.Services
{
    public interface IEntryService
    {
        Task<Entry> GetEntryBySlugAsync(string slug);

        Task<Entry> GetEntryByIdAsync(int id);

        Task<List<Entry>> GetEntriesByUserAsync(string user);

        Task<List<BasicArticle>> GetEntriesByTopicAsync(int topicId);

        Task<Entry> CreateEntryAsync(CreateArticle form, string user);

        Task<string> UpdateEntryAsync(EditArticle form);

        Task<List<Entry>> GetReccomendationsAsync(List<int> topics, int exclude, int similarity = 2);

        Task AddTopicAsync(int entry, string topic, bool primary);

        Task Publish(int entry);

        Task Unpublish(int entry);

        Task IncreasePageViews(Entry entry);

        Task<List<BasicArticle>> GetHeadlineEntries(int? top = null);

        Task<List<Topic>> GetHeadlineTopics(int top = 5);

        Task Pin(int article);

        Task UnPin(int article);

        Task Feature(int article);

        Task UnFeature(int article);

        Task<List<BasicArticle>> GetPublishedEntries();

        Task<List<Topic>> GetEntryTopics(int article);
    }
}
