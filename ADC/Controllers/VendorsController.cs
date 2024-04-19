﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ADC.Data;
using ADC.Models;

namespace ADC.Controllers
{
    public class VendorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vendors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vendors.ToListAsync());
        }

        // GET: Vendors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendors = await _context.Vendors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendors == null)
            {
                return NotFound();
            }

            return View(vendors);
        }

        // GET: Vendors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendors vendors)
        {
            if (ModelState.IsValid)
            {
                vendors.EntryBy = User.Identity?.Name;
                _context.Add(vendors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendors);
        }

        // GET: Vendors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendors = await _context.Vendors.FindAsync(id);
            if (vendors == null)
            {
                return NotFound();
            }
            return View(vendors);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Vendors vendors)
        {
            if (id != vendors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vendors.UpdateBy = User.Identity?.Name;
                    vendors.UpdateDate = DateTime.Now;
                    _context.Update(vendors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorsExists(vendors.Id))
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
            return View(vendors);
        }

        // GET: Vendors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendors = await _context.Vendors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendors == null)
            {
                return NotFound();
            }

            return View(vendors);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendors = await _context.Vendors.FindAsync(id);
            if (vendors != null)
            {
                _context.Vendors.Remove(vendors);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendorsExists(int id)
        {
            return _context.Vendors.Any(e => e.Id == id);
        }
    }
}
