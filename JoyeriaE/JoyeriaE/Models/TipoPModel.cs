using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JoyeriaE.Models
{
    public class TipoPModel
    {

        [Key]
        public int IdTipoP { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string NombreP { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public double Tamano { get; set; }


    }
}