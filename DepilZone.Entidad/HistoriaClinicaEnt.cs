using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class HistoriaClinicaEnt
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
    }
}
