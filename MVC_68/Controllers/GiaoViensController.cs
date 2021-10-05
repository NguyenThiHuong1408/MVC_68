using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_68.Data;
using MVC_68.Models;

namespace MVC_68.Controllers
{
    public class GiaoViensController : Controller
    {
        private readonly MVC_68Context _context;

        public GiaoViensController(MVC_68Context context)
        {
            _context = context;
        }

        // GET: GiaoViens
        public async Task<IActionResult> Index()
        {
            return View(await _context.GiaoVien.ToListAsync());
        }

        // GET: GiaoViens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaoVien = await _context.GiaoVien
                .FirstOrDefaultAsync(m => m.MGV == id);
            if (giaoVien == null)
            {
                return NotFound();
            }

            return View(giaoVien);
        }

        // GET: GiaoViens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GiaoViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MGV,TenGV,DiaChi")] GiaoVien giaoVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giaoVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giaoVien);
        }

        // GET: GiaoViens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaoVien = await _context.GiaoVien.FindAsync(id);
            if (giaoVien == null)
            {
                return NotFound();
            }
            return View(giaoVien);
        }

        // POST: GiaoViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MGV,TenGV,DiaChi")] GiaoVien giaoVien)
        {
            if (id != giaoVien.MGV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giaoVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiaoVienExists(giaoVien.MGV))
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
            return View(giaoVien);
        }

        // GET: GiaoViens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaoVien = await _context.GiaoVien
                .FirstOrDefaultAsync(m => m.MGV == id);
            if (giaoVien == null)
            {
                return NotFound();
            }

            return View(giaoVien);
        }

        // POST: GiaoViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giaoVien = await _context.GiaoVien.FindAsync(id);
            _context.GiaoVien.Remove(giaoVien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiaoVienExists(int id)
        {
            return _context.GiaoVien.Any(e => e.MGV == id);
        }
    }
}
