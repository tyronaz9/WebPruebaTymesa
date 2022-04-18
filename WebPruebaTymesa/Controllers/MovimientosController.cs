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
    public class MovimientosController : Controller
    {
        private readonly ApplicationDbContext _context;
        readonly Funciones fn = new Funciones();
        public MovimientosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movimientos
        public async Task<IActionResult> Index()
        {
         
            var usuario = User.Identity.Name;


            if (fn.Rol(_context, "ROLE_ADMIN", usuario))
            {
                return View(await _context.Movimientos.Include(m => m.Cuentas).Include(m => m.Tipos).Include(m => m.Cuentas.Clientes).OrderBy(c => c.Fecha).ToListAsync());
            }
            else
            {
               
                return View(await _context.Movimientos.Include(m => m.Cuentas).Include(m => m.Tipos).Include(m => m.Cuentas.Clientes).Where(c => c.Cuentas.Clientes.UserName == usuario).OrderBy(c => c.Fecha).ToListAsync());

            }





           
        }

        // GET: EstadoCuenta
        public async Task<IActionResult> EstadoCuenta(string Buscar, DateTime Fechai , DateTime Fechaf)
        {
            var applicationDbContext = _context.Movimientos.Include(m => m.Cuentas).Include(m => m.Tipos).Include(m => m.Cuentas.Clientes).Where(c=> c.Fecha.Date >= Fechai && c.Fecha.Date<= Fechaf.Date).OrderBy(c => c.Fecha);


            if (!string.IsNullOrEmpty(Buscar))
            {
                foreach (var item in Buscar.Split(new char[] { ' ' },
                         StringSplitOptions.RemoveEmptyEntries))
                {
                    applicationDbContext = applicationDbContext.Where(x => x.Cuentas.Clientes.Nombre.Contains(item))
                        .OrderBy(c=>c.Cuentas.Clientes.Nombre).ThenBy(c=>c.Fecha);
                                                  
                }
            }
            return View(await applicationDbContext.ToListAsync());
        
        }



        // GET: Movimientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientos = await _context.Movimientos
                .Include(m => m.Cuentas)
                .Include(m => m.Tipos)
                .FirstOrDefaultAsync(m => m.MovimientosID == id);
            if (movimientos == null)
            {
                return NotFound();
            }

            return View(movimientos);
        }

        // GET: Movimientos/Create
        public IActionResult Create()
        {
            ViewData["CuentasID"] = new SelectList(_context.Cuentas, "CuentasID", "Numero");
            ViewData["TiposID"] = new SelectList(_context.Tipos, "TiposID", "Sigla");

            return View();
           
         
        }

        // POST: Movimientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovimientosID,Fecha,CuentasID,TiposID,Valor")] Movimientos movimientos)
        {
           
            if (ModelState.IsValid)
            {

                using (var transacction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        movimientos.Fecha = DateTime.Now;
                        if (ActualizarSaldo(movimientos, out float _NewSaldo)) {

                            await _context.SaveChangesAsync();

                            _context.Add(movimientos);
                            await _context.SaveChangesAsync();

                             transacction.Commit();

                            return RedirectToAction(nameof(Index));

                        };


                        ViewBag.Error = "ERROR: " +"Saldo Insuficiente";
                        transacction.Rollback();
                     


                    }
                    catch (Exception ex)
                    {

                        if (ex.InnerException == null)
                        {
                            ViewBag.Error = "ERROR: " + ex.Message;
                        }
                        else
                        {
                            ViewBag.Error = "ERROR: " + ex.InnerException.InnerException.Message.ToString();
                        }
                     

                        transacction.Rollback();
                    }
                   
                }
              
            }
            ViewData["CuentasID"] = new SelectList(_context.Cuentas, "CuentasID", "Numero", movimientos.CuentasID);
            ViewData["TiposID"] = new SelectList(_context.Tipos, "TiposID", "Sigla", movimientos.TiposID);
            return View(movimientos);
        }

        private bool ActualizarSaldo(Movimientos movimientos,out float NewSaldo)
        {
            bool estado = true;
            int signo;
            float Saldo;
            var _Tipo = _context.Tipos.Find(movimientos.TiposID);
            signo = _Tipo.Signo;

            var _Cuenta = _context.Cuentas.Find(movimientos.CuentasID);
            Saldo = _Cuenta.Saldo + (movimientos.Valor * signo);

            NewSaldo = Saldo;

            if (Saldo < 0)
            {
                estado = false;
            }
            else
            {
                _Cuenta.Saldo = Saldo;
                _context.Update(_Cuenta);
                estado = true;
            }

          

            return estado;
        }

        // GET: Movimientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientos = await _context.Movimientos.FindAsync(id);
            if (movimientos == null)
            {
                return NotFound();
            }
            ViewData["CuentasID"] = new SelectList(_context.Cuentas, "CuentasID", "CuentasID", movimientos.CuentasID);
            ViewData["TiposID"] = new SelectList(_context.Tipos, "TiposID", "Sigla", movimientos.TiposID);
            return View(movimientos);
        }

        // POST: Movimientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovimientosID,Fecha,CuentasID,TiposID,Valor")] Movimientos movimientos)
        {
            if (id != movimientos.MovimientosID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimientos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientosExists(movimientos.MovimientosID))
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
            ViewData["CuentasID"] = new SelectList(_context.Cuentas, "CuentasID", "CuentasID", movimientos.CuentasID);
            ViewData["TiposID"] = new SelectList(_context.Tipos, "TiposID", "Sigla", movimientos.TiposID);
            return View(movimientos);
        }

        // GET: Movimientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientos = await _context.Movimientos
                .Include(m => m.Cuentas)
                .Include(m => m.Tipos)
                .FirstOrDefaultAsync(m => m.MovimientosID == id);
            if (movimientos == null)
            {
                return NotFound();
            }

            return View(movimientos);
        }

        // POST: Movimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimientos = await _context.Movimientos.FindAsync(id);
            _context.Movimientos.Remove(movimientos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientosExists(int id)
        {
            return _context.Movimientos.Any(e => e.MovimientosID == id);
        }
    }
}
