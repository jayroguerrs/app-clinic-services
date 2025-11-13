using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class IncidenciaListadoGrillaDTO
    {
        public int Id { get; set; }
        public int IdModuloSistema { get; set; }
        public string Modulo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
        public string Prioridad { get; set; }
        public DateTime FechaRegistra { get; set; }
        public DateTime? FechaPublica { get; set; }

    }

    public class IncidenciaNivelAtencion
    {
        public int NumeroCitas { get; set; }
        public decimal Total { get; set; }
    }
}
