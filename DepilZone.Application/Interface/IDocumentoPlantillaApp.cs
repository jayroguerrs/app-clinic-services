using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IDocumentoPlantillaApp
    {
        Task<IEnumerable<DocumentoPlantillaDTO>> ObtenerListado();

        Task<Respuesta<DocumentoPlantillaEnt>> ObtenerById(int Id);

        Task<Respuesta<DocumentoPlantillaEnt>> Insertar(DocumentoPlantillaDTO model);

        Task<Respuesta<DocumentoPlantillaEnt>> Modificar(DocumentoPlantillaDTO model);
    }
}