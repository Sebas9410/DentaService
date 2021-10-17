using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DentaService.API.Data;
using DentaService.API.Data.Entities;

namespace DentaService.API.Controllers
{
    public class ShedulesController : Controller
    {
        private readonly DataContext _context;

        public ShedulesController(DataContext context)
        {
            _context = context;
        }

 
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shedules.ToListAsync());
        }

        

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Shedule shedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shedule);
        }

  
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shedule = await _context.Shedules.FindAsync(id);
            if (shedule == null)
            {
                return NotFound();
            }
            return View(shedule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Shedule shedule)
        {
            if (id != shedule.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SheduleExists(shedule.ID))
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
            return View(shedule);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shedule = await _context.Shedules
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shedule == null)
            {
                return NotFound();
            }

            _context.Shedules.Remove(shedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool SheduleExists(int id)
        {
            return _context.Shedules.Any(e => e.ID == id);
        }
    }
}
