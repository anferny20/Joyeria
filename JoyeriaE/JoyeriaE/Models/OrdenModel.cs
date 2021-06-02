using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JoyeriaE.Models
{
    public class OrdenModel
    {   
        [Key]
        public int IdOrden { get; set; }

        //Datos Externos de otras tablas
        [Required(ErrorMessage = "Requerido")]
        public int IdCliente { get; set; }

        [Display(Name = "Nombre Cliente")]
        public string NombreC { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public int IdEmpleado { get; set; }
        [Display(Name = "Nombre Empleado")]
        public string NombreE { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public int IdItem { get; set; }

        [Display(Name ="Nombre Item")]
        public string NombreI { get; set; }
        // Aqui termina los datos de las otras tablas

        [Display(Name = "Fecha de Creación")]
        [Required(ErrorMessage = "Requerido")]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = "Fecha de Finalización")]
        [Required(ErrorMessage = "Requerido")]
        public DateTime FechaFinalizacion { get; set; }

    }
}