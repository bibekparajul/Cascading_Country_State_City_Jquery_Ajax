using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AjaxCheck.Data;
using AjaxCheck.Models;

namespace AjaxCheck.Controllers
{
    public class StatessController : Controller
    {
        private readonly AppDbContext _context;

        public StatessController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Statess
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.States.Include(s => s.Country);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Statess/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statesModel = await _context.States
                .Include(s => s.Country)
                .FirstOrDefaultAsync(m => m.StateId == id);
            if (statesModel == null)
            {
                return NotFound();
            }

            return View(statesModel);
        }

        // GET: Statess/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName");
            return View();
        }

        // POST: Statess/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StateId,StateName,CountryId")] StatesModel statesModel)
        {

            _context.Add(statesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        // GET: Statess/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statesModel = await _context.States.FindAsync(id);
            if (statesModel == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName", statesModel.CountryId);
            return View(statesModel);
        }

        // POST: Statess/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StateId,StateName,CountryId")] StatesModel statesModel)
        {
            if (id != statesModel.StateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatesModelExists(statesModel.StateId))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName", statesModel.CountryId);
            return View(statesModel);
        }

        // GET: Statess/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statesModel = await _context.States
                .Include(s => s.Country)
                .FirstOrDefaultAsync(m => m.StateId == id);
            if (statesModel == null)
            {
                return NotFound();
            }

            return View(statesModel);
        }

        // POST: Statess/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statesModel = await _context.States.FindAsync(id);
            if (statesModel != null)
            {
                _context.States.Remove(statesModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatesModelExists(int id)
        {
            return _context.States.Any(e => e.StateId == id);
        }
    }
}
