using System;


namespace DepilZone.Entidad.DTO
{
    public class FormDTO
    {
        public int IdTeleoperadora { get; set; }
        public string NombreCliente { get; set; }
        public string DocCliente { get; set; }
        public string FechaCita { get; set; }
        public int IdTipoCliente { get; set; }
        public int IdOrigen { get; set; }
        public int? IdServiciosPorPromocion { get; set; }
        public int IdPromociones { get; set; }
        public int IdSede { get; set; }
        public string NroOrigen { get; set; }
        public string? Observaciones { get; set; }
        public int IdUsuario { get; set; }
    }
    public class FilterFormDTO
    {
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public int? IdTeleoperadora { get; set; }
        public int? IdSede { get; set; }
        public int? IdUsuario { get; set; }
    }    
}
