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
    public class CustomerController : Controller
    {
        private readonly EnhaStoreContext _context;

        public CustomerController(EnhaStoreContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            var enhaStoreContext = _context.Customers.Include(c => c.IdAlbumNavigation).Include(c => c.IdPembayaranNavigation).Include(c => c.IdPemesananNavigation).Include(c => c.NoResiNavigation).Include(c => c.UsernameNavigation);
            return View(await enhaStoreContext.ToListAsync());
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.IdAlbumNavigation)
                .Include(c => c.IdPembayaranNavigation)
                .Include(c => c.IdPemesananNavigation)
                .Include(c => c.NoResiNavigation)
                .Include(c => c.UsernameNavigation)
                .FirstOrDefaultAsync(m => m.IdCustomer == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            ViewData["IdAlbum"] = new SelectList(_context.DetailAlbums, "IdAlbum", "IdAlbum");
            ViewData["IdPembayaran"] = new SelectList(_context.Pembayarans, "IdPembayaran", "IdPembayaran");
            ViewData["IdPemesanan"] = new SelectList(_context.Pemesanans, "IdPemesanan", "IdPemesanan");
            ViewData["NoResi"] = new SelectList(_context.Pengirimen, "NoResi", "NoResi");
            ViewData["Username"] = new SelectList(_context.SignIns, "Username", "Username");
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCustomer,Nama,NoHp,AlamatLengkap,Username,IdPemesanan,IdPembayaran,NoResi,IdAlbum")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlbum"] = new SelectList(_context.DetailAlbums, "IdAlbum", "IdAlbum", customer.IdAlbum);
            ViewData["IdPembayaran"] = new SelectList(_context.Pembayarans, "IdPembayaran", "IdPembayaran", customer.IdPembayaran);
            ViewData["IdPemesanan"] = new SelectList(_context.Pemesanans, "IdPemesanan", "IdPemesanan", customer.IdPemesanan);
            ViewData["NoResi"] = new SelectList(_context.Pengirimen, "NoResi", "NoResi", customer.NoResi);
            ViewData["Username"] = new SelectList(_context.SignIns, "Username", "Username", customer.Username);
            return View(customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["IdAlbum"] = new SelectList(_context.DetailAlbums, "IdAlbum", "IdAlbum", customer.IdAlbum);
            ViewData["IdPembayaran"] = new SelectList(_context.Pembayarans, "IdPembayaran", "IdPembayaran", customer.IdPembayaran);
            ViewData["IdPemesanan"] = new SelectList(_context.Pemesanans, "IdPemesanan", "IdPemesanan", customer.IdPemesanan);
            ViewData["NoResi"] = new SelectList(_context.Pengirimen, "NoResi", "NoResi", customer.NoResi);
            ViewData["Username"] = new SelectList(_context.SignIns, "Username", "Username", customer.Username);
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdCustomer,Nama,NoHp,AlamatLengkap,Username,IdPemesanan,IdPembayaran,NoResi,IdAlbum")] Customer customer)
        {
            if (id != customer.IdCustomer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.IdCustomer))
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
            ViewData["IdAlbum"] = new SelectList(_context.DetailAlbums, "IdAlbum", "IdAlbum", customer.IdAlbum);
            ViewData["IdPembayaran"] = new SelectList(_context.Pembayarans, "IdPembayaran", "IdPembayaran", customer.IdPembayaran);
            ViewData["IdPemesanan"] = new SelectList(_context.Pemesanans, "IdPemesanan", "IdPemesanan", customer.IdPemesanan);
            ViewData["NoResi"] = new SelectList(_context.Pengirimen, "NoResi", "NoResi", customer.NoResi);
            ViewData["Username"] = new SelectList(_context.SignIns, "Username", "Username", customer.Username);
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.IdAlbumNavigation)
                .Include(c => c.IdPembayaranNavigation)
                .Include(c => c.IdPemesananNavigation)
                .Include(c => c.NoResiNavigation)
                .Include(c => c.UsernameNavigation)
                .FirstOrDefaultAsync(m => m.IdCustomer == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(string id)
        {
            return _context.Customers.Any(e => e.IdCustomer == id);
        }
    }
}
