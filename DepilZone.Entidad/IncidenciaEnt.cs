using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class IncidenciaEnt
    {
        public int Id { get; set; }
        public int IdModuloSistema { get; set; }
        public string Descripcion { get; set; }
        public int IdEstadoIncidencia { get; set; }
        public int IdUsuarioRegistra { get; set; }
        public int IdPrioridad { get; set; }
        public DateTime FechaRegistra { get; set; }
        public DateTime? FechaPublica { get; set; }
    }
}
