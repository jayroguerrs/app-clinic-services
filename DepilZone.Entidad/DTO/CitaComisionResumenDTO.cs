using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class CitaComisionResumenDTO
    {
        public int NumCitas { get; set; }
        public int NumZonas { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoComision { get; set; }
        public decimal MontoComisionIgv { get; set; }
        public int IdUsuarioOperador { get; set; }
        public string UsuarioOperador { get; set; }
    }
}
