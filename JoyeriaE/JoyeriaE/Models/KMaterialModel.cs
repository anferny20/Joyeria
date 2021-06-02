using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JoyeriaE.Models
{
    public class KMaterialModel
    {
        [Key]
        public int IdKMaterial { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Kilate { get; set; }

    }
}