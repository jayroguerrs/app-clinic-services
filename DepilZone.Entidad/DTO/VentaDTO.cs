using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class VentaDTO
    {
        public int Id { get; set; }
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public decimal TotalVenta { get; set; }

        public DateTime Fecha { get; set; }
    }

    public class VentaPotencialDTO
    {
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public string MedioContacto { get; set; }
        public string Sede { get; set; }
        public string ClienteActivo { get; set; }
        public string Servicio { get; set; }
        public List<VentaPotencial_CitasDTO> Citas { get; set; }
    }

    public class VentaPotencial_CitasDTO {
        public string AtendidoPor { get; set; }
        public DateTime FechaCita { get; set; }
        public decimal Total { get; set; }
    }
         

         
    
}
