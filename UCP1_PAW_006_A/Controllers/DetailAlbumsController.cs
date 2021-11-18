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
    public class DetailAlbumsController : Controller
    {
        private readonly EnhaStoreContext _context;

        public DetailAlbumsController(EnhaStoreContext context)
        {
            _context = context;
        }

        // GET: DetailAlbums
        public async Task<IActionResult> Index()
        {
            return View(await _context.DetailAlbums.ToListAsync());
        }

        // GET: DetailAlbums/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailAlbum = await _context.DetailAlbums
                .FirstOrDefaultAsync(m => m.IdAlbum == id);
            if (detailAlbum == null)
            {
                return NotFound();
            }

            return View(detailAlbum);
        }

        // GET: DetailAlbums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetailAlbums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlbum,JenisAlbum,HargaAlbum,PajakAlbum")] DetailAlbum detailAlbum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detailAlbum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detailAlbum);
        }

        // GET: DetailAlbums/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailAlbum = await _context.DetailAlbums.FindAsync(id);
            if (detailAlbum == null)
            {
                return NotFound();
            }
            return View(detailAlbum);
        }

        // POST: DetailAlbums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdAlbum,JenisAlbum,HargaAlbum,PajakAlbum")] DetailAlbum detailAlbum)
        {
            if (id != detailAlbum.IdAlbum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detailAlbum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailAlbumExists(detailAlbum.IdAlbum))
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
            return View(detailAlbum);
        }

        // GET: DetailAlbums/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailAlbum = await _context.DetailAlbums
                .FirstOrDefaultAsync(m => m.IdAlbum == id);
            if (detailAlbum == null)
            {
                return NotFound();
            }

            return View(detailAlbum);
        }

        // POST: DetailAlbums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var detailAlbum = await _context.DetailAlbums.FindAsync(id);
            _context.DetailAlbums.Remove(detailAlbum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailAlbumExists(string id)
        {
            return _context.DetailAlbums.Any(e => e.IdAlbum == id);
        }
    }
}
