using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class TipoComprobanteEnt
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public int IdEstado { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioEdita { get; set; }
        public DateTime? FechaEdita { get; set; }


        public int? IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public string? UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public string? Valor { get; set; }
        public bool PuntoVenta { get; set; }

    }
}
