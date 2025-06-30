using SmartLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartLife.Data;

namespace SmartLife.Controllers
{
    public class SmartLifeClassesController : Controller
    {
        private readonly AppDbContext _context;

        public SmartLifeClassesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SmartLifeClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.SmartLives.ToListAsync());
        }

        // GET: SmartLifeClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smartLifeClass = await _context.SmartLives
                .FirstOrDefaultAsync(m => m.Id == id);
            if (smartLifeClass == null)
            {
                return NotFound();
            }

            return View(smartLifeClass);
        }

        // GET: SmartLifeClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SmartLifeClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Occupation,Money,Mood,Personality,Familybond,LastUpdated")] SmartLifeClass smartLifeClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(smartLifeClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(smartLifeClass);
        }

        // GET: SmartLifeClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smartLifeClass = await _context.SmartLives.FindAsync(id);
            if (smartLifeClass == null)
            {
                return NotFound();
            }
            return View(smartLifeClass);
        }

        // POST: SmartLifeClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Occupation,Money,Mood,Personality,Familybond,LastUpdated")] SmartLifeClass smartLifeClass)
        {
            if (id != smartLifeClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(smartLifeClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SmartLifeClassExists(smartLifeClass.Id))
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
            return View(smartLifeClass);
        }

        // GET: SmartLifeClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smartLifeClass = await _context.SmartLives
                .FirstOrDefaultAsync(m => m.Id == id);
            if (smartLifeClass == null)
            {
                return NotFound();
            }

            return View(smartLifeClass);
        }

        // POST: SmartLifeClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var smartLifeClass = await _context.SmartLives.FindAsync(id);
            if (smartLifeClass != null)
            {
                _context.SmartLives.Remove(smartLifeClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SmartLifeClassExists(int id)
        {
            return _context.SmartLives.Any(e => e.Id == id);
        }
    }
}
