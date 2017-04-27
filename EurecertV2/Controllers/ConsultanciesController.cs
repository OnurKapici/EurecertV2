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
    public class ConsultanciesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment env;
        
        
        public ConsultanciesController(ApplicationDbContext context, IHostingEnvironment _env)
        {
            _context = context;
            this.env = _env;
        }

        // GET: Consultancies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Consultancies.Include(c => c.ApplicationMethod).Include(c => c.Company).Include(c => c.MarketingMethod).Include(c => c.ReportCreatedBy);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Consultancies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultancy = await _context.Consultancies
                .Include(c => c.ApplicationMethod)
                .Include(c => c.Company)
                .Include(c => c.MarketingMethod)
                .Include(c => c.ReportCreatedBy)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (consultancy == null)
            {
                return NotFound();
            }

            return View(consultancy);
        }

        // GET: Consultancies/Create
        public IActionResult Create()
        {
            ViewData["ApplicationMethodId"] = new SelectList(_context.ApplicationMethods, "Id", "Name");
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewData["MarketingMethodId"] = new SelectList(_context.MarketingMethods, "Id", "Name");
            ViewData["ReportCreatedById"] = new SelectList(_context.ApplicationUser, "Id", "FullName");
            ViewData["ServiceFields"] = new MultiSelectList(_context.ServiceFields, "Id", "Name");
            var model = new Consultancy();
            model.CreatedBy = User.Identity.Name;
            model.UpdatedBy = User.Identity.Name;
            return View(model);
        }

        // POST: Consultancies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,ReportCode,ApplicationMethodId,IsPresentationDone,PresentationDate,PresentationFile,MarketingMethodId,ProposedBudget,ProposalDate,CompanyRequests,ConsultancyStartDate,ConsultancyFinishDate,ReportCreateDate,ReportCreatedById,ReportSendDate,ConsultantNotes,CreateDate,CreatedBy,UpdateDate,UpdatedBy,ServiceFields")] Consultancy consultancy,IFormFile presentationUpload)
        {
         
            if (ModelState.IsValid)
            {
                
                if(presentationUpload != null && presentationUpload.Length > 0)
                {
                    
                    string presentationName = new Random().Next(9999).ToString() + presentationUpload.FileName;
                    

                    using (var stream = new FileStream(env.WebRootPath + "\\uploads\\presentationFiles\\" + presentationName, FileMode.Create))
                    {
                        presentationUpload.CopyTo(stream);
                    }
                    consultancy.PresentationFile = presentationName;
                }
                _context.Add(consultancy);
                await _context.SaveChangesAsync();

                consultancy.ConsultancyServiceFields.Clear();
                if (consultancy.ServiceFields != null)
                {
                    foreach (var serviceField in consultancy.ServiceFields)
                    {
                        consultancy.ConsultancyServiceFields.Add(new ConsultancyServiceField() { ConsultancyId = consultancy.Id, ServiceFieldId = serviceField });
                    }
                }
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            ViewData["ApplicationMethodId"] = new SelectList(_context.ApplicationMethods, "Id", "Name", consultancy.ApplicationMethodId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", consultancy.CompanyId);
            ViewData["MarketingMethodId"] = new SelectList(_context.MarketingMethods, "Id", "Name", consultancy.MarketingMethodId);
            ViewData["ReportCreatedById"] = new SelectList(_context.ApplicationUser, "Id", "FullName", consultancy.ReportCreatedById);
            ViewData["ServiceFields"] = new MultiSelectList(_context.ServiceFields, "Id", "Name", consultancy.ServiceFields);
            return View(consultancy);
        }

        // GET: Consultancies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultancy = await _context.Consultancies.Include("ConsultancyServiceFields").SingleOrDefaultAsync(m => m.Id == id);
            if (consultancy == null)
            {
                return NotFound();
            }
            ViewData["ApplicationMethodId"] = new SelectList(_context.ApplicationMethods, "Id", "Name", consultancy.ApplicationMethodId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", consultancy.CompanyId);
            ViewData["MarketingMethodId"] = new SelectList(_context.MarketingMethods, "Id", "Name", consultancy.MarketingMethodId);
            ViewData["ReportCreatedById"] = new SelectList(_context.ApplicationUser, "Id", "FullName", consultancy.ReportCreatedById);
            ViewData["ServiceFields"] = new MultiSelectList(_context.ServiceFields, "Id", "Name",consultancy.ConsultancyServiceFields.Select(c => c.ServiceFieldId).ToList());
            return View(consultancy);
            
        }

        // POST: Consultancies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,ReportCode,ApplicationMethodId,IsPresentationDone,PresentationDate,PresentationFile,MarketingMethodId,ProposedBudget,ProposalDate,CompanyRequests,ConsultancyStartDate,ConsultancyFinishDate,ReportCreateDate,ReportCreatedById,ReportSendDate,ConsultantNotes,CreateDate,CreatedBy,UpdateDate,UpdatedBy,ServiceFields")] Consultancy consultancy,IFormFile presentationUpload)
        {
            
            if (id != consultancy.Id)
            {
                return NotFound();
            }
         
            
            if (ModelState.IsValid)
            {
                
                try
                {
                    if (presentationUpload != null && presentationUpload.Length > 0)
                    {          
                        string presentationName = new Random().Next(9999).ToString() + presentationUpload.FileName;
                        using (var stream = new FileStream(env.WebRootPath + "\\uploads\\presentationFiles\\" + presentationName, FileMode.Create))
                        {
                            presentationUpload.CopyTo(stream);
                        }
                        consultancy.PresentationFile = presentationName;
                    }
                    _context.ConsultancyServiceFields.RemoveRange(_context.ConsultancyServiceFields.Where(w => w.ConsultancyId == id).ToList());
                    _context.SaveChanges();
                    _context.Update(consultancy);
                    _context.SaveChanges();
                    if (consultancy.ServiceFields != null)
                    {
                        foreach (var serviceField in consultancy.ServiceFields)
                        {
                            consultancy.ConsultancyServiceFields.Add(new ConsultancyServiceField() { ConsultancyId = consultancy.Id, ServiceFieldId = serviceField });
                        }
                        
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultancyExists(consultancy.Id))
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
            ViewData["ApplicationMethodId"] = new SelectList(_context.ApplicationMethods, "Id", "Name", consultancy.ApplicationMethodId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", consultancy.CompanyId);
            ViewData["MarketingMethodId"] = new SelectList(_context.MarketingMethods, "Id", "Name", consultancy.MarketingMethodId);
            ViewData["ReportCreatedById"] = new SelectList(_context.ApplicationUser, "Id", "FullName", consultancy.ReportCreatedById);
            ViewData["ServiceFields"] = new MultiSelectList(_context.ServiceFields, "Id", "Name", consultancy.ServiceFields);
            return View(consultancy);
        }

        // GET: Consultancies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultancy = await _context.Consultancies
                .Include(c => c.ApplicationMethod)
                .Include(c => c.Company)
                .Include(c => c.MarketingMethod)
                .Include(c => c.ReportCreatedBy)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (consultancy == null)
            {
                return NotFound();
            }

            return View(consultancy);
        }

        // POST: Consultancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultancy = await _context.Consultancies.SingleOrDefaultAsync(m => m.Id == id);
            try
            {
                consultancy.ConsultancyServiceFields.Clear();
                _context.Consultancies.Remove(consultancy);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("Delete", "Silme ��lemi Esnas�nda Hata Olu�tu.Bu Kay�d�n Ba�ka Kay�tlar Taraf�ndan Kullan�lmad���na Emin Olun !!");
                return View(consultancy);
            }
        }

        private bool ConsultancyExists(int id)
        {
            return _context.Consultancies.Any(e => e.Id == id);
        }
    }
}
