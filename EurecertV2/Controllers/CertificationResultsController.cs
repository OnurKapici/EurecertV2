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
    public class CertificationResultsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CertificationResultsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CertificationResults
        public async Task<IActionResult> Index()
        {
            return View(await _context.CertificationResults.ToListAsync());
        }

        // GET: CertificationResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificationResult = await _context.CertificationResults
                .SingleOrDefaultAsync(m => m.Id == id);
            if (certificationResult == null)
            {
                return NotFound();
            }

            return View(certificationResult);
        }

        // GET: CertificationResults/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CertificationResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CertificationResult certificationResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certificationResult);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(certificationResult);
        }

        // GET: CertificationResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificationResult = await _context.CertificationResults.SingleOrDefaultAsync(m => m.Id == id);
            if (certificationResult == null)
            {
                return NotFound();
            }
            return View(certificationResult);
        }

        // POST: CertificationResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CertificationResult certificationResult)
        {
            if (id != certificationResult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificationResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificationResultExists(certificationResult.Id))
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
            return View(certificationResult);
        }

        // GET: CertificationResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificationResult = await _context.CertificationResults
                .SingleOrDefaultAsync(m => m.Id == id);
            if (certificationResult == null)
            {
                return NotFound();
            }

            return View(certificationResult);
        }

        // POST: CertificationResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certificationResult = await _context.CertificationResults.SingleOrDefaultAsync(m => m.Id == id);
            _context.CertificationResults.Remove(certificationResult);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CertificationResultExists(int id)
        {
            return _context.CertificationResults.Any(e => e.Id == id);
        }
    }
}
