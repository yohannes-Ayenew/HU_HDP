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
    public class WeeklySchedulesController(HDPDbContext context) : Controller
    {
        private readonly HDPDbContext _context = context;

        // GET: WeeklySchedules
        public async Task<IActionResult> Index()
        {
            var ScheduleInfo = _context.WeeklySchedules.Include(w => w.Center).Include(w => w.Room).Include(w => w.Topic).Include(w => w.Trainer);
            return View(await ScheduleInfo.ToListAsync());
        }

        // GET: WeeklySchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weeklySchedule = await _context.WeeklySchedules
                .Include(w => w.Center)
                .Include(w => w.Room)
                .Include(w => w.Topic)
                .Include(w => w.Trainer)
                .FirstOrDefaultAsync(m => m.WeeklyScheduleId == id);
            if (weeklySchedule == null)
            {
                return NotFound();
            }

            return View(weeklySchedule);
        }

        // GET: WeeklySchedules/Create
        public IActionResult Create()
        {
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterId");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Room Name");
            ViewData["TopicId"] = new SelectList(_context.Topics, "TopicId", " Today's Topic");
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerId");
            return View();
        }

        // POST: WeeklySchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WeeklyScheduleId,TrainerId,CenterId,RoomId,TopicId,WeekName,TrainingDay,TrainingDate,Status,Remark")] WeeklySchedule weeklySchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weeklySchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterId", weeklySchedule.CenterId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", weeklySchedule.RoomId);
            ViewData["TopicId"] = new SelectList(_context.Topics, "TopicId", "TopicId", weeklySchedule.TopicId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerId", weeklySchedule.TrainerId);
            return View(weeklySchedule);
        }

        // GET: WeeklySchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weeklySchedule = await _context.WeeklySchedules.FindAsync(id);
            if (weeklySchedule == null)
            {
                return NotFound();
            }
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterId", weeklySchedule.CenterId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", weeklySchedule.RoomId);
            ViewData["TopicId"] = new SelectList(_context.Topics, "TopicId", "TopicId", weeklySchedule.TopicId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerId", weeklySchedule.TrainerId);
            return View(weeklySchedule);
        }

        // POST: WeeklySchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WeeklyScheduleId,TrainerId,CenterId,RoomId,TopicId,WeekName,TrainingDay,TrainingDate,Status,Remark")] WeeklySchedule weeklySchedule)
        {
            if (id != weeklySchedule.WeeklyScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weeklySchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeeklyScheduleExists(weeklySchedule.WeeklyScheduleId))
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
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterId", weeklySchedule.CenterId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", weeklySchedule.RoomId);
            ViewData["TopicId"] = new SelectList(_context.Topics, "TopicId", "TopicId", weeklySchedule.TopicId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerId", weeklySchedule.TrainerId);
            return View(weeklySchedule);
        }

        // GET: WeeklySchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weeklySchedule = await _context.WeeklySchedules
                .Include(w => w.Center)
                .Include(w => w.Room)
                .Include(w => w.Topic)
                .Include(w => w.Trainer)
                .FirstOrDefaultAsync(m => m.WeeklyScheduleId == id);
            if (weeklySchedule == null)
            {
                return NotFound();
            }

            return View(weeklySchedule);
        }

        // POST: WeeklySchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weeklySchedule = await _context.WeeklySchedules.FindAsync(id);
            if (weeklySchedule != null)
            {
                _context.WeeklySchedules.Remove(weeklySchedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeeklyScheduleExists(int id)
        {
            return _context.WeeklySchedules.Any(e => e.WeeklyScheduleId == id);
        }
    }
}
