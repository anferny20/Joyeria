using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JoyeriaE.Models
{
    public class ProvedorModel
    {

        [Key]
        public int IdProveedor { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Telefono { get; set; }

        //Dato de llave foranea
        [Required(ErrorMessage = "Requerido")]
        public int? IdItem { get; set; }



    }
}