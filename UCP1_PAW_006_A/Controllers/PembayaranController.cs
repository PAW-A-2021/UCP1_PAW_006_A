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
    public class PembayaranController : Controller
    {
        private readonly EnhaStoreContext _context;

        public PembayaranController(EnhaStoreContext context)
        {
            _context = context;
        }

        // GET: Pembayaran
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pembayarans.ToListAsync());
        }

        // GET: Pembayaran/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayarans
                .FirstOrDefaultAsync(m => m.IdPembayaran == id);
            if (pembayaran == null)
            {
                return NotFound();
            }

            return View(pembayaran);
        }

        // GET: Pembayaran/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pembayaran/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPembayaran,TanggalPembayaran,JenisPembayaran,TotalHarga,BuktiPembayaran")] Pembayaran pembayaran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pembayaran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pembayaran);
        }

        // GET: Pembayaran/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayarans.FindAsync(id);
            if (pembayaran == null)
            {
                return NotFound();
            }
            return View(pembayaran);
        }

        // POST: Pembayaran/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdPembayaran,TanggalPembayaran,JenisPembayaran,TotalHarga,BuktiPembayaran")] Pembayaran pembayaran)
        {
            if (id != pembayaran.IdPembayaran)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pembayaran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PembayaranExists(pembayaran.IdPembayaran))
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
            return View(pembayaran);
        }

        // GET: Pembayaran/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayarans
                .FirstOrDefaultAsync(m => m.IdPembayaran == id);
            if (pembayaran == null)
            {
                return NotFound();
            }

            return View(pembayaran);
        }

        // POST: Pembayaran/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pembayaran = await _context.Pembayarans.FindAsync(id);
            _context.Pembayarans.Remove(pembayaran);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PembayaranExists(string id)
        {
            return _context.Pembayarans.Any(e => e.IdPembayaran == id);
        }
    }
}
