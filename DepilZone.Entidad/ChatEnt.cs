using System;

namespace DepilZone.Entidad
{
    public class ChatEnt
    {
        public Guid Id { get; set; }
        public int IdDeUsuario { get; set; }
        public int IdParaUsuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string Texto { get; set; }
        public int EstadoTexto { get; set; }
    }
}
