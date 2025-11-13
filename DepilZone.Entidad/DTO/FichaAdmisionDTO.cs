using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class FichaAdmisionDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public bool TieneMedicacion { get; set; }
        public string IndiqueMedicacion { get; set; }
        public bool AplicaProductoTopico { get; set; }
        public bool AntecedentePatologico { get; set; }
        public int TipoCicatrizacion { get; set; }
        public int BebeAlcohol { get; set; }
        public bool EsFumador { get; set; }
        public int IdUsuarioRegistra { get; set; }
        public int IdUsuarioEdita { get; set; }

        public string Observaciones { get; set; }
        public DateTime FechaRegistra { get; set; }
        public DateTime? FechaEdita { get; set; }

        //Secondary
        public string UsuarioRegistra { get; set; }
        public string? UsuarioEdita { get; set; }

        public ClienteEnt Cliente { get; set; }
        public IList<FichaAdmisionZonasDTO> ZonasConsultar { get; set; }
        public IList<FichaAdmisionZonasDTO> ZonasRealizar { get; set; }
        public IList<FichaAdmisionPatologiaDTO> Patologias { get; set; }
        public IList<FichaAdmisionPatologiaRespuestaDTO> PatologiaRespuestas { get; set; }
    }

    public class FichaAdmisionPatologiaDTO
    {
        public int Id { get; set; }
        public int IdFichaAdmision { get; set; }
        public int IdPatologia { get; set; }

        // secondary
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
    public class FichaAdmisionPatologiaRespuestaDTO
    {
        public int Id { get; set; }
        public int IdFichaAdmision { get; set; }
        public int IdPatologia { get; set; }
        public int IdPatologiaPregunta { get; set; }
        public string Respuesta { get; set; }
    }
    public class FichaAdmisionZonasDTO
    {
        public int Id { get; set; }
        public int IdTipoAccion { get; set; }
        public int IdFichaAdmision { get; set; }
        public int IdZonaCorporal { get; set; }
        public string Descripcion { get; set; }
    }
}
