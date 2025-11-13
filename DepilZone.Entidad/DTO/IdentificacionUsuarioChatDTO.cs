using System;

namespace DepilZone.Entidad.DTO
{
    public class IdentificacionUsuarioChatDTO
    {
        public int IdUsuario { get; set; }
        public DateTime FechaHoraConeccion{ get; set; }
        public string ConnectionId { get; set; }
    }
}
