using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPruebaTymesa.Data;
using WebPruebaTymesa.Models;

namespace WebPruebaTymesa.Controllers
{
    [Authorize]
    public class CuentasController : Controller
    {
        private readonly ApplicationDbContext _context;
        readonly Funciones fn = new Funciones();
        public CuentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cuentas
        public async Task<IActionResult> Index()
        {
          //  var applicationDbContext = _context.Cuentas.Include(c => c.Clientes);
           

            var usuario = User.Identity.Name;


            if (fn.Rol(_context, "ROLE_ADMIN", usuario))
            {
                return View(await _context.Cuentas.Include(c => c.Clientes).ToListAsync());
            }
            else
            {
                return View(await _context.Cuentas.Include(c => c.Clientes).Where(c=>c.Clientes.UserName==usuario).ToListAsync());
            
            }

        }

        // GET: Cuentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentas = await _context.Cuentas
                .Include(c => c.Clientes)
                .FirstOrDefaultAsync(m => m.CuentasID == id);
            if (cuentas == null)
            {
                return NotFound();
            }

            return View(cuentas);
        }

        // GET: Cuentas/Create
        public IActionResult Create()
        {

            var usuario = User.Identity.Name;



            if (fn.Rol(_context, "ROLE_ADMIN", usuario))
            {
             //   ViewData["UserNameID"] = new SelectList(_context.Users.Where(c => !_context.Clientes.Where(es => es.UserName == c.UserName).Any()), "UserName", "UserName");
                ViewData["ClientesID"] = new SelectList(_context.Clientes, "ClientesID", "Nombre");
            }
            else
            {
              
                ViewData["ClientesID"] = new SelectList(_context.Clientes.Where(c => c.UserName == usuario), "ClientesID", "Nombre");

            }

          
            return View();
        }

        // POST: Cuentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CuentasID,Numero,ClientesID")] Cuentas cuentas)
        {
            cuentas.Saldo =(float)(0);
            if (ModelState.IsValid)
            {
                _context.Add(cuentas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientesID"] = new SelectList(_context.Clientes, "ClientesID", "Nombre", cuentas.ClientesID);
            return View(cuentas);
        }

        // GET: Cuentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentas = await _context.Cuentas.FindAsync(id);
            if (cuentas == null)
            {
                return NotFound();
            }
            ViewData["ClientesID"] = new SelectList(_context.Clientes, "ClientesID", "Nombre", cuentas.ClientesID);
            return View(cuentas);
        }

        // POST: Cuentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CuentasID,Numero,Saldo,ClientesID")] Cuentas cuentas)
        {
            if (id != cuentas.CuentasID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuentas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuentasExists(cuentas.CuentasID))
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
            ViewData["ClientesID"] = new SelectList(_context.Clientes, "ClientesID", "Nombre", cuentas.ClientesID);
            return View(cuentas);
        }

        // GET: Cuentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentas = await _context.Cuentas
                .Include(c => c.Clientes)
                .FirstOrDefaultAsync(m => m.CuentasID == id);
            if (cuentas == null)
            {
                return NotFound();
            }

            return View(cuentas);
        }

        // POST: Cuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuentas = await _context.Cuentas.FindAsync(id);
            _context.Cuentas.Remove(cuentas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuentasExists(int id)
        {
            return _context.Cuentas.Any(e => e.CuentasID == id);
        }
    }
}
