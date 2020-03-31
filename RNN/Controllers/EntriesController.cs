using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RNN.Controllers.Common;
using RNN.Models;
using RNN.Models.Identity;
using RNN.Models.ViewModels;
using RNN.Models.ViewModels.ViewComponents;
using RNN.Services;

namespace RNN.Controllers
{
    [Authorize]
    public class EntriesController : BaseController
    {
        private readonly RNNContext _context;
        private readonly IImageProcessingService _imageProcessing;
        private readonly UserManager<ApplicationUser> _userManager;

        public EntriesController(
            RNNContext context, 
            IHostingEnvironment environment,
            IImageProcessingService imageProcessing,
            UserManager<ApplicationUser> userManager) : base(environment)
        {
            _userManager = userManager;
            _context = context;
            _imageProcessing = imageProcessing;
        }

        [Route("Entries/List")]
        [HttpGet]
        public async Task<IActionResult> GetEntries()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var entries = await _context.Entries
                                        .Where(e => e.ApplicationUserId.Equals(user.Id))
                                        .ToListAsync();

            return View("List", entries);
        }

        /// <summary>
        /// Display an article
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        [Route("article/{slug}", Name = "display")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get(string slug)
        {
            var article = await _context.Entries
                .Include(a => a.ApplicationUser)
                .Include(a => a.EntryToTopics)
                .ThenInclude(et => et.Topic)
                .FirstOrDefaultAsync(a => a.Slug == slug);

            // find Entries with similar topics
            // get topics linked to article
            var topics = article.EntryToTopics.Select(et => et.Topic);
            // get topic ids
            var topicIds = topics.Select(t => t.Id).ToList();

            var reccomendations = await _context.Entries
                                          .Include(a => a.EntryToTopics)
                                          .Where(a => a.EntryToTopics.Any(et => topicIds.Contains(et.Topic.Id)))
                                          .Where(a => a.Id != article.Id)
                                          .OrderByDescending(a => a.Date)
                                          .AsNoTracking()
                                          .ToListAsync();

            DisplayArticle model = new DisplayArticle()
            {
                Article = article,
                Topics = topics,
                Reccomendations = reccomendations.Select(r => ReccomendationBlockViewComponent.ToViewModel(r))
            };

            ViewData["OGTitle"] = article.HeadLine;
            ViewData["OGDescription"] = article.Paragraph;
            ViewData["OGImage"] = "https://www.renegadenews.net/images/uploads/" + article.Img;
            ViewData["OGUrl"] = "https://www.renegadenews.net/Article/" + article.Slug;

            // update page view
            article.PageViews++;
            _context.Entry(article).Property(p => p.PageViews).IsModified = true;
            await _context.SaveChangesAsync();

            return View("Index", model);
        }

        [Route("Entries/Create")]
        // GET: Entries/Create
        public IActionResult Create()
        {
            //ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name");
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Entries/Create")]
        public async Task<IActionResult> Create(CreateArticle form)
        {
            if (ModelState.IsValid)
            {
                var article = new Entry()
                {
                    HeadLine = form.HeadLine,
                    Slug = GenerateSlug(form.HeadLine),
                    ApplicationUserId = (await _userManager.GetUserAsync(HttpContext.User)).Id,
                    Body = form.Body,
                    Date = DateTime.Now,
                    Rank = form.Rank,
                    Url = form.Url,
                    Paragraph = form.Paragraph,
                    Img = _imageProcessing.ProcessFormImage(form.Img),
                    PageViews = 0
                };

                _context.Entries.Add(article);
                await _context.SaveChangesAsync();

                // link topic to article
                _context.EntryToTopics.Add(new EntryToTopic()
                {
                    TopicId = form.TopicId.Value,
                    EntryId = article.Id,
                    IsPrimary = true
                });

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(GetEntries));
            }
            
            //ViewData["GroupingId"] = new SelectList(_context.Groupings, "Id", "Id", article.GroupingId);
            //ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id", article.AuthorId);
            //ViewData["TitleId"] = new SelectList(_context.Titles, "Id", "Id", article.TitleId);
            return View();
        }

        private static string GenerateSlug(string headline)
        {
            headline = headline.Trim();
            Regex rgx = new Regex("[^a-zA-Z0-9 ]");
            headline = rgx.Replace(headline, "");
            headline = headline.Replace(' ', '-');
            return headline.ToLower();
        }

        [Route("Entries/Edit/{id}")]
        // GET: Entries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Entries.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }
            
            return View(new EditArticle() 
            {
                HeadLine = article.HeadLine,
                Url = article.Url,
                Body = article.Body,
                Paragraph = article.Paragraph
            });
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Entries/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, EditArticle form)
        {
            if (id != form.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var article = await _context.Entries.FirstOrDefaultAsync(e => e.Id == id);

                    if (article == null)
                        return NotFound();

                    article.HeadLine = form.HeadLine;
                    article.Paragraph = form.Paragraph;
                    article.Slug = GenerateSlug(form.HeadLine);
                    article.Url = form.Url;
                    article.Body = form.Body;

                    if(form.Img != null)
                    {
                        article.Img = _imageProcessing.ProcessFormImage(form.Img);
                    }

                    var entry = _context.Entry(article);
                    entry.State = EntityState.Modified;

                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(GetEntries));
            }

            return RedirectToAction(nameof(GetEntries));
        }

        private bool Exists(int id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }
    }
}
