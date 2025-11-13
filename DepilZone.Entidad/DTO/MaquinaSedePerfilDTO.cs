using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class MaquinaSedePerfilDTO
    {
        public int Id { get; set; }
        public int IdMaquinaSede { get; set; }
        public int IdPerfil { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }

        // secondary
        public string UsuarioRegistro { get; set; }
        public List<int> IdPerfiles { get; set; }
        public string Perfil { get; set; }
        public string Maquina { get; set; }

    }
}
