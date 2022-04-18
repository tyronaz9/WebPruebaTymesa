using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPruebaTymesa.Models
{
    public class Tipos
    {

        [Key]
        public int TiposID { get; set; }

        [Required]
        [StringLength(100)]
        public string Tipo { get; set; }

        [Required]
        [StringLength(1)]
        public string Sigla { get; set; }

        [Required]
        [StringLength(1)]
        public int Signo { get; set; }


    }
}
