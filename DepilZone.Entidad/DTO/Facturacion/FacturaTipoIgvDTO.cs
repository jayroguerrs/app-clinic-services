using System;

namespace DepilZone.Entidad.DTO.Facturacion
{
    public class FacturaTipoIgvDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string Valor { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdEstado { get; set; }
        public bool AplicaIgv { get; set; }
        public bool Gratuita { get; set; }
        public bool Inafecta { get; set; }
        public bool Exonerada { get; set; }

        // secondary
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public string Estado { get; set; }
    }

}
