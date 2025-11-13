using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IDocumentoIdentidadTipoDom
    {
        Task<IEnumerable<DocumentoIdentidadTipoEnt>> Obtener();
    }
}
