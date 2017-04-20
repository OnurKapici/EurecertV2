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
    public class EducationCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EducationCategoriesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: EducationCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.EducationCategories.ToListAsync());
        }

        // GET: EducationCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationCategory = await _context.EducationCategories
                .SingleOrDefaultAsync(m => m.Id == id);
            if (educationCategory == null)
            {
                return NotFound();
            }

            return View(educationCategory);
        }

        // GET: EducationCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EducationCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] EducationCategory educationCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educationCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(educationCategory);
        }

        // GET: EducationCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationCategory = await _context.EducationCategories.SingleOrDefaultAsync(m => m.Id == id);
            if (educationCategory == null)
            {
                return NotFound();
            }
            return View(educationCategory);
        }

        // POST: EducationCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] EducationCategory educationCategory)
        {
            if (id != educationCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educationCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationCategoryExists(educationCategory.Id))
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
            return View(educationCategory);
        }

        // GET: EducationCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationCategory = await _context.EducationCategories
                .SingleOrDefaultAsync(m => m.Id == id);
            if (educationCategory == null)
            {
                return NotFound();
            }

            return View(educationCategory);
        }

        // POST: EducationCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educationCategory = await _context.EducationCategories.SingleOrDefaultAsync(m => m.Id == id);
            _context.EducationCategories.Remove(educationCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EducationCategoryExists(int id)
        {
            return _context.EducationCategories.Any(e => e.Id == id);
        }
    }
}
