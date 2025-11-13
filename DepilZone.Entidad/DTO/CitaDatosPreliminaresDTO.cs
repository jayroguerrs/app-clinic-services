using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class CitaDatosPreliminaresDTO
    {
        public IList<CitaTipoEnt> CitaTipos { get; set; }
        public IList<TipoClienteEnt> ClienteTipos { get; set; }
        public IList<UsuarioGridDTO> Usuarios { get; set; }
        public IList<SedeEnt> Sedes { get; set; }
        public IList<ZonaCorporalGridDTO> ZonasCorporales { get; set; }
        public IList<MaquinaSedeGridDTO> MaquinaSedes { get; set; }
    }
}
