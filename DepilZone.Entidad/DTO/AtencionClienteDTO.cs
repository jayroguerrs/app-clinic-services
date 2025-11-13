using System;

namespace DepilZone.Entidad.DTO
{
    public class AtencionClienteDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdSede { get; set; }
        public int IdEstado { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int IdUsuarioModifico { get; set; }
        public int FechaRegistro { get; set; }
        public int FechaModifico { get; set; }


        // secondary
        public string UsuarioRegistro { get; set; }
        public string UsuarioModifico { get; set; }

    }


    public class AtencionClienteRegistrarDTO
    {
        public int IdSede { get; set; }
        public string LlaveCliente { get; set; } 
        public DateTime Fecha { get; set; }
        public int IdUsuarioRegistro { get; set; }
    }


}
