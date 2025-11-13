using System;

namespace DepilZone.Entidad.DTO
{
    public class HistorialMensajeMasivoDTO
    {
        public int Id { get; set; }
        public string NombreArchivo { get; set; }
        public int NumeroRegistros { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }

        // secondary
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
    }

}
