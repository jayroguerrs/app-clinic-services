using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class IncidenciaApp: IIncidenciaApp
    {
        private readonly IIncidenciaDom _IIncidenciaDom;
        public IncidenciaApp(IIncidenciaDom IIncidenciaDom)
        {
            _IIncidenciaDom = IIncidenciaDom;
        }

        public async Task<Respuesta<IncidenciaEnt>> Insertar(IncidenciaEnt model)
        {
            return await _IIncidenciaDom.Insertar(model);
        }

        public async Task<Respuesta<IncidenciaEnt>> Modificar(IncidenciaEnt model)
        {
            return await _IIncidenciaDom.Modificar(model);
        }

        public async Task<IncidenciaEnt> ObtenerById(int id)
        {
            return await _IIncidenciaDom.ObtenerById(id);
        }

        public async Task<IEnumerable<IncidenciaListadoGrillaDTO>> ObtenerListado(int idEstado)
        {
            return await _IIncidenciaDom.ObtenerListado(idEstado);
        }

        public async Task<IncidenciaNivelAtencion> NivelAtencion()
        {
            return await _IIncidenciaDom.NivelAtencion();
        }
    }
}
