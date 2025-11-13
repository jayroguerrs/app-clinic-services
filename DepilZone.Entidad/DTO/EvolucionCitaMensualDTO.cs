using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class EvolucionCitaMensualDTO
    {
        public IList<DateTime> FechasSiguienteMes { get; set; }
        public IList<EvolucionCitaMensualCabeceraDTO> EvolucionCitaMensual { get; set; }
        public IList<DiasPorMesEvolucionDTO> Dias { get; set; }
        
    }

    public class EvolucionCitaMensualCabeceraDTO
    {
        public int Id { get; set; }
        public DateTime FechaProceso { get; set; }
        public DateTime FechaRegistra { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
        public IList<EvolucionCitaMensualDetalleDTO> Detalles { get; set; }
    }
    public class EvolucionCitaMensualDetalleDTO
    {
        public int Id { get; set; }
        public int IdEvolucionCitaMensual { get; set; }
        public DateTime Fecha { get; set; }
        public int Citas { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
    }

    public class DiasPorMesEvolucionDTO
    {
        public int Dias { get; set; }
        public string Nombre { get; set; }
        public int Mes { get; set; }
    }

    
}
