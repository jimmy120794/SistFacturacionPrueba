using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacturaViomatica.Models;
using FacturaViomatica.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace FacturaViomatica.Controllers
{
    public class HomeController : Controller
    {
        private readonly FacturacionContext _context;

        public HomeController(FacturacionContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Clientes = _context.Clientes.ToList(); // select * from FacturaCabecera
            ViewBag.FacturaDetalles = _context.FacturaDetalles.ToList();

            ViewBag.AllProducts = _context.Productos.ToList();
            Console.WriteLine("ya fue mira ok22222!!");
            return View();
        }
        public bool ProductoExists(string NameProducto)
        {
            Console.WriteLine("ya fue mira ok!!");
            return _context.Clientes.Any(e => e.Nombre == NameProducto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetFactura([Bind("Id,Nombre,Empresa,DirEmpresa,TelEmpresa,Fecha_nac")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }
        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
        /*public async Task<IActionResult> Index()
        {
            var Clientes = _context.Clientes; // select * from FacturaCabecera
            Console.WriteLine("ya -->");
            return View(await Clientes.ToListAsync());
        }*/



    }
}