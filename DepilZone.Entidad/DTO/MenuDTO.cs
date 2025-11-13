using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class MenuDTO
    {
        public int IdMenu { get; set; }
        public int? IdPadre { get; set; }
        public string Title { get; set; }
        public string IdMenuTipo { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string Id { get; set; }
        public bool Visible { get; set; }
        public int Nivel { get; set; }
        public string Type { get; set; }        
        public ICollection<MenuDTO> Children { get; set; }        
        public bool Seleccionado { get; set; }
        //public ICollection<Domain.Entities.Accion> Acciones { get; set; }
        //public ICollection<MenuAccionDto> MenuAcciones { get; set; }
        public List<int> Privilegios { get; set; } = new List<int>();
    }

}
