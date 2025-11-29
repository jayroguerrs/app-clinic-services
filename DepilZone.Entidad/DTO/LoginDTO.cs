using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class LoginDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }        
        public string Perfil { get; set; }
        public int IdPerfil { get; set; }
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public string Foto { get; set; }
        public DateTime FechaRegistra { get; set; }
        public IList<MenuDTO> Menu { get; set; }
        public object MenuUsuario { get; set; }
        public string? ColorSidebarDeFondo { get; set; }
        public string? ColorSidebarDeTexto { get; set; }
        public string? ImagenDeFondo { get; set; }
        public bool? DatosActualizados { get; set; }
        public int Privilegio { get; set; }
        public int? Aprobado { get; set; }
        public int? IdSupervisor { get; set; }
        public string? CaptchaToken { get; set; }
        public bool? ClaveGenerica { get; set; }

    }

    public class MenuUsuarioPadreDTO
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; }
        public bool State { get; set; }
        public List<string> Profiles { get; set; }
        public List<MenuUsuarioOptionDTO> Options { get; set; }
    }

    public class MenuUsuarioOptionDTO
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public bool State { get; set; }
        public List<string> Actions { get; set; }
    }
}
