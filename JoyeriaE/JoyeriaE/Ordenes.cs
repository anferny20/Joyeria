//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JoyeriaE
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ordenes
    {
        public int IdOrden { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public int IdItem { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaFinalizacion { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Empleados Empleados { get; set; }
        public virtual Items Items { get; set; }
    }
}