using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebPruebaTymesa.Models;

namespace WebPruebaTymesa.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Banca
        public DbSet<WebPruebaTymesa.Models.Clientes> Clientes { get; set; }

        public DbSet<WebPruebaTymesa.Models.Cuentas> Cuentas { get; set; }

        public DbSet<WebPruebaTymesa.Models.Tipos> Tipos { get; set; }

        public DbSet<WebPruebaTymesa.Models.Movimientos> Movimientos { get; set; }


        //Salud
        public DbSet<WebPruebaTymesa.Models.Medicinas> Medicinas { get; set; }

        public DbSet<WebPruebaTymesa.Models.Pacientes> Pacientes { get; set; }

        public DbSet<WebPruebaTymesa.Models.Prescripciones> Prescripciones { get; set; }

        public DbSet<WebPruebaTymesa.Models.SP_F_ReporteMedicinas> SP_F_ReporteMedicinas { get; set; }


    }
}
