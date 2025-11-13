using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class EnvioEmailEnt
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public int IdCliente { get; set; }
        public string CodigoTabla { get; set; }
        public string NombresCompletos { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string Descripcion { get; set; }
        public int IdSede { get; set; }
        public string Celular { get; set; }
    }
}
