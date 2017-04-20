using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EurecertV2.Data;
using EurecertV2.Models;
using Microsoft.AspNetCore.Authorization;

namespace EurecertV2.Controllers
{
    [Authorize]
    public class MarketingMethodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarketingMethodsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: MarketingMethods
        public async Task<IActionResult> Index()
        {
            return View(await _context.MarketingMethods.ToListAsync());
        }

        // GET: MarketingMethods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marketingMethod = await _context.MarketingMethods
                .SingleOrDefaultAsync(m => m.Id == id);
            if (marketingMethod == null)
            {
                return NotFound();
            }

            return View(marketingMethod);
        }

        // GET: MarketingMethods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarketingMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] MarketingMethod marketingMethod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marketingMethod);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(marketingMethod);
        }

        // GET: MarketingMethods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marketingMethod = await _context.MarketingMethods.SingleOrDefaultAsync(m => m.Id == id);
            if (marketingMethod == null)
            {
                return NotFound();
            }
            return View(marketingMethod);
        }

        // POST: MarketingMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] MarketingMethod marketingMethod)
        {
            if (id != marketingMethod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marketingMethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarketingMethodExists(marketingMethod.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(marketingMethod);
        }

        // GET: MarketingMethods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marketingMethod = await _context.MarketingMethods
                .SingleOrDefaultAsync(m => m.Id == id);
            if (marketingMethod == null)
            {
                return NotFound();
            }

            return View(marketingMethod);
        }

        // POST: MarketingMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marketingMethod = await _context.MarketingMethods.SingleOrDefaultAsync(m => m.Id == id);
            _context.MarketingMethods.Remove(marketingMethod);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MarketingMethodExists(int id)
        {
            return _context.MarketingMethods.Any(e => e.Id == id);
        }
    }
}
