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
    public class ActionResearchesController(HDPDbContext context) : Controller
    {
        private readonly HDPDbContext _context = context;

        // GET: ActionResearches
        public async Task<IActionResult> Index()
        {
            var hDPDbContext = _context.ActionResearches.Include(a => a.Trainee);
            return View(await hDPDbContext.ToListAsync());
        }

        // GET: ActionResearches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var actionResearch = await _context.ActionResearches
                .Include(a => a.Trainee)
                .FirstOrDefaultAsync(m => m.ActionResearchId == id);

            if (actionResearch == null) return NotFound();

            return View(actionResearch);
        }

        // GET: ActionResearches/Create
        public IActionResult Create()
        {
            ViewData["TraineeId"] = new SelectList(
                _context.Trainees.Select(t => new
                {
                    TraineeId = t.TraineeId,
                    FullName = t.FirstName + " " + t.MiddleName + " " + t.LastName
                }),
                "TraineeId",
                "FullName"
            );
            return View();
        }

        // POST: ActionResearches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActionResearchId,ActionResearchTitle,AcademicYear,Status,TraineeId")] ActionResearch actionResearch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actionResearch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["TraineeId"] = new SelectList(
                _context.Trainees.Select(t => new
                {
                    TraineeId = t.TraineeId,
                    FullName = t.FirstName + " " + t.MiddleName + " " + t.LastName
                }),
                "TraineeId",
                "FullName",
                actionResearch.TraineeId
            );
            return View(actionResearch);
        }

        // GET: ActionResearches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var actionResearch = await _context.ActionResearches.FindAsync(id);
            if (actionResearch == null) return NotFound();

            ViewData["TraineeId"] = new SelectList(
                _context.Trainees.Select(t => new
                {
                    TraineeId = t.TraineeId,
                    FullName = t.FirstName + " " + t.MiddleName + " " + t.LastName
                }),
                "TraineeId",
                "FullName",
                actionResearch.TraineeId
            );
            return View(actionResearch);
        }

        // POST: ActionResearches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActionResearchId,ActionResearchTitle,AcademicYear,Status,TraineeId")] ActionResearch actionResearch)
        {
            if (id != actionResearch.ActionResearchId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actionResearch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActionResearchExists(actionResearch.ActionResearchId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["TraineeId"] = new SelectList(
                _context.Trainees.Select(t => new
                {
                    TraineeId = t.TraineeId,
                    FullName = t.FirstName + " " + t.MiddleName + " " + t.LastName
                }),
                "TraineeId",
                "FullName",
                actionResearch.TraineeId
            );
            return View(actionResearch);
        }

        // GET: ActionResearches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var actionResearch = await _context.ActionResearches
                .Include(a => a.Trainee)
                .FirstOrDefaultAsync(m => m.ActionResearchId == id);

            if (actionResearch == null) return NotFound();

            return View(actionResearch);
        }

        // POST: ActionResearches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actionResearch = await _context.ActionResearches.FindAsync(id);
            if (actionResearch != null)
            {
                _context.ActionResearches.Remove(actionResearch);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ActionResearchExists(int id)
        {
            return _context.ActionResearches.Any(e => e.ActionResearchId == id);
        }
    }
}
