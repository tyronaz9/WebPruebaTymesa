using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebPruebaTymesa.Models
{
    public class Movimientos
    {

        [Key]
        public int MovimientosID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = false)]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [NotMapped]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = false)]
        public DateTime FechaDesde { get; set; } = DateTime.Now;


        [NotMapped]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = false)]
        public DateTime FechaHasta { get; set; } = DateTime.Now;


        public int CuentasID { get; set; }

        public int TiposID { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Ingrese el field {0}")]
        [Range(00, 999999999,
         ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public float Valor { get; set; }


        public virtual Cuentas Cuentas { get; set; }

        public virtual Tipos Tipos { get; set; }



    }
}
