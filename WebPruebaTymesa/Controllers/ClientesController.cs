using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPruebaTymesa.Data;
using WebPruebaTymesa.Models;

namespace WebPruebaTymesa.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        readonly Funciones fn = new Funciones();

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var usuario = User.Identity.Name;
          

            if  (fn.Rol(_context, "ROLE_ADMIN",usuario))          
            {
                return View(await _context.Clientes.ToListAsync());
            }
            else
            {

                return View(await _context.Clientes.Where(c=> c.UserName==usuario).ToListAsync());
            }


          
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClientesID == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }


        // GET: Clientes/Create
        public IActionResult Create()
        {

            var usuario = User.Identity.Name;

           

            if (fn.Rol(_context, "ROLE_ADMIN", usuario))
            {
                ViewData["UserNameID"] = new SelectList(_context.Users.Where(c => !_context.Clientes.Where(es => es.UserName == c.UserName).Any()), "UserName", "UserName");
              
            }
            else
            {
                ViewData["UserNameID"] = new SelectList(_context.Users.Where(c => c.UserName == usuario), "UserName", "UserName");

            }


          
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientesID,Nombre,Direccion,Telefono,UserName")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }


            var usuario = User.Identity.Name;


            if (fn.Rol(_context, "ROLE_ADMIN", usuario))
            {
                ViewData["UserNameID"] = new SelectList(_context.Users.Where(c => c.UserName == usuario), "UserName", "UserName");
            }
            else
            {

                ViewData["UserNameID"] = new SelectList(_context.Users.Where(c => !_context.Clientes.Where(es => es.UserName == c.UserName).Any()), "UserName", "UserName");
            }


            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientesID,Nombre,Direccion,Telefono,UserName")] Clientes clientes)
        {
            if (id != clientes.ClientesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.ClientesID))
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
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClientesID == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesExists(int id)
        {
            return _context.Clientes.Any(e => e.ClientesID == id);
        }
    }
}
