using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class CitaAsignadaEnt
    {
        public int Id { get; set; }
        public int IdCita { get; set; }
        public int IdCitaAsignacion { get; set; }
        public int IdUsuarioOperador { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime FechaConfirmacion { get; set; }
        public int IdUsuarioRegistra { get; set; }
        public int Tipo { get; set; }
    }
}
