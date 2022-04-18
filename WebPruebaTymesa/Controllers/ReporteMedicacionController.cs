using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebPruebaTymesa.Data;
using WebPruebaTymesa.Models;

namespace WebPruebaTymesa.Controllers
{
    public class ReporteMedicacionController : Controller
    {
      
        private readonly ApplicationDbContext _context;

        private PaginadorGenerico<SP_F_ReporteMedicinas> _PaginadorCustomers;

        private readonly int _RegistrosPorPagina = 10;
        //  readonly Funciones fn = new Funciones();
        public ReporteMedicacionController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ReporteMedicacion
        public ActionResult Index(int pagina = 1)
        {
           
            int _TotalRegistros = 0;


            var _dato = _context.SP_F_ReporteMedicinas.FromSqlRaw("EXECUTE dbo.F_Reporte_MEdicinas")
             .ToList();


            // Número total de páginas de la tabla Customers
            _TotalRegistros = _dato.Count();

            // Obtenemos la 'página de registros' de la tabla Customers
            _dato = _dato.OrderBy(x => x.NombrePaciente)
                                             .Skip((pagina - 1) * _RegistrosPorPagina)
                                             .Take(_RegistrosPorPagina)
                                             .ToList();


            var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);
            // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
            _PaginadorCustomers = new PaginadorGenerico<SP_F_ReporteMedicinas>()
            {
                RegistrosPorPagina = _RegistrosPorPagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                Resultado = _dato
            };
            // Enviamos a la Vista la 'Clase de paginación'
            return View(_PaginadorCustomers);
           

        }



        public ActionResult Indice()
        {
            //conexion



            var _dato = _context.SP_F_ReporteMedicinas.FromSqlRaw("EXECUTE dbo.F_Reporte_MEdicinas")
             .ToList();
            return View(_dato);

        }




    }
}
