using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPruebaTymesa.Models
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class Medicinas
    {
        [Key]
        public int MedicinasID { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        public bool Cobrable { get; set; }

        public bool Generico { get; set; }

        public bool Activo { get; set; }


        
    }
}

