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
    public class PemesananController : Controller
    {
        private readonly EnhaStoreContext _context;

        public PemesananController(EnhaStoreContext context)
        {
            _context = context;
        }

        // GET: Pemesanan
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pemesanans.ToListAsync());
        }

        // GET: Pemesanan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemesanan = await _context.Pemesanans
                .FirstOrDefaultAsync(m => m.IdPemesanan == id);
            if (pemesanan == null)
            {
                return NotFound();
            }

            return View(pemesanan);
        }

        // GET: Pemesanan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pemesanan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPemesanan,TanggalPemesanan,TotalHarga,JenisAlbum,JumlahAlbum")] Pemesanan pemesanan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pemesanan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pemesanan);
        }

        // GET: Pemesanan/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemesanan = await _context.Pemesanans.FindAsync(id);
            if (pemesanan == null)
            {
                return NotFound();
            }
            return View(pemesanan);
        }

        // POST: Pemesanan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdPemesanan,TanggalPemesanan,TotalHarga,JenisAlbum,JumlahAlbum")] Pemesanan pemesanan)
        {
            if (id != pemesanan.IdPemesanan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pemesanan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PemesananExists(pemesanan.IdPemesanan))
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
            return View(pemesanan);
        }

        // GET: Pemesanan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemesanan = await _context.Pemesanans
                .FirstOrDefaultAsync(m => m.IdPemesanan == id);
            if (pemesanan == null)
            {
                return NotFound();
            }

            return View(pemesanan);
        }

        // POST: Pemesanan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pemesanan = await _context.Pemesanans.FindAsync(id);
            _context.Pemesanans.Remove(pemesanan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PemesananExists(string id)
        {
            return _context.Pemesanans.Any(e => e.IdPemesanan == id);
        }
    }
}
