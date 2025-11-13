using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class CajaValidacionDTO
    {
        public bool CajaPermitida { get; set; }
        public string Mensaje { get; set; }
        public int Turno { get; set; }
    }
}
