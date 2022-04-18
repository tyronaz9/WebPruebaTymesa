using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPruebaTymesa.Models
{
    public class DtoArchivo
    {
       public string Dato  { get; set; }
       [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = false)]
       public DateTime Fecha { get; set; } = DateTime.Now;

    }
}
