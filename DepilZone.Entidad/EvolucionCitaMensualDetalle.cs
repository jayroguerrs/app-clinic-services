using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class EvolucionCitaMensualDetalle
    {
        public int Id { get; set; }
        public int IdEvolucionCitaMensual { get; set; }
        public DateTime Fecha { get; set; }
        public int Citas { get; set; }
    }
}
