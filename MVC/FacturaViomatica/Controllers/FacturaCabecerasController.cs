using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FacturaViomatica.Models.DB;

namespace FacturaViomatica.Controllers
{
    public class FacturaCabecerasController : Controller
    {
        private readonly FacturacionContext _context;

        public FacturaCabecerasController(FacturacionContext context)
        {
            _context = context;
        }

        // GET: FacturaCabeceras
        public async Task<IActionResult> Index()
        {
            var facturacionContext = _context.FacturaCabeceras.Include(f => f.IdClienteNavigation);
            return View(await facturacionContext.ToListAsync());
        }

        // GET: FacturaCabeceras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FacturaCabeceras == null)
            {
                return NotFound();
            }

            var facturaCabecera = await _context.FacturaCabeceras
                .Include(f => f.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facturaCabecera == null)
            {
                return NotFound();
            }

            return View(facturaCabecera);
        }

        // GET: FacturaCabeceras/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id");
            return View();
        }

        // POST: FacturaCabeceras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCliente,Fecha,FechaVence")] FacturaCabecera facturaCabecera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturaCabecera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", facturaCabecera.IdCliente);
            return View(facturaCabecera);
        }

        // GET: FacturaCabeceras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FacturaCabeceras == null)
            {
                return NotFound();
            }

            var facturaCabecera = await _context.FacturaCabeceras.FindAsync(id);
            if (facturaCabecera == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", facturaCabecera.IdCliente);
            return View(facturaCabecera);
        }

        // POST: FacturaCabeceras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCliente,Fecha,FechaVence")] FacturaCabecera facturaCabecera)
        {
            if (id != facturaCabecera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturaCabecera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaCabeceraExists(facturaCabecera.Id))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", facturaCabecera.IdCliente);
            return View(facturaCabecera);
        }

        // GET: FacturaCabeceras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FacturaCabeceras == null)
            {
                return NotFound();
            }

            var facturaCabecera = await _context.FacturaCabeceras
                .Include(f => f.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facturaCabecera == null)
            {
                return NotFound();
            }

            return View(facturaCabecera);
        }

        // POST: FacturaCabeceras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FacturaCabeceras == null)
            {
                return Problem("Entity set 'FacturacionContext.FacturaCabeceras'  is null.");
            }
            var facturaCabecera = await _context.FacturaCabeceras.FindAsync(id);
            if (facturaCabecera != null)
            {
                _context.FacturaCabeceras.Remove(facturaCabecera);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaCabeceraExists(int id)
        {
          return _context.FacturaCabeceras.Any(e => e.Id == id);
        }
    }
}
