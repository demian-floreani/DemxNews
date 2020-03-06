using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RNN.Models;

namespace RNN.Controllers
{
    public class EntryToTopicsController : Controller
    {
        private readonly RNNContext _context;

        public EntryToTopicsController(RNNContext context)
        {
            _context = context;
        }

        // GET: EntryToTopics
        public async Task<IActionResult> Index()
        {
            var rNNContext = _context.EntryToTopics.Include(e => e.Entry).Include(e => e.Topic);
            return View(await rNNContext.ToListAsync());
        }

        // GET: EntryToTopics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entryToTopic = await _context.EntryToTopics
                .Include(e => e.Entry)
                .Include(e => e.Topic)
                .FirstOrDefaultAsync(m => m.TopicId == id);
            if (entryToTopic == null)
            {
                return NotFound();
            }

            return View(entryToTopic);
        }

        // GET: EntryToTopics/Create
        public IActionResult Create()
        {
            ViewData["EntryId"] = new SelectList(_context.Set<Entry>(), "Id", "HeadLine");
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Name");
            return View();
        }

        // POST: EntryToTopics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntryId,TopicId")] EntryToTopic entryToTopic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new EntryToTopic() 
                {
                    EntryId = entryToTopic.EntryId,
                    TopicId = entryToTopic.TopicId,
                    IsPrimary = false
                });

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["EntryId"] = new SelectList(_context.Set<Entry>(), "Id", "Discriminator", entryToTopic.EntryId);
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id", entryToTopic.TopicId);
            return View(entryToTopic);
        }

        // GET: EntryToTopics/Edit/5
        public async Task<IActionResult> Edit(int? entry, int? topic)
        {
            var entryToTopic = await _context.EntryToTopics
                .Include(e => e.Entry)
                .Include(e => e.Topic)
                .FirstOrDefaultAsync(m => m.TopicId == topic && m.EntryId == entry);

            if (entryToTopic == null)
            {
                return NotFound();
            }

            ViewData["EntryId"] = new SelectList(_context.Set<Entry>(), "Id", "Discriminator", entryToTopic.EntryId);
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id", entryToTopic.TopicId);
            ViewData["IsPrimary"] = entryToTopic.IsPrimary;

            return View(entryToTopic);
        }

        // POST: EntryToTopics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntryId,TopicId,IsPrimary")] EntryToTopic entryToTopic)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entryToTopic);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EntryId"] = new SelectList(_context.Set<Entry>(), "Id", "Discriminator", entryToTopic.EntryId);
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id", entryToTopic.TopicId);

            return View(entryToTopic);
        }

        // GET: EntryToTopics/Delete/5
        public async Task<IActionResult> Delete(int? entry, int? topic)
        {
            var entryToTopic = await _context.EntryToTopics
                .Include(e => e.Entry)
                .Include(e => e.Topic)
                .FirstOrDefaultAsync(m => m.TopicId == topic && m.EntryId == entry);
            
            _context.EntryToTopics.Remove(entryToTopic);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: EntryToTopics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entryToTopic = await _context.EntryToTopics.FindAsync(id);
            _context.EntryToTopics.Remove(entryToTopic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntryToTopicExists(int id)
        {
            return _context.EntryToTopics.Any(e => e.TopicId == id);
        }
    }
}
