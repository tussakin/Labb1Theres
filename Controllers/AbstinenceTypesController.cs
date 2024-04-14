using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb1Theres.Data;
using Labb1Theres.Models;

namespace Labb1Theres.Controllers
{
    public class AbstinenceTypesController : Controller
    {
        private readonly Labb1DbContext _context;

        public AbstinenceTypesController(Labb1DbContext context)
        {
            _context = context;
        }

        // GET: AbstinenceTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AbstinenceTypes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abstinenceType = await _context.AbstinenceTypes
                .FirstOrDefaultAsync(m => m.AbstinenceId == id);
            if (abstinenceType == null)
            {
                return NotFound();
            }

            return View(abstinenceType);
        }

        // GET: AbstinenceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AbstinenceTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AbstinenceId,AbstinenceName")] AbstinenceType abstinenceType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(abstinenceType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(abstinenceType);
        }

        // GET: AbstinenceTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abstinenceType = await _context.AbstinenceTypes.FindAsync(id);
            if (abstinenceType == null)
            {
                return NotFound();
            }
            return View(abstinenceType);
        }

        // POST: AbstinenceTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AbstinenceId,AbstinenceName")] AbstinenceType abstinenceType)
        {
            if (id != abstinenceType.AbstinenceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abstinenceType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbstinenceTypeExists(abstinenceType.AbstinenceId))
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
            return View(abstinenceType);
        }

        // GET: AbstinenceTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abstinenceType = await _context.AbstinenceTypes
                .FirstOrDefaultAsync(m => m.AbstinenceId == id);
            if (abstinenceType == null)
            {
                return NotFound();
            }

            return View(abstinenceType);
        }

        // POST: AbstinenceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var abstinenceType = await _context.AbstinenceTypes.FindAsync(id);
            if (abstinenceType != null)
            {
                _context.AbstinenceTypes.Remove(abstinenceType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbstinenceTypeExists(int id)
        {
            return _context.AbstinenceTypes.Any(e => e.AbstinenceId == id);
        }
    }
}
