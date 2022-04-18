using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebPruebaTymesa.Models
{
  
    public class SP_F_ReporteMedicinas
    {
        [Key]
        public int Id { get; set; }
        public int PacientesID { get; set; }
        public string NombrePaciente { get; set; }
        public string Telefono { get; set; }
        public string Medicina { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}", ApplyFormatInEditMode = false)]
        public DateTime FechaIni { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}", ApplyFormatInEditMode = false)]
        public DateTime? FechaFin { get; set; }


    }
}
