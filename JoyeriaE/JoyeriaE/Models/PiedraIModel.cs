using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JoyeriaE.Models
{
    public class PiedraIModel
    {
        [Key]
        public int IdItem { get; set; }

        [Key]
        public int IdTipoP { get; set; }
     
    }
}