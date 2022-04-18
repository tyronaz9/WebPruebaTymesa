using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPruebaTymesa.Models
{

    [Index(nameof(Nombre), nameof(Apellido), IsUnique = true)]
    public class Pacientes
    {
        [Key]
        public int PacientesID { get; set; }

        [Required]
        [StringLength(200)]
      
        public string Nombre { get; set; }

        [Required]
        [StringLength(200)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(20)]
        public string Prefijo { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} value cannot exceed {1} characters. ", MinimumLength=10)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }

        [Required]
        [StringLength(1)]
        public string Sexo { get; set; }             
   
        public float Peso { get; set; }
        public float Altura { get; set; }
        public bool Activo { get; set; }

      

    }
}

