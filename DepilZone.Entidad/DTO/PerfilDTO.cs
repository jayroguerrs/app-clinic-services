using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class PerfilDTO
    {
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public IEnumerable<PerfilDetalleDTO> PerfilDetalle { get; set; }
    }
}
