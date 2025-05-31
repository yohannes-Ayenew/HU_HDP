using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HU_HDP.Data;
using HU_HDP.Models;

namespace HU_HDP.Controllers
{
    public class AcademicUnitsController : Controller
    {
        private readonly HDPDbContext _context;

        public AcademicUnitsController(HDPDbContext context)
        {
            _context = context;
        }

        // GET: AcademicUnits
        public async Task<IActionResult> Index()
        {
            return View(await _context.AcademicUnits.ToListAsync());
        }

        // GET: AcademicUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicUnit = await _context.AcademicUnits
                .FirstOrDefaultAsync(m => m.AcademicUnitId == id);
            if (academicUnit == null)
            {
                return NotFound();
            }

            return View(academicUnit);
        }

        // GET: AcademicUnits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcademicUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcademicUnitId,AcademicUnitType,AcademicUnitName,AcademicUnitAcronym")] AcademicUnit academicUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(academicUnit);
        }

        // GET: AcademicUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicUnit = await _context.AcademicUnits.FindAsync(id);
            if (academicUnit == null)
            {
                return NotFound();
            }
            return View(academicUnit);
        }

        // POST: AcademicUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcademicUnitId,AcademicUnitType,AcademicUnitName,AcademicUnitAcronym")] AcademicUnit academicUnit)
        {
            if (id != academicUnit.AcademicUnitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicUnitExists(academicUnit.AcademicUnitId))
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
            return View(academicUnit);
        }

        // GET: AcademicUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicUnit = await _context.AcademicUnits
                .FirstOrDefaultAsync(m => m.AcademicUnitId == id);
            if (academicUnit == null)
            {
                return NotFound();
            }

            return View(academicUnit);
        }

        // POST: AcademicUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicUnit = await _context.AcademicUnits.FindAsync(id);
            if (academicUnit != null)
            {
                _context.AcademicUnits.Remove(academicUnit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicUnitExists(int id)
        {
            return _context.AcademicUnits.Any(e => e.AcademicUnitId == id);
        }
    }
}
