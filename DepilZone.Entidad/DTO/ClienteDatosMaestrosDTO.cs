using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class ClienteDatosMaestrosDTO
    {
        public IEnumerable<GeneroEnt> MaestroGenero { get; set; } 
        public IEnumerable<DocumentoIdentidadTipoEnt> MaestroDocumentoIdentidadTipo { get; set; }
        public IEnumerable<MedioContactoEnt> MaestroMedioContacto { get; set;  }
        public IEnumerable<DepartamentoDTO> MaestroDepartamento { get; set; }
    }
}
