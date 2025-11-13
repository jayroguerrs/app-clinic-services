using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class ClienteEncuestaDTO
    {
        // primary props
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int? IdDistrito { get; set; }
        public int IdSede { get; set; }
        public int EfectividadTratamiento { get; set; }
        public int AtencionCliente { get; set; }
        public int ClaridadInformativa { get; set; }
        public int BrindoInformacionPromo { get; set; }
        public int Medio { get; set; }
        public string? Sugerencias { get; set; }
        public int IdEspecialista { get; set; }
        public DateTime FechaCreacion { get; set; }

        // secondary props
        public string Cliente { get; set; }
        public string Distrito { get; set; }
        public string Sede { get; set; }
        public string VEfectividadTratamiento { get; set; }
        public string VAtencionCliente { get; set; }
        public string VClaridadInformativa { get; set; }
        public string VBrindoInformacionPromo { get; set; }
        public string VMedio { get; set; }
        public string VEspecialista { get; set; }

    }



    public class CE_PreguntaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<CE_Resultado> Resultados {get; set;}
    }

    public class CE_Resultado
    {
        public int Total { get; set; }
        public string Item { get; set; }
    }

}