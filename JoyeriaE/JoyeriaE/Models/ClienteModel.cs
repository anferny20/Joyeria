using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JoyeriaE.Models
{
    public class ClienteModel
    {


        [Key]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public int Monto { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Telefono { get; set; }


    }
}