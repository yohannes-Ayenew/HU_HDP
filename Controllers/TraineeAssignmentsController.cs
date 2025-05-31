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
    public class TraineeAssignmentsController : Controller
    {
        private readonly HDPDbContext _context;

        public TraineeAssignmentsController(HDPDbContext context)
        {
            _context = context;
        }

        // GET: TraineeAssignments
        public async Task<IActionResult> Index()
        {
            var hDPDbContext = _context.TraineeAssignments.Include(t => t.Center).Include(t => t.Trainee);
            return View(await hDPDbContext.ToListAsync());
        }

        // GET: TraineeAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traineeAssignment = await _context.TraineeAssignments
                .Include(t => t.Center)
                .Include(t => t.Trainee)
                .FirstOrDefaultAsync(m => m.TraineeAssignmentId == id);
            if (traineeAssignment == null)
            {
                return NotFound();
            }

            return View(traineeAssignment);
        }

        // GET: TraineeAssignments/Create
        public IActionResult Create()
        {
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterId");
            ViewData["TraineeId"] = new SelectList(_context.Trainees, "TraineeId", "TraineeId");
            return View();
        }

        // POST: TraineeAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TraineeAssignmentId,TraineeId,CenterId,AssignedDate")] TraineeAssignment traineeAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(traineeAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterId", traineeAssignment.CenterId);
            ViewData["TraineeId"] = new SelectList(_context.Trainees, "TraineeId", "TraineeId", traineeAssignment.TraineeId);
            return View(traineeAssignment);
        }

        // GET: TraineeAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traineeAssignment = await _context.TraineeAssignments.FindAsync(id);
            if (traineeAssignment == null)
            {
                return NotFound();
            }
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterId", traineeAssignment.CenterId);
            ViewData["TraineeId"] = new SelectList(_context.Trainees, "TraineeId", "TraineeId", traineeAssignment.TraineeId);
            return View(traineeAssignment);
        }

        // POST: TraineeAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TraineeAssignmentId,TraineeId,CenterId,AssignedDate")] TraineeAssignment traineeAssignment)
        {
            if (id != traineeAssignment.TraineeAssignmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(traineeAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeAssignmentExists(traineeAssignment.TraineeAssignmentId))
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
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterId", traineeAssignment.CenterId);
            ViewData["TraineeId"] = new SelectList(_context.Trainees, "TraineeId", "TraineeId", traineeAssignment.TraineeId);
            return View(traineeAssignment);
        }

        // GET: TraineeAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traineeAssignment = await _context.TraineeAssignments
                .Include(t => t.Center)
                .Include(t => t.Trainee)
                .FirstOrDefaultAsync(m => m.TraineeAssignmentId == id);
            if (traineeAssignment == null)
            {
                return NotFound();
            }

            return View(traineeAssignment);
        }

        // POST: TraineeAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var traineeAssignment = await _context.TraineeAssignments.FindAsync(id);
            if (traineeAssignment != null)
            {
                _context.TraineeAssignments.Remove(traineeAssignment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TraineeAssignmentExists(int id)
        {
            return _context.TraineeAssignments.Any(e => e.TraineeAssignmentId == id);
        }
    }
}
