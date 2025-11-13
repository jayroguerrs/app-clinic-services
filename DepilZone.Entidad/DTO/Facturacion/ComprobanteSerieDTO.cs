using System;

namespace DepilZone.Entidad.DTO.Facturacion
{
    public class ComprobanteSerieDTO
    {
        public int Id { get; set; }
        public int IdSede { get; set; }
        public int IdTipoComprobante { get; set; }
        public string Serie { get; set; }
        public int NumeroComprobante { get; set; }
        public string? Descripcion { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdEstado { get; set; }
        public int NumeroActual { get; set; }

        // secondary
        public string Sede { get; set; }
        public string TipoComprobante { get; set; }
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public string Estado { get; set; }
    }

}
