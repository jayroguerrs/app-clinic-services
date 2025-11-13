using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Threading.Tasks;
namespace DepilZone.Domain.Implement
{
    public class LibroReclamacionDom : ILibroReclamacionDom
    {
        private readonly ILibroReclamacionDat _ILibroReclamacionDat;
        public LibroReclamacionDom(ILibroReclamacionDat ILibroReclamacionDat)
        {
            this._ILibroReclamacionDat = ILibroReclamacionDat;
        }
        public async Task<Respuesta<LibroReclamacionDTO>> Insertar(LibroReclamacionEnt model)
        {
            return await _ILibroReclamacionDat.Insertar(model);
        }
        public async Task<Respuesta<string>> ObtenerPlantilla(int idTabla)
        {
            return await _ILibroReclamacionDat.ObtenerPlantilla(idTabla);
        }
    }
}