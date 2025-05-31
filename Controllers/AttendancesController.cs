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
    public class AttendancesController : Controller
    {
        private readonly HDPDbContext _context;

        public AttendancesController(HDPDbContext context)
        {
            _context = context;
        }

        // GET: Attendances
        public async Task<IActionResult> Index()
        {
            var hDPDbContext = _context.Attendances.Include(a => a.Trainee).Include(a => a.Trainer).Include(a => a.WeeklySchedule);
            return View(await hDPDbContext.ToListAsync());
        }

        // GET: Attendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .Include(a => a.Trainee)
                .Include(a => a.Trainer)
                .Include(a => a.WeeklySchedule)
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: Attendances/Create
        public IActionResult Create()
        {
            ViewData["TraineeId"] = new SelectList(_context.Trainees, "TraineeId", "TraineeId");
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerId");
            ViewData["WeeklyScheduleId"] = new SelectList(_context.WeeklySchedules, "WeeklyScheduleId", "WeeklyScheduleId");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttendanceId,WeeklyScheduleId,TraineeId,TrainerId,Session,SubmissionDate,Status")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TraineeId"] = new SelectList(_context.Trainees, "TraineeId", "TraineeId", attendance.TraineeId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerId", attendance.TrainerId);
            ViewData["WeeklyScheduleId"] = new SelectList(_context.WeeklySchedules, "WeeklyScheduleId", "WeeklyScheduleId", attendance.WeeklyScheduleId);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            ViewData["TraineeId"] = new SelectList(_context.Trainees, "TraineeId", "TraineeId", attendance.TraineeId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerId", attendance.TrainerId);
            ViewData["WeeklyScheduleId"] = new SelectList(_context.WeeklySchedules, "WeeklyScheduleId", "WeeklyScheduleId", attendance.WeeklyScheduleId);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttendanceId,WeeklyScheduleId,TraineeId,TrainerId,Session,SubmissionDate,Status")] Attendance attendance)
        {
            if (id != attendance.AttendanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists(attendance.AttendanceId))
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
            ViewData["TraineeId"] = new SelectList(_context.Trainees, "TraineeId", "TraineeId", attendance.TraineeId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerId", attendance.TrainerId);
            ViewData["WeeklyScheduleId"] = new SelectList(_context.WeeklySchedules, "WeeklyScheduleId", "WeeklyScheduleId", attendance.WeeklyScheduleId);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .Include(a => a.Trainee)
                .Include(a => a.Trainer)
                .Include(a => a.WeeklySchedule)
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(int id)
        {
            return _context.Attendances.Any(e => e.AttendanceId == id);
        }
    }
}
