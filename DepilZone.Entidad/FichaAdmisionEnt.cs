using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class FichaAdmisionEnt
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

        public string Observaciones { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }

        public ClienteEnt Cliente { get; set; }
        public IList<FichaAdmisionZonas> ZonasConsultar { get; set; }
        public IList<FichaAdmisionZonas> ZonasRealizar { get; set; }
        public IList<FichaAdmisionPatologia> Patologias { get; set; }
        public IList<FichaAdmisionPatologiaRespuesta> PatologiaRespuestas { get; set; }
    }


    public class FichaAdmisionPatologia
    {
        public int Id { get; set; }
        public int IdFichaAdmision { get; set; }
        public int IdPatologia { get; set; }
    }
    public class FichaAdmisionPatologiaRespuesta
    {
        public int Id { get; set; }
        public int IdFichaAdmision { get; set; }
        public int IdPatologia { get; set; }
        public int IdPatologiaPregunta { get; set; }
        public string Respuesta { get; set; }
    }
    public class FichaAdmisionZonas
    {
        public int Id { get; set; }
        public int IdTipoAccion { get; set; }
        public int IdFichaAdmision { get; set; }
        public int IdZonaCorporal { get; set; }
    }

}
