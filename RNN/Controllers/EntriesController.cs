using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RNN.Models;
using RNN.Models.ViewModels;
using RNN.Models.ViewModels.ViewComponents;

namespace RNN.Controllers
{
    public class EntriesController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly RNNContext _context;

        public EntriesController(RNNContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [Route("Entries/")]
        public async Task<IActionResult> Index()
        {
            return View("List", await _context.Entries.ToListAsync());
        }

        [Route("article/{slug}", Name = "display")]
        public async Task<IActionResult> Display(string slug)
        {
            ViewData["Controller"] = String.Concat(!_environment.IsDevelopment() ? "prod-" : "", this.ControllerContext.ActionDescriptor.ControllerName, ".min.css");

            if (slug == null)
            {
                return NotFound();
            }

            var article = await _context.Entries
                .Include(a => a.Author)
                .Include(a => a.EntryToTopics)
                .ThenInclude(et => et.Topic)
                .FirstOrDefaultAsync(a => a.Slug == slug);

            // find Entries with similar topics
            // get topics linked to article
            var topics = article.EntryToTopics.Select(et => et.Topic);
            // get topic ids
            var topicIds = topics.Select(t => t.Id).ToList();

            var reccomendations = _context.Entries
                                          .Include(a => a.EntryToTopics)
                                          .Where(a => a.EntryToTopics.Any(et => topicIds.Contains(et.Topic.Id)))
                                          .Where(a => a.Id != article.Id)
                                          .OrderByDescending(a => a.Date)
                                          .ToList();

            if (article == null)
            {
                return NotFound();
            }

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

        // GET: Entries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Entries
                .Include(a => a.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        [Route("Entries/Create")]
        // GET: Entries/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name");
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Name");
            return View();
        }

        // POST: Entries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Entries/Create")]
        public async Task<IActionResult> Create([Bind("Slug,TitleId,Paragraph,Img,Body,AuthorId,Rank,Id,HeadLine,Url,GroupingId,TopicId")] CreateArticle form)
        {
            if (ModelState.IsValid)
            {
                string imageName = String.Concat(Guid.NewGuid().ToString(), Path.GetExtension(form.Img.FileName));

                Entry article = new Entry()
                {
                    HeadLine = form.HeadLine,
                    Slug = GenerateSlug(form.HeadLine),
                    AuthorId = form.AuthorId,
                    Body = form.Body,
                    Date = DateTime.Now,
                    Rank = form.Rank,
                    Url = form.Url,
                    Paragraph = form.Paragraph,
                    Img = imageName
                };

                _context.Entries.Add(article);
                int id = await _context.SaveChangesAsync();

                // save image
                var uploads = Path.Combine(_environment.WebRootPath, "images", "uploads", imageName);
                form.Img.CopyTo(new FileStream(uploads, FileMode.Create));

                // link topic to article
                _context.EntryToTopics.Add(new EntryToTopic()
                {
                    TopicId = form.TopicId.Value,
                    EntryId = article.Id,
                    IsPrimary = true
                });

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            //ViewData["GroupingId"] = new SelectList(_context.Groupings, "Id", "Id", article.GroupingId);
            //ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id", article.AuthorId);
            //ViewData["TitleId"] = new SelectList(_context.Titles, "Id", "Id", article.TitleId);
            return View();
        }

        private static string GenerateSlug(string headline)
        {
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

            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", article.AuthorId);
            
            return View(article);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Entries/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("TitleId,Paragraph,Slug,Img,Body,AuthorId,Rank,Id,HeadLine,Url,Date,GroupingId")] Entry article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var entry = _context.Entry(article);
                    entry.State = EntityState.Modified;
                    entry.Property(p => p.PageViews).IsModified = false;
                    entry.Property(p => p.Id).IsModified = false;
                    entry.Property(p => p.Date).IsModified = false;

                    //_context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id", article.AuthorId);

            return View(article);
        }

        // GET: Entries/Delete/5
        [Route("Entries/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            //var articleToTopics = await _context.EntryToTopics.Where(et => et.EntryId == id.Value);


            var article = await _context.Entries.FindAsync(id);
            _context.Entries.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var article = await _context.Entries
            //    .Include(a => a.Grouping)
            //    .Include(a => a.Author)
            //    .Include(a => a.Title)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (article == null)
            //{
            //    return NotFound();
            //}

            //return View(article);
        }

        // POST: Entries/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var article = await _context.Entries.FindAsync(id);
        //    _context.Entries.Remove(article);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool ArticleExists(int id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }
    }
}
