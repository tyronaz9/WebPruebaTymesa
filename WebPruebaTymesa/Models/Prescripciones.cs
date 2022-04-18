using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPruebaTymesa.Models
{
    public class Prescripciones
    {
        [Key]
        public int PrescripcionID { get; set; }
        public int PacientesID { get; set; }
        public int MedicinasID { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = false)]
        public DateTime FechaIni { get; set; } 


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = false)]
        public DateTime? FechaFin { get; set; }

        public virtual Pacientes Pacientes { get; set; }

        public virtual Medicinas Medicinas { get; set; }





    }
}
