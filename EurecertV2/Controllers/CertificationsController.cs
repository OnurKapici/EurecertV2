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
    public class CertificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CertificationsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Certifications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Certifications.Include(c => c.ApplicationMethod).Include(c => c.CertificationInputsUser).Include(c => c.CertificationResult).Include(c => c.Company).Include(c => c.FirstContactPerson).Include(c => c.InspectorPerson).Include(c => c.MarketingMethod);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Certifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications
                .Include(c => c.ApplicationMethod)
                .Include(c => c.CertificationInputsUser)
                .Include(c => c.CertificationResult)
                .Include(c => c.Company)
                .Include(c => c.FirstContactPerson)
                .Include(c => c.InspectorPerson)
                .Include(c => c.MarketingMethod)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (certification == null)
            {
                return NotFound();
            }

            return View(certification);
        }

        // GET: Certifications/Create
        public IActionResult Create()
        {
            ViewData["ApplicationMethodId"] = new SelectList(_context.ApplicationMethods, "Id", "Name");
            ViewData["CertificationInputsUserId"] = new SelectList(_context.ApplicationUser, "Id", "FullName");
            ViewData["CertificationResultId"] = new SelectList(_context.CertificationResults, "Id", "Name");
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewData["FirstContactPersonId"] = new SelectList(_context.ApplicationUser, "Id", "FullName");
            ViewData["InspectorPersonId"] = new SelectList(_context.ApplicationUser, "Id", "FullName");
            ViewData["MarketingMethodId"] = new SelectList(_context.MarketingMethods, "Id", "Name");
            var model = new Certification();
            model.CreatedBy = User.Identity.Name;
            model.UpdatedBy = User.Identity.Name;
            return View(model);
        }

        // POST: Certifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,ReportCode,ImprintCode,InspectorPersonId,InspectionDate,MarketingMethodId,ApplicationMethodId,IsPresentationDone,PresentationDate,FirstContactDate,FirstContactPersonId,FirstInspectionDate,ApproveDate,DataSendDate,ReportReturnDate,ReportPreparedBy,InspectionReport,ReportRecievedDateByCompany,CompanyAnswerToReport,StartDateForMissings,FinishDateForMissings,LastInspectionDate,CertificationResultId,QualityCertificateDate,QualityCertificateEndDate,CertificationInputsCompleteDate,CertificationInputsUserId,InspectorNotes,ProposedBudget,InspectionFile,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Certification certification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certification);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ApplicationMethodId"] = new SelectList(_context.ApplicationMethods, "Id", "Name", certification.ApplicationMethodId);
            ViewData["CertificationInputsUserId"] = new SelectList(_context.ApplicationUser, "Id", "FullName", certification.CertificationInputsUserId);
            ViewData["CertificationResultId"] = new SelectList(_context.CertificationResults, "Id", "Name", certification.CertificationResultId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", certification.CompanyId);
            ViewData["FirstContactPersonId"] = new SelectList(_context.ApplicationUser, "Id", "FullName", certification.FirstContactPersonId);
            ViewData["InspectorPersonId"] = new SelectList(_context.ApplicationUser, "Id", "FullName", certification.InspectorPersonId);
            ViewData["MarketingMethodId"] = new SelectList(_context.MarketingMethods, "Id", "Name", certification.MarketingMethodId);
            return View(certification);
        }

        // GET: Certifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications.SingleOrDefaultAsync(m => m.Id == id);
            if (certification == null)
            {
                return NotFound();
            }
            ViewData["ApplicationMethodId"] = new SelectList(_context.ApplicationMethods, "Id", "Name", certification.ApplicationMethodId);
            ViewData["CertificationInputsUserId"] = new SelectList(_context.ApplicationUser, "Id", "FullName", certification.CertificationInputsUserId);
            ViewData["CertificationResultId"] = new SelectList(_context.CertificationResults, "Id", "Name", certification.CertificationResultId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", certification.CompanyId);
            ViewData["FirstContactPersonId"] = new SelectList(_context.ApplicationUser, "Id", "FullName", certification.FirstContactPersonId);
            ViewData["InspectorPersonId"] = new SelectList(_context.ApplicationUser, "Id", "FullName", certification.InspectorPersonId);
            ViewData["MarketingMethodId"] = new SelectList(_context.MarketingMethods, "Id", "Name", certification.MarketingMethodId);
            return View(certification);
        }

        // POST: Certifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,ReportCode,ImprintCode,InspectorPersonId,InspectionDate,MarketingMethodId,ApplicationMethodId,IsPresentationDone,PresentationDate,FirstContactDate,FirstContactPersonId,FirstInspectionDate,ApproveDate,DataSendDate,ReportReturnDate,ReportPreparedBy,InspectionReport,ReportRecievedDateByCompany,CompanyAnswerToReport,StartDateForMissings,FinishDateForMissings,LastInspectionDate,CertificationResultId,QualityCertificateDate,QualityCertificateEndDate,CertificationInputsCompleteDate,CertificationInputsUserId,InspectorNotes,ProposedBudget,InspectionFile,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Certification certification)
        {
            if (id != certification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificationExists(certification.Id))
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
            ViewData["ApplicationMethodId"] = new SelectList(_context.ApplicationMethods, "Id", "Name", certification.ApplicationMethodId);
            ViewData["CertificationInputsUserId"] = new SelectList(_context.ApplicationUser, "Id", "FullName", certification.CertificationInputsUserId);
            ViewData["CertificationResultId"] = new SelectList(_context.CertificationResults, "Id", "Name", certification.CertificationResultId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", certification.CompanyId);
            ViewData["FirstContactPersonId"] = new SelectList(_context.ApplicationUser, "Id", "FullName", certification.FirstContactPersonId);
            ViewData["InspectorPersonId"] = new SelectList(_context.ApplicationUser, "Id", "FullName", certification.InspectorPersonId);
            ViewData["MarketingMethodId"] = new SelectList(_context.MarketingMethods, "Id", "Name", certification.MarketingMethodId);
            return View(certification);
        }

        // GET: Certifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications
                .Include(c => c.ApplicationMethod)
                .Include(c => c.CertificationInputsUser)
                .Include(c => c.CertificationResult)
                .Include(c => c.Company)
                .Include(c => c.FirstContactPerson)
                .Include(c => c.InspectorPerson)
                .Include(c => c.MarketingMethod)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (certification == null)
            {
                return NotFound();
            }

            return View(certification);
        }

        // POST: Certifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certification = await _context.Certifications.SingleOrDefaultAsync(m => m.Id == id);
            _context.Certifications.Remove(certification);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CertificationExists(int id)
        {
            return _context.Certifications.Any(e => e.Id == id);
        }
    }
}
