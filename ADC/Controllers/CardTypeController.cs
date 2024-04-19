using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ADC.Data;
using ADC.Models;
using Microsoft.AspNetCore.Authorization;

namespace ADC.Controllers
{
    [Authorize]
    public class CardTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CardTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CardType
        public async Task<IActionResult> Index()
        {
            var cardTypes = await _context.CardTypes.ToListAsync();
            return View(cardTypes);
        }

        // GET: CardType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardType = await _context.CardTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardType == null)
            {
                return NotFound();
            }

            return View(cardType);
        }

        // GET: CardType/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CardType cardType)
        {
            if (ModelState.IsValid)
            {
                cardType.EntryBy = User.Identity?.Name;
                _context.Add(cardType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardType);
        }

        // GET: CardType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardType = await _context.CardTypes.FindAsync(id);
            if (cardType == null)
            {
                return NotFound();
            }
            return View(cardType);
        }

        // POST: CardType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,CardType cardType)
        {
            if (id != cardType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cardType.UpdateBy = User.Identity?.Name;
                    cardType.UpdateDate = DateTime.Now;
                    _context.Update(cardType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardTypeExists(cardType.Id))
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
            return View(cardType);
        }

        // GET: CardType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardType = await _context.CardTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardType == null)
            {
                return NotFound();
            }

            return View(cardType);
        }

        // POST: CardType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardType = await _context.CardTypes.FindAsync(id);
            if (cardType != null)
            {
                _context.CardTypes.Remove(cardType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardTypeExists(int id)
        {
            return _context.CardTypes.Any(e => e.Id == id);
        }
    }
}
