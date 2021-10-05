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
    public class HocSinhsController : Controller
    {
        private readonly MVC_68Context _context;

        public HocSinhsController(MVC_68Context context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string HocSinhGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.HocSinh
                                            orderby m.DiaChi
                                            select m.DiaChi;

            var movies = from m in _context.HocSinh
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.DiaChi.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(HocSinhGenre))
            {
                movies = movies.Where(x => x.DiaChi == HocSinhGenre);
            }

            var movieGenreVM = new HocSinhGenreViewModel
            {
                DiaChi = new SelectList(await genreQuery.Distinct().ToListAsync()),
                HocSinhs = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        // GET: HocSinhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocSinh = await _context.HocSinh
                .FirstOrDefaultAsync(m => m.MaSV == id);
            if (hocSinh == null)
            {
                return NotFound();
            }

            return View(hocSinh);
        }

        // GET: HocSinhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HocSinhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSV,HoaTen,NamSinh,DiaChi,Email,SDT")] HocSinh hocSinh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hocSinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hocSinh);
        }

        // GET: HocSinhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocSinh = await _context.HocSinh.FindAsync(id);
            if (hocSinh == null)
            {
                return NotFound();
            }
            return View(hocSinh);
        }

        // POST: HocSinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSV,HoaTen,NamSinh,DiaChi,Email,SDT")] HocSinh hocSinh)
        {
            if (id != hocSinh.MaSV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hocSinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HocSinhExists(hocSinh.MaSV))
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
            return View(hocSinh);
        }

        // GET: HocSinhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocSinh = await _context.HocSinh
                .FirstOrDefaultAsync(m => m.MaSV == id);
            if (hocSinh == null)
            {
                return NotFound();
            }

            return View(hocSinh);
        }

        // POST: HocSinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hocSinh = await _context.HocSinh.FindAsync(id);
            _context.HocSinh.Remove(hocSinh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HocSinhExists(int id)
        {
            return _context.HocSinh.Any(e => e.MaSV == id);
        }
    }
}
