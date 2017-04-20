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
    public class ServiceFieldsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceFieldsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ServiceFields
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceFields.ToListAsync());
        }

        // GET: ServiceFields/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceField = await _context.ServiceFields
                .SingleOrDefaultAsync(m => m.Id == id);
            if (serviceField == null)
            {
                return NotFound();
            }

            return View(serviceField);
        }

        // GET: ServiceFields/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ServiceField serviceField)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceField);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(serviceField);
        }

        // GET: ServiceFields/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceField = await _context.ServiceFields.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceField == null)
            {
                return NotFound();
            }
            return View(serviceField);
        }

        // POST: ServiceFields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ServiceField serviceField)
        {
            if (id != serviceField.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceField);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceFieldExists(serviceField.Id))
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
            return View(serviceField);
        }

        // GET: ServiceFields/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceField = await _context.ServiceFields
                .SingleOrDefaultAsync(m => m.Id == id);
            if (serviceField == null)
            {
                return NotFound();
            }

            return View(serviceField);
        }

        // POST: ServiceFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceField = await _context.ServiceFields.SingleOrDefaultAsync(m => m.Id == id);
            _context.ServiceFields.Remove(serviceField);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ServiceFieldExists(int id)
        {
            return _context.ServiceFields.Any(e => e.Id == id);
        }
    }
}
