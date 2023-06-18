using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSGTaskManager.Data;
using SSGTaskManager.Models;

namespace SSGTaskManager.Controllers
{
    public class ETC_InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ETC_InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ETC_Inventory
        public async Task<IActionResult> Index()
        {
              return _context.ETC_Inventory != null ? 
                          View(await _context.ETC_Inventory.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ETC_Inventory'  is null.");
        }

        public async Task<IActionResult> FormShow()
        {
            return View();
        }

        // GET: Inventory/FormResult
        public async Task<IActionResult> FormResult(String FindItem)
        {
            return View("Index", await _context.ETC_Inventory.Where(j => j.Item.Contains(FindItem)).ToListAsync());
        }


        // GET: ETC_Inventory/Details/5\
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ETC_Inventory == null)
            {
                return NotFound();
            }

            var eTC_Inventory = await _context.ETC_Inventory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eTC_Inventory == null)
            {
                return NotFound();
            }

            return View(eTC_Inventory);
        }

        // GET: ETC_Inventory/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ETC_Inventory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Item,Date,Name")] ETC_Inventory eTC_Inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eTC_Inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eTC_Inventory);
        }

        // GET: ETC_Inventory/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ETC_Inventory == null)
            {
                return NotFound();
            }

            var eTC_Inventory = await _context.ETC_Inventory.FindAsync(id);
            if (eTC_Inventory == null)
            {
                return NotFound();
            }
            return View(eTC_Inventory);
        }

        // POST: ETC_Inventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Item,Date,Name")] ETC_Inventory eTC_Inventory)
        {
            if (id != eTC_Inventory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eTC_Inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ETC_InventoryExists(eTC_Inventory.Id))
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
            return View(eTC_Inventory);
        }

        // GET: ETC_Inventory/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ETC_Inventory == null)
            {
                return NotFound();
            }

            var eTC_Inventory = await _context.ETC_Inventory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eTC_Inventory == null)
            {
                return NotFound();
            }

            return View(eTC_Inventory);
        }

        // POST: ETC_Inventory/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ETC_Inventory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ETC_Inventory'  is null.");
            }
            var eTC_Inventory = await _context.ETC_Inventory.FindAsync(id);
            if (eTC_Inventory != null)
            {
                _context.ETC_Inventory.Remove(eTC_Inventory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ETC_InventoryExists(int id)
        {
          return (_context.ETC_Inventory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
