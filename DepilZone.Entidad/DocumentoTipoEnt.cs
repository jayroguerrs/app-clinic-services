using System;
using System.Collections.Generic;

namespace DepilZone.Entidad
{
	public class DocumentoTipoEnt
	{
		public int Id { get; set; }
        //public int? IdPerfil { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }

        public int? Version { get; set; }

        public IList<DocumentoTipoPerfilEnt> Perfiles { get; set; }

        public int? IdServicio { get; set; }



        public bool BlPromocion { get; set; }
        public bool BlZona { get; set; }
        public bool BlPatologia { get; set; }
        public bool BlApoderado { get; set; }
        public bool BlMantenimiento { get; set; }
        public bool BlRetroceso { get; set; }

    }

    public class DocumentoTipoPerfilEnt
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }


    public class DocumentoPlantillaEnt
	{
		public int Id { get; set; }
        public int IdDocumentoTipo { get; set; }
        public string Plantilla { get; set; }
        public int Version { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioRegistra { get; set; }

        public DP_DocumentoEnt Documento { get; set; }
        public string ImagenCabeceraDocumento { get; set; }
        public string ImagenPieDocumento { get; set; }
        public string Html { get; set; }
        public string Margin { get; set; }
    }

    public class DP_DocumentoEnt
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
