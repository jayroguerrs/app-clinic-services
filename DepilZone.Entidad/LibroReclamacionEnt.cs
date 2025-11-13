using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class LibroReclamacionEnt
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Nombres { get; set; }
        public int IdDepartamento { get; set; }
        public int IdProvincia { get; set; }
        public int IdDistrito { get; set; }
        public string  Domicilio { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string NombrePadres { get; set; }
        public int TipoBien { get; set; }
        public decimal MontoReclamado { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public string Pedido { get; set; }
        public int TipoReclamacion { get; set; }
        public int EstadoReclamacion { get; set; }
        public int? IdSede { get; set; }
        public string ZonaCorporal { get; set; }

    }
}
