using RNN.Models;
using RNN.Models.ViewModels;
using RNN.Models.ViewModels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Services.Impl
{
    public interface IArticleService
    {
        Task<Entry> GetArticleBySlugAsync(string slug);
        Task<List<BasicArticle>> GetReccomendedArticlesAsync(List<int> topics, int exclude, int similarity = 2);
        Task<List<BasicArticle>> GetArticlesByTopicAsync(int topic);
        Task<List<Topic>> GetArticleTopics(int article);
        Task<List<BasicArticle>> GetHeadlineArticles(int top);
        Task<List<Topic>> GetHeadlineTopics(int top);
    }
}
