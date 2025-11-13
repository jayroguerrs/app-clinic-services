using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class IncidenciaDom : IIncidenciaDom
    {
        private readonly IIncidenciaDat _IIncidenciaDat;
        public IncidenciaDom(IIncidenciaDat IIncidenciaDat)
        {
            this._IIncidenciaDat = IIncidenciaDat;
        }

        public async Task<Respuesta<IncidenciaEnt>> Insertar(IncidenciaEnt model)
        {
            return await _IIncidenciaDat.Insertar(model);
        }

        public async Task<Respuesta<IncidenciaEnt>> Modificar(IncidenciaEnt model)
        {
            return await _IIncidenciaDat.Modificar(model);
        }

        public async Task<IncidenciaEnt> ObtenerById(int id)
        {
            return await _IIncidenciaDat.ObtenerById(id);
        }

        public async Task<IEnumerable<IncidenciaListadoGrillaDTO>> ObtenerListado(int idEstado)
        {
            return await _IIncidenciaDat.ObtenerListado(idEstado);
        }

        public async Task<IncidenciaNivelAtencion> NivelAtencion()
        {
            return await _IIncidenciaDat.NivelAtencion();
        }

    }
}
