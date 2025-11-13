using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class DescuentoDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Porcentaje { get; set; }

        public string? UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
    }
}
