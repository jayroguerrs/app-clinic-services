using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Entidad.DTO
{
    public class UsuarioActualizarDatosDTO
    {
        public int IdUsuario { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string FechaNacimiento { get; set; }
        public string NuevaClave { get; set; }
        public string? ColorSidebarDeFondo { get; set; }
        public string? ColorSidebarDeTexto { get; set; }
        public string? ImagenFondo { get; set; }
        public bool? DatosActualizados { get; set; }
    }
}
