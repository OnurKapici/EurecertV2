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
    public class ApplicationMethodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationMethodsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ApplicationMethods
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationMethods.ToListAsync());
        }

        // GET: ApplicationMethods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationMethod = await _context.ApplicationMethods
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationMethod == null)
            {
                return NotFound();
            }

            return View(applicationMethod);
        }

        // GET: ApplicationMethods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ApplicationMethod applicationMethod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationMethod);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(applicationMethod);
        }

        // GET: ApplicationMethods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationMethod = await _context.ApplicationMethods.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationMethod == null)
            {
                return NotFound();
            }
            return View(applicationMethod);
        }

        // POST: ApplicationMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ApplicationMethod applicationMethod)
        {
            if (id != applicationMethod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationMethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationMethodExists(applicationMethod.Id))
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
            return View(applicationMethod);
        }

        // GET: ApplicationMethods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationMethod = await _context.ApplicationMethods
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationMethod == null)
            {
                return NotFound();
            }

            return View(applicationMethod);
        }

        // POST: ApplicationMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationMethod = await _context.ApplicationMethods.SingleOrDefaultAsync(m => m.Id == id);
            _context.ApplicationMethods.Remove(applicationMethod);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ApplicationMethodExists(int id)
        {
            return _context.ApplicationMethods.Any(e => e.Id == id);
        }
    }
}
