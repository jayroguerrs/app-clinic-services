using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class PerfilConfiguracionDTO
    {
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }

        public IList<MenuDTO> Menus { get; set; }
        public IList<DashboardElementoDTO> DashboardElementos { get; set;  }

        public IList<PerfilDetalleDTO> Detalle { get; set; }
    }
}
