using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Entidad.DTO
{
    public class PersonalizarClinicDTO
    {
        public int IdUsuario { get; set; }
        public string? ColorSidebarDeFondo { get; set; }
        public string? ColorSidebarDeTexto { get; set; }
        public string? ImagenFondo { get; set; }
    }
}
