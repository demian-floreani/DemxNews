using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using RNN.Controllers.Common;
using RNN.Data;
using RNN.Data.Repositories;
using RNN.Exceptions;
using RNN.Messaging;
using RNN.Models;
using RNN.Models.Identity;
using RNN.Models.Services.SitemapService;
using RNN.Models.ViewModels;
using RNN.Models.ViewModels.Containers;
using RNN.Models.ViewModels.Forms;
using RNN.Models.ViewModels.Pages;
using RNN.Models.ViewModels.ViewComponents;
using RNN.Services;

namespace RNN.Controllers
{
    [Authorize]
    public class EntriesController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEntryService _entryService;
        private readonly ITopicService _topicService;
        private readonly ISitemapService _sitemapService;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;

        public EntriesController(
            IWebHostEnvironment environment,
            UserManager<ApplicationUser> userManager,
            IEntryService entryService,
            ITopicService topicService,
            ISitemapService sitemapService,
            IConfiguration configuration,
            IMemoryCache cache) : base(environment)
        {
            _entryService = entryService;
            _topicService = topicService;
            _userManager = userManager;
            _sitemapService = sitemapService;
            _configuration = configuration;
            _cache = cache;
        }

        /// <summary>
        /// List articles belonging to a user
        /// </summary>
        /// <returns></returns>
        [Route("entries/list")]
        [HttpGet]
        public async Task<IActionResult> GetEntries()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var entries = await _entryService.GetEntriesByUserAsync(user.Id);

            return View("List", entries);
        }

        [HttpGet]
        [Route("Entries/Create")]
        public async Task<IActionResult> Create()
        {
            var topics = _topicService
                .GetAllTopics()
                .Select(t => new TopicSelectItem()
                {
                    Id = t.Id,
                    Name = t.Name
                });

            ViewData["TopicItems"] = new SelectList(topics, "Id", "Name");

            ViewData["TopicDataList"] = topics;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnCreate(
            [FromForm] CreateArticle form)
        {
            if (ModelState.IsValid)
            {
                string user = (await _userManager.GetUserAsync(HttpContext.User)).Id;

                Entry article = await _entryService.CreateEntryAsync(form, user);

                return RedirectToRoute(new
                {
                    controller = this.ControllerContext.ActionDescriptor.ControllerName,
                    action = nameof(Edit),
                    id = article.Id
                });
            }

            return RedirectToAction(nameof(Create));
        }


        /// <summary>
        /// Get page to modify an an article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("entries/edit/{id}")]
        public async Task<IActionResult> Edit(
            [FromRoute] int id)
        {
            var article = await _entryService.GetEntryByIdAsync(id);

            if (article == default)
            {
                throw new AppException(ExceptionType.ARTICLE_NOT_FOUND_BY_ID);
            }

            ViewData["Topics"] = article.EntryToTopics.Select(et => et.Topic);

            var topics = _topicService
                .GetAllTopics()
                .Select(t => new TopicSelectItem()
                {
                    Id = t.Id,
                    Name = t.Name
                });

            var selected = article
                .EntryToTopics
                .FirstOrDefault(et => et.IsPrimary)?
                .Topic;

            ViewData["TopicItems"] = new SelectList(topics, "Id", "Name", selected?.Id);
            ViewData["TopicDataList"] = topics;
            ViewData["IsPublished"] = article.IsPublished;
            ViewData["IsPinned"] = article.IsPinned;
            ViewData["IsFeatured"] = article.IsFeatured;

            return View(new EditArticle()
            {
                Id = article.Id,
                HeadLine = article.HeadLine,
                Url = article.Url,
                Body = article.Body,
                Paragraph = article.Paragraph,
                ImgUrl = article.Img,
                Caption = article.Caption
            });
        }

        /// <summary>
        /// Modify an existing article
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnEdit(
            [FromForm] EditArticle form)
        {
            if (ModelState.IsValid)
            {
                var slug = await _entryService.UpdateEntryAsync(form);

                _cache.Remove(slug);

                return RedirectToRoute(new
                {
                    controller = "Entries",
                    action = nameof(EntriesController.Edit),
                    id = form.Id
                });
            }

            return RedirectToAction(nameof(GetEntries));
        }

        /// <summary>
        /// Adds a new topic to entry. Create topic if it doesn't exist.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        public async Task<string> AddTopic(
            [FromBody] AddTopicToEntryRequest request)
        {
            await _entryService.AddTopicAsync(request.EntryId, request.Topic, request.SetPrimary);
            return request.Topic;
        }

        [HttpPut]
        [Route("article/publish")]
        public async Task Publish(int article)
        {
            await _entryService.Publish(article);

            await GenerateSitemap();
        }

        private async Task GenerateSitemap()
        {
            var sitemapPath = Path.Combine(_hostingEnvironment.WebRootPath, "sitemap.xml");

            var sitemap = _sitemapService.GenerateSitemap((await _entryService.GetPublishedEntries())
                .Select(e => new Page()
                {
                    Url = string.Concat("/article/", e.Slug),
                    LastModified = e.LastModified
                }));

            if (sitemap != null)
            {
                sitemap.Save(sitemapPath);
            }
        }

        [HttpPut]
        [Route("article/unpublish")]
        public async Task Unpublish(int article)
        {
            await _entryService.Unpublish(article);
        }

        [HttpGet]
        [Route("article/{article}/topics/")]
        public async Task<IEnumerable<string>> GetTopics(int article)
        {
            var topics = (await _entryService.GetEntryTopics(article));

            return topics.Select(et => et.Name);
        }

        [HttpPut]
        [Route("article/pin")]
        public async Task Pin(int article)
        {
            await _entryService.Pin(article);
        }

        [HttpPut]
        [Route("article/unpin")]
        public async Task UnPin(int article)
        {
            await _entryService.UnPin(article);
        }

        [HttpPut]
        [Route("article/{id}/feature")]
        public async Task Feature(
            [FromRoute] int id)
        {
            await _entryService.Feature(id);
        }

        [HttpPut]
        [Route("article/{id}/unfeature")]
        public async Task UnFeature(
            [FromRoute] int id)
        {
            await _entryService.UnFeature(id);
        }

        [HttpPost]
        [Route("article/body/save")]
        public async Task SaveBodyAsync(
            [FromBody] SynchBodyRequest request)
        {
            
            //var entry = await _entryRepository
            //    .FindBy(e => e.Id == request.EntryId)
            //    .SingleOrDefaultAsync();

            //_entryRepository.Entry(entry).Property(p => p.Body).IsModified = true;

            //await _entryRepository.SaveChangesAsync();
        }
    }
}
