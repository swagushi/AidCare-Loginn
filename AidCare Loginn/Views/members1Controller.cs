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
    public class members1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public members1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: members1
        public async Task<IActionResult> Index()
        {
              return _context.member != null ? 
                          View(await _context.member.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.member'  is null.");
        }

        // GET: members1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.member == null)
            {
                return NotFound();
            }

            var member = await _context.member
                .FirstOrDefaultAsync(m => m.memberID == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: members1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: members1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("memberID,Firstname,Lastname,DateRegistered")] member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: members1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.member == null)
            {
                return NotFound();
            }

            var member = await _context.member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: members1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("memberID,Firstname,Lastname,DateRegistered")] member member)
        {
            if (id != member.memberID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!memberExists(member.memberID))
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
            return View(member);
        }

        // GET: members1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.member == null)
            {
                return NotFound();
            }

            var member = await _context.member
                .FirstOrDefaultAsync(m => m.memberID == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: members1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.member == null)
            {
                return Problem("Entity set 'ApplicationDbContext.member'  is null.");
            }
            var member = await _context.member.FindAsync(id);
            if (member != null)
            {
                _context.member.Remove(member);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool memberExists(int id)
        {
          return (_context.member?.Any(e => e.memberID == id)).GetValueOrDefault();
        }
    }
}
