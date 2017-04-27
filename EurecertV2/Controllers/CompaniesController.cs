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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace EurecertV2.Controllers
{
    [Authorize]
    public class CompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment env;

        public CompaniesController(ApplicationDbContext context, IHostingEnvironment _env)
        {
            _context = context;
            env = _env;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Companies.Include(c => c.City).Include(c => c.CompanyFunction).Include(c => c.Country).Include(c => c.SalesPerson).Include(c => c.Source);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .Include(c => c.City)
                .Include(c => c.CompanyFunction)
                .Include(c => c.Country)
                .Include(c => c.SalesPerson)
                .Include(c => c.Source)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities.OrderBy(c=>c.Name), "Id", "Name");
            ViewData["CompanyFunctionId"] = new SelectList(_context.CompanyFunctions, "Id", "Name");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["SalesPersonId"] = new SelectList(_context.ApplicationUser, "Id", "FullName");
            ViewData["SourceId"] = new SelectList(_context.Sources, "Id", "Name");
            var model = new Company();
            model.CreateDate = DateTime.Now;
            model.UpdateDate = DateTime.Now;
            model.UpdatedBy = User.Identity.Name;
            model.CreatedBy = User.Identity.Name;
            
            return View(model);
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CompanyFunctionId,CountryId,CityId,Address,Email,Phone,Website,SourceId,SalesPersonId,ProposalAbstract,ProposalFile,ProposalResult,DownPayment,TotalAmount,CompanyRequests,VisitCount,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Company company, IFormFile ProposalFileUpload)
        {
            
            if (ModelState.IsValid)
            {
                if (ProposalFileUpload != null && ProposalFileUpload.Length > 0)
                {

                    string ProposalFileName = new Random().Next(9999).ToString() + ProposalFileUpload.FileName;


                    using (var stream = new FileStream(env.WebRootPath + "\\uploads\\ProposalFiles\\" + ProposalFileName, FileMode.Create))
                    {
                        ProposalFileUpload.CopyTo(stream);
                    }
                    company.ProposalFile = ProposalFileName;
                }
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CityId"] = new SelectList(_context.Cities.OrderBy(c => c.Name), "Id", "Name", company.CityId);
            ViewData["CompanyFunctionId"] = new SelectList(_context.CompanyFunctions, "Id", "Name", company.CompanyFunctionId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", company.CountryId);
            ViewData["SalesPersonId"] = new SelectList(_context.ApplicationUser, "Id", "FullName", company.SalesPersonId);
            ViewData["SourceId"] = new SelectList(_context.Sources, "Id", "Name", company.SourceId);
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.SingleOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities.OrderBy(c => c.Name), "Id", "Name", company.CityId);
            ViewData["CompanyFunctionId"] = new SelectList(_context.CompanyFunctions, "Id", "Name", company.CompanyFunctionId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", company.CountryId);
            ViewData["SalesPersonId"] = new SelectList(_context.ApplicationUser, "Id", "FullName", company.SalesPersonId);
            ViewData["SourceId"] = new SelectList(_context.Sources, "Id", "Name", company.SourceId);
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CompanyFunctionId,CountryId,CityId,Address,Email,Phone,Website,SourceId,SalesPersonId,ProposalAbstract,ProposalFile,ProposalResult,DownPayment,TotalAmount,CompanyRequests,VisitCount,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Company company, IFormFile ProposalFileUpload)
        {
            if (id != company.Id)
            {
                return NotFound();
            }


            company.UpdateDate = DateTime.Now;
            company.UpdatedBy = User.Identity.Name;

            if (ModelState.IsValid)
            {
                company.UpdateDate = DateTime.Now;
                company.UpdatedBy = User.Identity.Name;
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
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
            ViewData["CityId"] = new SelectList(_context.Cities.OrderBy(c => c.Name), "Id", "Name", company.CityId);
            ViewData["CompanyFunctionId"] = new SelectList(_context.CompanyFunctions, "Id", "Name", company.CompanyFunctionId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", company.CountryId);
            ViewData["SalesPersonId"] = new SelectList(_context.ApplicationUser, "Id", "FullName", company.SalesPersonId);
            ViewData["SourceId"] = new SelectList(_context.Sources, "Id", "Name", company.SourceId);
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .Include(c => c.City)
                .Include(c => c.CompanyFunction)
                .Include(c => c.Country)
                .Include(c => c.SalesPerson)
                .Include(c => c.Source)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Companies.SingleOrDefaultAsync(m => m.Id == id);
            try
            {
                
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("Delete", "Silme Ýþlemi Esnasýnda Hata Oluþtu.Bu Kayýdýn Baþka Kayýtlar Tarafýndan Kullanýlmadýðýna Emin Olun !!");
                return View(company);
            }

        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
