using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPruebaTymesa.Models
{

    [Index(nameof(UserName), IsUnique = true)]

    public class Clientes
    {
        [Key]
        public int ClientesID { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(400)]
        public string Direccion { get; set; }

        [Required]      
        [StringLength(60)]
        public string Telefono { get; set; }


        [Required]
      
        [StringLength(256)]
        public string UserName { get; set; }

        public virtual ICollection<Cuentas> Cuentas { get; set; }

    }
}
