using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RNN.Data;
using RNN.Data.Impl;
using RNN.Data.Repositories;
using RNN.Exceptions;
using RNN.Models;
using RNN.Models.ViewModels.Data;
using RNN.Models.ViewModels.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RNN.Services.Impl
{
    public class EntryService : IEntryService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private IEntryRepository _entryRepository { get; set; }
        private ITopicRepository _topicRepository { get; set; }
        private IEntryToTopicRepository _entryToTopicRepository { get; set; }
        private IImageProcessingService _imageProcessingService { get; set; }

        public EntryService(
            IUnitOfWork unitOfWork,
            IEntryRepository entryRepository,
            ITopicRepository topicRepository,
            IEntryToTopicRepository entryToTopicRepository,
            IImageProcessingService imageProcessingService)
        {
            _unitOfWork = unitOfWork;
            _entryRepository = entryRepository;
            _topicRepository = topicRepository;
            _entryToTopicRepository = entryToTopicRepository;
            _imageProcessingService = imageProcessingService;
        }

        public Task<Entry> GetEntryBySlugAsync(string slug)
        {
            var article = _entryRepository
                .FindBy(e => e.Slug == slug)
                .Include(a => a.ApplicationUser)
                .Include(a => a.EntryToTopics)
                    .ThenInclude(et => et.Topic)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return article;
        }

        public Task<Entry> GetEntryByIdAsync(int id)
        {
            var article = _entryRepository
                .FindBy(e => e.Id == id)
                .Include(a => a.ApplicationUser)
                .Include(a => a.EntryToTopics)
                    .ThenInclude(et => et.Topic)
                .FirstOrDefaultAsync();

            return article;
        }

        public async Task<Entry> CreateEntryAsync(CreateArticle form, string user)
        {
            using (var transaction = await _unitOfWork.BeginTransaction())
            {
                try
                {
                    Entry article = new Entry()
                    {
                        HeadLine = form.HeadLine,
                        Slug = GenerateSlug(form.HeadLine),
                        ApplicationUserId = user,
                        Body = form.Body,
                        Date = DateTime.Now,
                        Rank = 0,
                        Url = form.Url,
                        Paragraph = form.Paragraph,
                        Img = form.Img != null ? _imageProcessingService.ProcessFormImage(form.Img) : string.Empty,
                        PageViews = 0,
                        IsPublished = false,
                        IsPinned = 0,
                        Caption = String.Empty,
                        IsFeatured = false,
                        LastModified = DateTime.Now
                    };

                    await _entryRepository.Create(article);
                    await _unitOfWork.Commit();

                    if (!String.IsNullOrEmpty(form.PrimaryTopic))
                    {
                        await AddTopicAsync(article.Id, form.PrimaryTopic, true);
                    }
                    else
                    {
                        throw new AppException(ExceptionType.ARTICLE_CREATION_FAILED);
                    }

                    transaction.Commit();

                    return article;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        
        private static string GenerateSlug(string headline)
        {
            headline = headline.Trim();
            Regex rgx = new Regex("[^a-zA-Z0-9 ]");
            headline = rgx.Replace(headline, "");
            headline = headline.Replace(' ', '-');
            return headline.ToLower();
        }

        public async Task<string> UpdateEntryAsync(EditArticle form)
        {
            var article = await _entryRepository
                .FindBy(e => e.Id == form.Id)
                .Include(e => e.EntryToTopics)
                .FirstOrDefaultAsync();

            var tracker = new EditTracker<Entry>();

            if (article == default)
                throw new AppException(ExceptionType.ARTICLE_NOT_FOUND);

            try
            {
                article.LastModified = DateTime.Now;
                tracker.Track(article => article.LastModified);

                if (article.HeadLine != form.HeadLine)
                {
                    article.HeadLine = form.HeadLine;
                    article.Slug = GenerateSlug(form.HeadLine);
                    tracker.Track(e => e.HeadLine);
                    tracker.Track(e => e.Slug);
                }

                if (article.Paragraph != form.Paragraph)
                {
                    article.Paragraph = form.Paragraph;
                    tracker.Track(e => e.Paragraph);
                }

                if (article.Url != form.Url)
                {
                    article.Url = form.Url;
                    tracker.Track(e => e.Url);
                }

                if (article.Body != form.Body)
                {
                    article.Body = form.Body;
                    tracker.Track(e => e.Body);
                }

                if (form.Img != null)
                {
                    article.Img = _imageProcessingService.ProcessFormImage(form.Img);
                    tracker.Track(e => e.Img);
                }

                if(form.Caption != null)
                {
                    article.Caption = form.Caption;
                    tracker.Track(e => e.Caption);
                }

                _entryRepository.Update(article, tracker);
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new AppException(ExceptionType.ARTICLE_UPDATE_FAILED, ex);
            }

            var topicId = article.EntryToTopics.FirstOrDefault(et => et.IsPrimary)?.TopicId;

            if (topicId == default)
            {
                var existing = await _entryToTopicRepository
                    .FindByKey(article.Id, form.PrimaryTopic.Value);

                if (existing != null)
                {
                    existing.IsPrimary = true;
                    _entryToTopicRepository.Update(existing, e => e.IsPrimary);
                }
                else
                {
                    // what happens if article doesn't have a primary topic
                    // get the form primary topic and set it
                    var primaryTopic = new EntryToTopic()
                    {
                        EntryId = article.Id,
                        TopicId = form.PrimaryTopic.Value,
                        IsPrimary = true
                    };

                    await _entryToTopicRepository.Create(primaryTopic);
                }

                await _unitOfWork.Commit();
            }
            else if (topicId.Value != form.PrimaryTopic.Value)
            {
                using (IDbContextTransaction transaction = await _unitOfWork.BeginTransaction())
                {
                    try
                    {
                        // set new topic as primary
                        var primaryTopic = await _entryToTopicRepository
                            .FindBy(et => et.EntryId == article.Id && et.TopicId == topicId)
                            .FirstOrDefaultAsync();

                        primaryTopic.IsPrimary = false;

                        _entryToTopicRepository.Update(primaryTopic, e => e.IsPrimary);

                        // does this article already have this topic ?
                        var newPrimaryTopic = await _entryToTopicRepository
                            .FindByKey(article.Id, form.PrimaryTopic.Value);

                        if (newPrimaryTopic == default)
                        {
                            await _entryToTopicRepository.Create(new EntryToTopic()
                            {
                                EntryId = article.Id,
                                TopicId = form.PrimaryTopic.Value,
                                IsPrimary = true
                            });
                        }
                        else
                        {
                            newPrimaryTopic.IsPrimary = true;
                            _entryToTopicRepository.Update(newPrimaryTopic, e => e.IsPrimary);
                        }

                        await _unitOfWork.Commit();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }

            return article.Slug;
        }

        /// <summary>
        /// Adds a topic to the entry
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddTopicAsync(int entryId, string topicName, bool primary)
        {
            // find topic with case insensitive
            var topic = await _topicRepository
                .FindBy(t => topicName.Equals(t.Name))
                .FirstOrDefaultAsync();

            if (topic == default)
            {
                var entity = new Topic()
                {
                    Name = topicName
                };

                await _topicRepository.Create(entity);
                await _unitOfWork.Commit();

                await _entryToTopicRepository
                    .Create(new EntryToTopic()
                    {
                        EntryId = entryId,
                        TopicId = entity.Id,
                        IsPrimary = primary
                    });

                await _unitOfWork.Commit();
            }
            else
            {
                var find = await _entryToTopicRepository
                    .FindByKey(entryId, topic.Id);

                if (find != default)
                    throw new AppException(ExceptionType.TOPIC_ALREADY_LINKED_TO_ARTICLE);
                else
                {
                    await _entryToTopicRepository
                        .Create(new EntryToTopic()
                        {
                            EntryId = entryId,
                            TopicId = topic.Id,
                            IsPrimary = primary
                        });

                    await _unitOfWork.Commit();
                }
            }
        }

        public Task<List<Entry>> GetEntriesByUserAsync(string user)
        {
            var entries = _entryRepository
                .FindBy(e => e.ApplicationUserId.Equals(user))
                .OrderByDescending(e => e.IsPinned)
                    .ThenByDescending(e => e.Date)
                .ToListAsync();

            return entries;
        }

        public Task<List<BasicArticle>> GetEntriesByTopicAsync(int topicId)
        {
            var list = _entryRepository
                .FindBy(a => a.EntryToTopics
                             .Any(et => et.TopicId == topicId))
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

            return list;
        }

        /// <summary>
        /// Get articles that share a similar amount of topics
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="exclude"></param>
        /// <param name="similarity">the amount of topics articles must share to show in reccomendations</param>
        /// <returns></returns>
        public Task<List<Entry>> GetReccomendationsAsync(List<int> topics, int exclude, int similarity)
        {
            var task = _entryRepository
                .FindBy(a => a.Id != exclude &&
                             a.EntryToTopics
                             .Count(et => topics
                                          .Contains(et.TopicId)) >= similarity)
                .OrderByDescending(a => a.IsPinned)
                    .ThenByDescending(a => a.Date)
                .Take(5)
                .ToListAsync();

            return task;
        }

        public async Task Publish(int article)
        {
            var entity = await _entryRepository
                .FindBy(e => e.Id == article)
                .FirstOrDefaultAsync();

            entity.IsPublished = true;

            _entryRepository.Update(entity, e => e.IsPublished);

            await _unitOfWork.Commit();
        }

        public async Task Unpublish(int article)
        {
            var entity = await _entryRepository
                .FindBy(e => e.Id == article)
                .FirstOrDefaultAsync();

            entity.IsPublished = false;

            _entryRepository.Update(entity, e => e.IsPublished);

            await _unitOfWork.Commit();
        }

        public async Task Pin(int article)
        {
            var entity = await _entryRepository
                .FindBy(e => e.Id == article)
                .FirstOrDefaultAsync();

            entity.IsPinned = 1;

            _entryRepository.Update(entity, e => e.IsPinned);

            await _unitOfWork.Commit();
        }

        public async Task UnPin(int article)
        {
            var entity = await _entryRepository
                .FindBy(e => e.Id == article)
                .FirstOrDefaultAsync();

            entity.IsPinned = 0;

            _entryRepository.Update(entity, e => e.IsPinned);

            await _unitOfWork.Commit();
        }

        public async Task Feature(int article)
        {
            var entity = await _entryRepository
                .FindBy(e => e.Id == article)
                .FirstOrDefaultAsync();

            entity.IsFeatured = true;

            _entryRepository.Update(entity, e => e.IsFeatured);

            await _unitOfWork.Commit();
        }

        public async Task UnFeature(int article)
        {
            var entity = await _entryRepository
                .FindBy(e => e.Id == article)
                .FirstOrDefaultAsync();

            entity.IsFeatured = false;

            _entryRepository.Update(entity, e => e.IsFeatured);

            await _unitOfWork.Commit();
        }

        public async Task IncreasePageViews(Entry entry)
        {
            entry.PageViews++;
            _entryRepository.Update(entry, e => e.PageViews);
            await _unitOfWork.Commit();
        }

        public Task<List<BasicArticle>> GetHeadlineEntries(int? top = null)
        {
            var task = _entryRepository
                .FindBy(e => e.IsPublished)
                .OrderByDescending(a => a.IsPinned)
                    .ThenByDescending(a => a.Date)
                .Take(top.Value)
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

        public Task<List<BasicArticle>> GetPublishedEntries()
        {
            var task = _entryRepository
                .FindBy(e => e.IsPublished)
                .OrderByDescending(e => e.Date)
                    .ThenByDescending(e => e.Date)
                .AsNoTracking()
                .Select(e => new BasicArticle()
                {
                    Id = e.Id,
                    LastModified = e.LastModified,
                    Slug = e.Slug
                })
                .ToListAsync();

            return task;
        }

        public Task<List<Topic>> GetEntryTopics(int article)
        {
            var task = _entryRepository
                .FindBy(e => e.Id == article)
                .SelectMany(e => e.EntryToTopics)
                .Select(et => et.Topic)
                .AsNoTracking()
                .ToListAsync();

            return task;
        }

        public Task<List<Topic>> GetHeadlineTopics(int top = 5)
        {
            return _entryRepository
                .FindBy(e => e.IsPublished)
                .OrderBy(e => e.IsPinned)
                    .ThenByDescending(e => e.Date)
                .Take(top)
                .SelectMany(e => e.EntryToTopics)
                .Select(et => et.Topic)
                .ToListAsync();
        }
    }
}
