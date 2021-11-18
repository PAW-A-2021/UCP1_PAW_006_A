using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_006_A.Models;

namespace UCP1_PAW_006_A.Controllers
{
    public class PengirimanController : Controller
    {
        private readonly EnhaStoreContext _context;

        public PengirimanController(EnhaStoreContext context)
        {
            _context = context;
        }

        // GET: Pengiriman
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pengirimen.ToListAsync());
        }

        // GET: Pengiriman/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pengiriman = await _context.Pengirimen
                .FirstOrDefaultAsync(m => m.NoResi == id);
            if (pengiriman == null)
            {
                return NotFound();
            }

            return View(pengiriman);
        }

        // GET: Pengiriman/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pengiriman/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoResi,IdPembayaran,StatusPengiriman,JenisPengiriman,AlamatLengkap")] Pengiriman pengiriman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pengiriman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pengiriman);
        }

        // GET: Pengiriman/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pengiriman = await _context.Pengirimen.FindAsync(id);
            if (pengiriman == null)
            {
                return NotFound();
            }
            return View(pengiriman);
        }

        // POST: Pengiriman/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NoResi,IdPembayaran,StatusPengiriman,JenisPengiriman,AlamatLengkap")] Pengiriman pengiriman)
        {
            if (id != pengiriman.NoResi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pengiriman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PengirimanExists(pengiriman.NoResi))
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
            return View(pengiriman);
        }

        // GET: Pengiriman/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pengiriman = await _context.Pengirimen
                .FirstOrDefaultAsync(m => m.NoResi == id);
            if (pengiriman == null)
            {
                return NotFound();
            }

            return View(pengiriman);
        }

        // POST: Pengiriman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pengiriman = await _context.Pengirimen.FindAsync(id);
            _context.Pengirimen.Remove(pengiriman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PengirimanExists(string id)
        {
            return _context.Pengirimen.Any(e => e.NoResi == id);
        }
    }
}
