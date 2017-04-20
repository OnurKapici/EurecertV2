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
    public class CompanyFunctionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyFunctionsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CompanyFunctions
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyFunctions.ToListAsync());
        }

        // GET: CompanyFunctions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyFunction = await _context.CompanyFunctions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (companyFunction == null)
            {
                return NotFound();
            }

            return View(companyFunction);
        }

        // GET: CompanyFunctions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyFunctions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Code")] CompanyFunction companyFunction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyFunction);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(companyFunction);
        }

        // GET: CompanyFunctions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyFunction = await _context.CompanyFunctions.SingleOrDefaultAsync(m => m.Id == id);
            if (companyFunction == null)
            {
                return NotFound();
            }
            return View(companyFunction);
        }

        // POST: CompanyFunctions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Code")] CompanyFunction companyFunction)
        {
            if (id != companyFunction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyFunction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyFunctionExists(companyFunction.Id))
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
            return View(companyFunction);
        }

        // GET: CompanyFunctions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyFunction = await _context.CompanyFunctions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (companyFunction == null)
            {
                return NotFound();
            }

            return View(companyFunction);
        }

        // POST: CompanyFunctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyFunction = await _context.CompanyFunctions.SingleOrDefaultAsync(m => m.Id == id);
            _context.CompanyFunctions.Remove(companyFunction);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CompanyFunctionExists(int id)
        {
            return _context.CompanyFunctions.Any(e => e.Id == id);
        }
    }
}
