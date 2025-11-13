using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class MaquinaSedeGridDTO
    {
        public int Id { get; set; }
        public int IdMaquina { get; set; }
        public string Maquina { get; set; }
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public string Descripcion { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public int IdEstado { get; set; }
        public int IdFicticio { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime FechaModifca { get; set; }
        public int? IdServicio { get; set; }
        public string Color { get; set; }

        // secondary
        public string? Servicio { get; set; }
        public string? ServicioColor { get; set; }
        public List<TecnologiaSDTO> Tecnologias { get; set; }

        public List<MaquinaSedePerfilDTO> Perfiles { get; set; }

    }
}
