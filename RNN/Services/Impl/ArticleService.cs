using Microsoft.EntityFrameworkCore;
using RNN.Data;
using RNN.Data.Repositories;
using RNN.Models;
using RNN.Models.ViewModels;
using RNN.Models.ViewModels.Data;
using RNN.Services.Impl;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntryRepository _entryRepository;

        public ArticleService(
            IUnitOfWork unitOfWork,
            IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<FullArticle> GetArticleBySlugAsync(string slug)
        {
            var article = _entryRepository
                .FindBy(e => e.Slug.Equals(slug))
                .Select(e => new FullArticle()
                {
                    Id = e.Id,
                    Slug = e.Slug,
                    Author = e.ApplicationUser.DisplayName,
                    Body = e.Body,
                    Caption = e.Caption,
                    Date = e.Date,
                    HeadLine = e.HeadLine,
                    Img = e.Img,
                    PageViews = e.PageViews,
                    Paragraph = e.Paragraph,
                    Url = e.Url,
                    Topics = e.EntryToTopics
                        .Select(et => et.Topic.Name),
                    PrimaryTopic = e.EntryToTopics
                        .Where(et => et.IsPrimary)
                        .Select(et => et.Topic.Name)
                        .FirstOrDefault()
                })
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

        public Task<List<BasicArticle>> GetHeadlineArticles(int top, int offset)
        {
            var task = _entryRepository
                .FindBy(e => e.IsPublished &&
                             !e.IsFeatured)
                .OrderByDescending(a => a.IsPinned)
                    .ThenByDescending(a => a.Date)
                .Skip(offset)
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

        public async Task IncreaseViews(int id)
        {
            var article = _entryRepository
                .FindBy(a => a.Id == id)
                .FirstOrDefault();

            article.PageViews++;

            _entryRepository.Update(article, e => e.PageViews);
            await _unitOfWork.Commit();
        }

        public Task<BasicArticle> GetFeaturedArticle()
        {
            var task = _entryRepository
                .FindBy(a => a.IsFeatured &&
                             a.IsPublished)
                .Select(e => new BasicArticle()
                {
                    HeadLine = e.HeadLine,
                    Img = e.Img,
                    Paragraph = e.Paragraph,
                    Slug = e.Slug,
                    Caption = e.Caption
                })
                .FirstOrDefaultAsync();

            return task;
        }
    }
}
