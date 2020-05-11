using Microsoft.EntityFrameworkCore;
using RNN.Data.Repositories;
using RNN.Models;
using RNN.Models.ViewModels.Data;
using RNN.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Services
{
    public class ArticleService : IArticleService
    {
        private IEntryRepository _entryRepository { get; set; }

        public ArticleService(
            IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public Task<Entry> GetArticleBySlugAsync(string slug)
        {
            var article = _entryRepository
                .FindBy(e => e.Slug.Equals(slug))
                .Include(a => a.ApplicationUser)
                .Include(a => a.EntryToTopics)
                    .ThenInclude(et => et.Topic)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return article;
        }

        public Task<List<BasicArticle>> GetArticlesByTopicAsync(int topic)
        {
            var task = _entryRepository
                .FindBy(a => a.EntryToTopics
                             .Any(et => et.TopicId == topic))
                .OrderByDescending(a => a.Date)
                .AsNoTracking()
                .Select(e => new BasicArticle()
                {
                    Id = e.Id,
                    HeadLine = e.HeadLine,
                    Img = e.Img,
                    Slug = e.Slug,
                    PrimaryTopic = e.EntryToTopics
                                    .Where(et => et.IsPrimary)
                                    .Select(et => et.Topic.Name)
                                    .FirstOrDefault()
                })
                .ToListAsync();

            return task;
        }

        public Task<List<BasicArticle>> GetReccomendedArticlesAsync(List<int> topics, int exclude, int similarity = 2)
        {
            var task = _entryRepository
                 .FindBy(a => a.Id != exclude &&
                              a.EntryToTopics
                              .Count(et => topics
                                           .Contains(et.TopicId)) >= similarity)
                 .OrderByDescending(a => a.IsPinned)
                     .ThenByDescending(a => a.Date)
                 .Take(5)
                 .Select(e => new BasicArticle()
                 {
                     Slug = e.Slug,
                     HeadLine = e.HeadLine,
                     Img = e.Img
                 })
                 .ToListAsync();

            return task;
        }

        public Task<List<Topic>> GetArticleTopics(int article)
        {
            var task = _entryRepository
                .FindBy(e => e.Id == article)
                .SelectMany(e => e.EntryToTopics)
                .Select(et => et.Topic)
                .AsNoTracking()
                .ToListAsync();

            return task;
        }

        public Task<List<BasicArticle>> GetHeadlineArticles(int top)
        {
            var task = _entryRepository
                .FindBy(e => e.IsPublished)
                .OrderByDescending(a => a.IsPinned)
                    .ThenByDescending(a => a.Date)
                .Take(top)
                .AsNoTracking()
                .Select(e => new BasicArticle
                {
                    Id = e.Id,
                    HeadLine = e.HeadLine,
                    Paragraph = e.Paragraph,
                    Img = e.Img,
                    PrimaryTopic = e.EntryToTopics
                                    .Where(et => et.IsPrimary)
                                    .Select(et => et.Topic.Name)
                                    .FirstOrDefault(),
                    Slug = e.Slug
                })
                .ToListAsync();

            return task;
        }

        public Task<List<Topic>> GetHeadlineTopics(int top)
        {
            return _entryRepository
                .FindBy(e => e.IsPublished)
                .OrderByDescending(e => e.IsPinned)
                    .ThenByDescending(e => e.Date)
                .Take(top)
                .SelectMany(e => e.EntryToTopics)
                .Select(et => et.Topic)
                .ToListAsync();
        }
    }
}
