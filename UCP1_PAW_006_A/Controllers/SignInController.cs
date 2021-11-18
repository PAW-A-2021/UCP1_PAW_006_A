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
    public class SignInController : Controller
    {
        private readonly EnhaStoreContext _context;

        public SignInController(EnhaStoreContext context)
        {
            _context = context;
        }

        // GET: SignIn
        public async Task<IActionResult> Index()
        {
            return View(await _context.SignIns.ToListAsync());
        }

        // GET: SignIn/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signIn = await _context.SignIns
                .FirstOrDefaultAsync(m => m.Username == id);
            if (signIn == null)
            {
                return NotFound();
            }

            return View(signIn);
        }

        // GET: SignIn/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SignIn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Password")] SignIn signIn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signIn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signIn);
        }

        // GET: SignIn/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signIn = await _context.SignIns.FindAsync(id);
            if (signIn == null)
            {
                return NotFound();
            }
            return View(signIn);
        }

        // POST: SignIn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Username,Password")] SignIn signIn)
        {
            if (id != signIn.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signIn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignInExists(signIn.Username))
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
            return View(signIn);
        }

        // GET: SignIn/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signIn = await _context.SignIns
                .FirstOrDefaultAsync(m => m.Username == id);
            if (signIn == null)
            {
                return NotFound();
            }

            return View(signIn);
        }

        // POST: SignIn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var signIn = await _context.SignIns.FindAsync(id);
            _context.SignIns.Remove(signIn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignInExists(string id)
        {
            return _context.SignIns.Any(e => e.Username == id);
        }
    }
}
