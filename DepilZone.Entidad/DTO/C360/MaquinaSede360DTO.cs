using System;
using System.Collections.Generic;

namespace DepilZone.Entidad.DTO.C360
{
    public class MaquinaSede360DisponibleDTO
    {
        public DateTime Fecha { get; set; }
        public int Porcentaje { get; set; }
        public int IdServicio { get; set; }
        public int IdSede { get; set; }

        // secondary
        #nullable enable
        public string? Servicio { get; set; }
        #nullable enable
        public string? Sede { get; set; }

    }

    public class MaquinaSede360DTO
    {
        public int IdMaquina { get; set; }
        public int Porcentaje { get; set; }
        public int IdServicio { get; set; }
        public int IdSede { get; set; }
        public int IdUsuarioRegistro { get; set; }

        // secondary
        #nullable enable
        public string? Maquina { get; set; }
        #nullable enable
        public string? Servicio { get; set; }
        #nullable enable
        public string? Sede { get; set; }
        public string? UsuarioRegistro { get; set; }
        public List<TecnologiaSDTO> Tecnologias { get; set; }

    }

    public class MaquinaSedeTecnologia360DTO
    {
        public int IdMaquinaSede { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public List<TecnologiaDTO> Tecnologias { get; set; }

        // secondary
        #nullable enable
        public string? Maquina { get; set; }

    }

}
