using System;

namespace DepilZone.Entidad.DTO.Facturacion
{
    public class FacturaDatosClienteDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Denominacion { get; set; }
        public string Direccion { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdEstado { get; set; }
        public bool Predeterminado { get; set; }

        // secondary
        public string TipoDocumento { get; set; }
        public string TipoDocumentoValor { get; set; }
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public string Estado { get; set; }
    }

}
