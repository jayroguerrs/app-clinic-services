using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class CitaComisionDetalleDTO
    {
        public int IdCita { get; set; }
        public int IdZona { get; set; }
        public string ZonaCorporal { get; set; }
        public int IdUsuarioAgendado { get; set; }
        public string Operador { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaCita { get; set; }
        public decimal Comision { get; set; }
        public decimal PorcentajeComision { get; set; }
        public string Cliente { get; set; }
    }
}
