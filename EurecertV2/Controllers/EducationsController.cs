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
    public class EducationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EducationsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Educations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Educations.Include(e => e.ApplicationMethod).Include(e => e.Company).Include(e => e.EducationCategory).Include(e => e.MarketingMethod);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Educations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .Include(e => e.ApplicationMethod)
                .Include(e => e.Company)
                .Include(e => e.EducationCategory)
                .Include(e => e.MarketingMethod)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // GET: Educations/Create
        public IActionResult Create()
        {
            ViewData["ApplicationMethodId"] = new SelectList(_context.ApplicationMethods, "Id", "Name");
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewData["EducationCategoryId"] = new SelectList(_context.EducationCategories, "Id", "Name");
            ViewData["MarketingMethodId"] = new SelectList(_context.MarketingMethods, "Id", "Name");
            var model = new Education();
            model.CreatedBy = User.Identity.Name;
            model.UpdatedBy = User.Identity.Name;
            model.CreateDate = DateTime.Now;
            model.UpdateDate = DateTime.Now;
            return View(model);
        }

        // POST: Educations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,ReportCode,IsMarketingDone,MarketingMethodId,MarketingDate,ApplicationMethodId,EducationCategoryId,Teacher,ProposedBudget,ProposalDate,CompanyRequests,EducationStartDate,EducationFinishDate,EducationLocation,TeacherNotes,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Education education)
        {
            if (ModelState.IsValid)
            {
                _context.Add(education);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ApplicationMethodId"] = new SelectList(_context.ApplicationMethods, "Id", "Name", education.ApplicationMethodId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", education.CompanyId);
            ViewData["EducationCategoryId"] = new SelectList(_context.EducationCategories, "Id", "Name", education.EducationCategoryId);
            ViewData["MarketingMethodId"] = new SelectList(_context.MarketingMethods, "Id", "Name", education.MarketingMethodId);
            return View(education);
        }

        // GET: Educations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations.SingleOrDefaultAsync(m => m.Id == id);
            if (education == null)
            {
                return NotFound();
            }
            ViewData["ApplicationMethodId"] = new SelectList(_context.ApplicationMethods, "Id", "Name", education.ApplicationMethodId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", education.CompanyId);
            ViewData["EducationCategoryId"] = new SelectList(_context.EducationCategories, "Id", "Name", education.EducationCategoryId);
            ViewData["MarketingMethodId"] = new SelectList(_context.MarketingMethods, "Id", "Name", education.MarketingMethodId);
            return View(education);
        }

        // POST: Educations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,ReportCode,IsMarketingDone,MarketingMethodId,MarketingDate,ApplicationMethodId,EducationCategoryId,Teacher,ProposedBudget,ProposalDate,CompanyRequests,EducationStartDate,EducationFinishDate,EducationLocation,TeacherNotes,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Education education)
        {
            if (id != education.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    education.UpdateDate = DateTime.Now;
                    education.UpdatedBy = User.Identity.Name;
                    _context.Update(education);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationExists(education.Id))
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
            ViewData["ApplicationMethodId"] = new SelectList(_context.ApplicationMethods, "Id", "Name", education.ApplicationMethodId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", education.CompanyId);
            ViewData["EducationCategoryId"] = new SelectList(_context.EducationCategories, "Id", "Name", education.EducationCategoryId);
            ViewData["MarketingMethodId"] = new SelectList(_context.MarketingMethods, "Id", "Name", education.MarketingMethodId);
            return View(education);
        }

        // GET: Educations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .Include(e => e.ApplicationMethod)
                .Include(e => e.Company)
                .Include(e => e.EducationCategory)
                .Include(e => e.MarketingMethod)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education = await _context.Educations.SingleOrDefaultAsync(m => m.Id == id);
            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EducationExists(int id)
        {
            return _context.Educations.Any(e => e.Id == id);
        }
    }
}
