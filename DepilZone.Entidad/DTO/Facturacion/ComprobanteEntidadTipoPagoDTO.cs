using System;

namespace DepilZone.Entidad.DTO.Facturacion
{
    public class ComprobanteEntidadTipoPagoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Valor { get; set; }
        public int IdEstado { get; set; }
    }

}
