using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Entidad.DTO
{
    public class ParametroDTO
    {
    }

    public class HistorialParametroDTO
    {
        public int Sesion { get; set; }
        public string Parametro { get; set; }
        public string Maquina { get; set; }
    }

    public class ParametroUpdateDTO
    {
        public string Parametro { get; set; }
        public int IdCitaDetalle { get; set; }

    }
}
