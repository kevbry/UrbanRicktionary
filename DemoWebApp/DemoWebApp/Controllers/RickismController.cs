using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoWebApp.Data;
using DemoWebApp.Models;

namespace DemoWebApp.Controllers
{
    public class RickismController : Controller
    {
        private readonly RicktionaryContext _context;

        public RickismController(RicktionaryContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // GET: Rickism
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rickisms.OrderByDescending(r=>r.Created).ToListAsync());
        }

        // GET: Rickism/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rickism = await _context.Rickisms
                .SingleOrDefaultAsync(m => m.Id == id);
            if (rickism == null)
            {
                return NotFound();
            }

            return View(rickism);
        }

        // GET: Rickism/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rickism/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Term,Definition,Usage")] Rickism rickism)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rickism);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rickism);
        }

        // GET: Rickism/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rickism = await _context.Rickisms.SingleOrDefaultAsync(m => m.Id == id);
            if (rickism == null)
            {
                return NotFound();
            }
            return View(rickism);
        }

        // POST: Rickism/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Term,Definition,Usage")] Rickism rickism)
        {
            if (id != rickism.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rickism);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RickismExists(rickism.Id))
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
            return View(rickism);
        }

        // GET: Rickism/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rickism = await _context.Rickisms
                .SingleOrDefaultAsync(m => m.Id == id);
            if (rickism == null)
            {
                return NotFound();
            }

            return View(rickism);
        }

        // POST: Rickism/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rickism = await _context.Rickisms.SingleOrDefaultAsync(m => m.Id == id);
            _context.Rickisms.Remove(rickism);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RickismExists(int id)
        {
            return _context.Rickisms.Any(e => e.Id == id);
        }
    }
}
