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
    public class AbstinenceListsController : Controller
    {
        private readonly Labb1DbContext _context;

        public AbstinenceListsController(Labb1DbContext context)
        {
            _context = context;
        }

        // GET: AbstinenceLists
        public async Task<IActionResult> Index()
        {
            List<Employee> allEmployees = await _context.Employees.ToListAsync();
            ViewBag.AllEmployees = allEmployees;

            var abstinenceLists = await _context.AbstinenceLists.Include(a => a.AbstinenceType).Include(a => a.Employee).ToListAsync();
            var labb1DbContext = _context.AbstinenceLists.Include(a => a.AbstinenceType).Include(a => a.Employee);
            return View(await labb1DbContext.ToListAsync());
        }



        // GET: AbstinenceLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abstinenceList = await _context.AbstinenceLists
                .Include(a => a.AbstinenceType)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abstinenceList == null)
            {
                return NotFound();
            }

            return View(abstinenceList);
        }

        // GET: AbstinenceLists/Create
        public IActionResult Create()
        {
            ViewData["FkAbstinenceType"] = new SelectList(_context.AbstinenceTypes, "AbstinenceId", "AbstinenceName");
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName");
            return View();
        }

        // POST: AbstinenceLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FkEmployeeId,FkAbstinenceType,AbstinenceStart,AbstinenceEnd")] AbstinenceList abstinenceList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(abstinenceList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkAbstinenceType"] = new SelectList(_context.AbstinenceTypes, "AbstinenceId", "AbstinenceName", abstinenceList.FkAbstinenceType);
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", abstinenceList.FkEmployeeId);
            return View(abstinenceList);
        }

        // GET: AbstinenceLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abstinenceList = await _context.AbstinenceLists.FindAsync(id);
            if (abstinenceList == null)
            {
                return NotFound();
            }
            ViewData["FkAbstinenceType"] = new SelectList(_context.AbstinenceTypes, "AbstinenceId", "AbstinenceName", abstinenceList.FkAbstinenceType);
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", abstinenceList.FkEmployeeId);
            return View(abstinenceList);
        }

        // POST: AbstinenceLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FkEmployeeId,FkAbstinenceType,AbstinenceStart,AbstinenceEnd")] AbstinenceList abstinenceList)
        {
            if (id != abstinenceList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abstinenceList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbstinenceListExists(abstinenceList.Id))
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
            ViewData["FkAbstinenceType"] = new SelectList(_context.AbstinenceTypes, "AbstinenceId", "AbstinenceName", abstinenceList.FkAbstinenceType);
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", abstinenceList.FkEmployeeId);
            return View(abstinenceList);
        }

        // GET: AbstinenceLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abstinenceList = await _context.AbstinenceLists
                .Include(a => a.AbstinenceType)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abstinenceList == null)
            {
                return NotFound();
            }

            return View(abstinenceList);
        }

        // POST: AbstinenceLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var abstinenceList = await _context.AbstinenceLists.FindAsync(id);
            if (abstinenceList != null)
            {
                _context.AbstinenceLists.Remove(abstinenceList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbstinenceListExists(int id)
        {
            return _context.AbstinenceLists.Any(e => e.Id == id);
        }

    }
}
