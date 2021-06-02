using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JoyeriaE.Models
{
    public class ItemModel
    {
        [Key]
        public int IdItem { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public int Precio { get; set; }

        [Required(ErrorMessage = "Requerido")]     
        public int Costo { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [MaxLength(4, ErrorMessage = "El valor no puede tener más de 1 caracteres")]
        public int IdKMaterial { get; set; }

        public string Image { get; set; }

    }
}