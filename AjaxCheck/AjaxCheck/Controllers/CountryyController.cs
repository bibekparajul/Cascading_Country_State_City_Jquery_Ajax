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
    public class CountryyController : Controller
    {
        private readonly AppDbContext _context;

        public CountryyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Countryy
        public async Task<IActionResult> Index()
        {
            return View(await _context.Countries.ToListAsync());
        }

        // GET: Countryy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryModel = await _context.Countries
                .FirstOrDefaultAsync(m => m.CountryId == id);
            if (countryModel == null)
            {
                return NotFound();
            }

            return View(countryModel);
        }

        // GET: Countryy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Countryy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryId,CountryName")] CountryModel countryModel)
        {

            _context.Add(countryModel);
            await _context.SaveChangesAsync();
            return View();
        }

        // GET: Countryy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryModel = await _context.Countries.FindAsync(id);
            if (countryModel == null)
            {
                return NotFound();
            }
            return View(countryModel);
        }

        // POST: Countryy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CountryId,CountryName")] CountryModel countryModel)
        {
            if (id != countryModel.CountryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryModelExists(countryModel.CountryId))
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
            return View(countryModel);
        }

        // GET: Countryy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryModel = await _context.Countries
                .FirstOrDefaultAsync(m => m.CountryId == id);
            if (countryModel == null)
            {
                return NotFound();
            }

            return View(countryModel);
        }

        // POST: Countryy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countryModel = await _context.Countries.FindAsync(id);
            if (countryModel != null)
            {
                _context.Countries.Remove(countryModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryModelExists(int id)
        {
            return _context.Countries.Any(e => e.CountryId == id);
        }
    }
}
