using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebPruebaTymesa.Data;
using WebPruebaTymesa.Models;

namespace WebPruebaTymesa.Controllers
{
    public class BitacoraController : Controller
    {

        private readonly ApplicationDbContext _context;

       

        public BitacoraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BitacoraController

    

       /* public async Task<IActionResult> Indexx(string Tabla, DateTime Fechai, DateTime Fechaf)
        {
            var applicationDbContext = _context.dto.Include(m => m.Cuentas).Include(m => m.Tipos).Include(m => m.Cuentas.Clientes).Where(c => c.Fecha.Date >= Fechai && c.Fecha.Date <= Fechaf.Date).OrderBy(c => c.Fecha);


            if (!string.IsNullOrEmpty(Tabla))
            {
                foreach (var item in Tabla.Split(new char[] { ' ' },
                         StringSplitOptions.RemoveEmptyEntries))
                {
                    applicationDbContext = applicationDbContext.Where(x => x.Cuentas.Clientes.Nombre.Contains(item))
                        .OrderBy(c => c.Cuentas.Clientes.Nombre).ThenBy(c => c.Fecha);

                }
            }
            return View(await applicationDbContext.ToListAsync());

        }*/

        public ActionResult Index(string Tabla,string Operacion,string Usuario ,DateTime Fechai, DateTime Fechaf)
        {
          

            List<DtoArchivo> _datos = new List<DtoArchivo>();

          

            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\temp\\Test\\TyronMejia\\Bitacora.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                  //  Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                    if (line != null) {
                        var _dato = new DtoArchivo()
                        {
                            Dato = line
                        };


                       
                        _datos.Add(_dato);
                    }
                }
                //close the file
                sr.Close();
              //  Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            if (!string.IsNullOrEmpty(Tabla))
            {
                foreach (var item in Tabla.Split(new char[] { ' ' },
                         StringSplitOptions.RemoveEmptyEntries))
                {
                    _datos = _datos.Where(x => x.Dato.Contains(item))
                        .OrderBy(c => c.Dato).ToList();

                }
            }

            if (!string.IsNullOrEmpty(Operacion))
            {
                foreach (var item in Operacion.Split(new char[] { ' ' },
                         StringSplitOptions.RemoveEmptyEntries))
                {
                    _datos = _datos.Where(x => x.Dato.Contains(item))
                        .OrderBy(c => c.Dato).ToList();

                }
            }

            if (!string.IsNullOrEmpty(Usuario))
            {
                foreach (var item in Usuario.Split(new char[] { ' ' },
                         StringSplitOptions.RemoveEmptyEntries))
                {
                    _datos = _datos.Where(x => x.Dato.Contains(item))
                        .OrderBy(c => c.Dato).ToList();

                }
            }

            return View(_datos);
        }

       

    }
}
