using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class LibroReclamacionDTO
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Nombres { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Domicilio { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string EmailCC { get; set; }
        public string NombrePadres { get; set; }
        public string Tipo { get; set; }
        public decimal MontoReclamado { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public string Pedido { get; set; }
        public string TipoReclamo { get; set; }
        public int EstadoReclamacion { get; set; }
        public string Sede { get; set; }
        public string ZonaCorporal { get; set; }
    }
}
