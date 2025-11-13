using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DepilZone.Application.Implement
{
    public class LibroReclamacionApp: ILibroReclamacionApp
    {
        private readonly ILibroReclamacionDom _ILibroReclamacionDom;
        public LibroReclamacionApp(ILibroReclamacionDom ILibroReclamacionDom)
        {
            this._ILibroReclamacionDom = ILibroReclamacionDom;
        }
        public async Task<Respuesta<LibroReclamacionDTO>> Insertar(LibroReclamacionEnt model)
        {
            return await _ILibroReclamacionDom.Insertar(model);
        }
        public async Task<Respuesta<string>> ObtenerPlantilla(int idTabla)
        {
            return await _ILibroReclamacionDom.ObtenerPlantilla(idTabla);
        }
    }
}