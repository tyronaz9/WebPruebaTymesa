using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPruebaTymesa.Models
{
    [Index(nameof(Numero), IsUnique = true)]
    public class Cuentas
    {

        [Key]
        public int CuentasID { get; set; }

        public int Numero { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Ingrese el field {0}")]
        [Range(0, 999999999,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public float Saldo { get; set; }

        public int ClientesID { get; set; }


     
        public virtual Clientes Clientes { get; set; }

    }
}
