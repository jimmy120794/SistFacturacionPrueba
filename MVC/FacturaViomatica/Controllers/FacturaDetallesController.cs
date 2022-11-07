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
    public class FacturaDetallesController : Controller
    {
        private readonly FacturacionContext _context;

        public FacturaDetallesController(FacturacionContext context)
        {
            _context = context;
        }

        // GET: FacturaDetalles
        public async Task<IActionResult> Index()
        {
            var facturacionContext = _context.FacturaDetalles.Include(f => f.IdFactCabNavigation).Include(f => f.IdProductoNavigation);
            return View(await facturacionContext.ToListAsync());
        }

        // GET: FacturaDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FacturaDetalles == null)
            {
                return NotFound();
            }

            var facturaDetalle = await _context.FacturaDetalles
                .Include(f => f.IdFactCabNavigation)
                .Include(f => f.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facturaDetalle == null)
            {
                return NotFound();
            }

            return View(facturaDetalle);
        }

        // GET: FacturaDetalles/Create
        public IActionResult Create()
        {
            ViewData["IdFactCab"] = new SelectList(_context.FacturaCabeceras, "Id", "Id");
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id");
            return View();
        }

        // POST: FacturaDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdFactCab,IdProducto,Cantidad")] FacturaDetalle facturaDetalle)
        {
            if (ModelState.IsValid || !ModelState.IsValid)
            {
                _context.Add(facturaDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFactCab"] = new SelectList(_context.FacturaCabeceras, "Id", "Id", facturaDetalle.IdFactCab);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", facturaDetalle.IdProducto);
            return View(facturaDetalle);
        }

        // GET: FacturaDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FacturaDetalles == null)
            {
                return NotFound();
            }

            var facturaDetalle = await _context.FacturaDetalles.FindAsync(id);
            if (facturaDetalle == null)
            {
                return NotFound();
            }
            ViewData["IdFactCab"] = new SelectList(_context.FacturaCabeceras, "Id", "Id", facturaDetalle.IdFactCab);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", facturaDetalle.IdProducto);
            return View(facturaDetalle);
        }

        // POST: FacturaDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdFactCab,IdProducto,Cantidad")] FacturaDetalle facturaDetalle)
        {
            if (id != facturaDetalle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid || !ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturaDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaDetalleExists(facturaDetalle.Id))
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
            ViewData["IdFactCab"] = new SelectList(_context.FacturaCabeceras, "Id", "Id", facturaDetalle.IdFactCab);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", facturaDetalle.IdProducto);
            return View(facturaDetalle);
        }

        // GET: FacturaDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FacturaDetalles == null)
            {
                return NotFound();
            }

            var facturaDetalle = await _context.FacturaDetalles
                .Include(f => f.IdFactCabNavigation)
                .Include(f => f.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facturaDetalle == null)
            {
                return NotFound();
            }

            return View(facturaDetalle);
        }

        // POST: FacturaDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FacturaDetalles == null)
            {
                return Problem("Entity set 'FacturacionContext.FacturaDetalles'  is null.");
            }
            var facturaDetalle = await _context.FacturaDetalles.FindAsync(id);
            if (facturaDetalle != null)
            {
                _context.FacturaDetalles.Remove(facturaDetalle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaDetalleExists(int id)
        {
          return _context.FacturaDetalles.Any(e => e.Id == id);
        }
    }
}
