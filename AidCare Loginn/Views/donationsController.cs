using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AidCare_Loginn.Areas.Identity.Data;
using AidCare_Loginn.Models;

namespace AidCare_Loginn.Views
{
    public class donationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public donationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: donations
        public async Task<IActionResult> Index()
        {
              return _context.donation != null ? 
                          View(await _context.donation.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.donation'  is null.");
        }

        // GET: donations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.donation == null)
            {
                return NotFound();
            }

            var donation = await _context.donation
                .FirstOrDefaultAsync(m => m.donationID == id);
            if (donation == null)
            {
                return NotFound();
            }

            return View(donation);
        }

        // GET: donations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: donations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("donationID,DonationDescription,donationAmount")] donation donation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donation);
        }

        // GET: donations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.donation == null)
            {
                return NotFound();
            }

            var donation = await _context.donation.FindAsync(id);
            if (donation == null)
            {
                return NotFound();
            }
            return View(donation);
        }

        // POST: donations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("donationID,DonationDescription,donationAmount")] donation donation)
        {
            if (id != donation.donationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!donationExists(donation.donationID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(donation);
        }

        // GET: donations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.donation == null)
            {
                return NotFound();
            }

            var donation = await _context.donation
                .FirstOrDefaultAsync(m => m.donationID == id);
            if (donation == null)
            {
                return NotFound();
            }

            return View(donation);
        }

        // POST: donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.donation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.donation'  is null.");
            }
            var donation = await _context.donation.FindAsync(id);
            if (donation != null)
            {
                _context.donation.Remove(donation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool donationExists(int id)
        {
          return (_context.donation?.Any(e => e.donationID == id)).GetValueOrDefault();
        }
    }
}
