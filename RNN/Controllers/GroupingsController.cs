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
    public class GroupingsController : Controller
    {
        private readonly RNNContext _context;

        public GroupingsController(RNNContext context)
        {
            _context = context;
        }

        // GET: Groupings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Groupings.ToListAsync());
        }

        // GET: Groupings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grouping = await _context.Groupings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grouping == null)
            {
                return NotFound();
            }

            return View(grouping);
        }

        // GET: Groupings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Groupings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Rank")] Grouping grouping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grouping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grouping);
        }

        // GET: Groupings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grouping = await _context.Groupings.FindAsync(id);
            if (grouping == null)
            {
                return NotFound();
            }
            return View(grouping);
        }

        // POST: Groupings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Rank")] Grouping grouping)
        {
            if (id != grouping.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grouping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupingExists(grouping.Id))
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
            return View(grouping);
        }

        // GET: Groupings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grouping = await _context.Groupings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grouping == null)
            {
                return NotFound();
            }

            return View(grouping);
        }

        // POST: Groupings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grouping = await _context.Groupings.FindAsync(id);
            _context.Groupings.Remove(grouping);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupingExists(int id)
        {
            return _context.Groupings.Any(e => e.Id == id);
        }
    }
}
