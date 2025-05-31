﻿using System;
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
    public class CentersController : Controller
    {
        private readonly HDPDbContext _context;

        public CentersController(HDPDbContext context)
        {
            _context = context;
        }

        // GET: Centers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Centers.ToListAsync());
        }

        // GET: Centers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var center = await _context.Centers
                .FirstOrDefaultAsync(m => m.CenterId == id);
            if (center == null)
            {
                return NotFound();
            }

            return View(center);
        }

        // GET: Centers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Centers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CenterId,CenterCode,CenterName,Status")] Center center)
        {
            if (ModelState.IsValid)
            {
                _context.Add(center);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(center);
        }

        // GET: Centers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var center = await _context.Centers.FindAsync(id);
            if (center == null)
            {
                return NotFound();
            }
            return View(center);
        }

        // POST: Centers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CenterId,CenterCode,CenterName,Status")] Center center)
        {
            if (id != center.CenterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(center);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CenterExists(center.CenterId))
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
            return View(center);
        }

        // GET: Centers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var center = await _context.Centers
                .FirstOrDefaultAsync(m => m.CenterId == id);
            if (center == null)
            {
                return NotFound();
            }

            return View(center);
        }

        // POST: Centers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var center = await _context.Centers.FindAsync(id);
            if (center != null)
            {
                _context.Centers.Remove(center);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CenterExists(int id)
        {
            return _context.Centers.Any(e => e.CenterId == id);
        }
    }
}
