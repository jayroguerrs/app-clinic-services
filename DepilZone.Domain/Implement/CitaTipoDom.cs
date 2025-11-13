using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class CitaTipoDom : ICitaTipoDom
    {
        private readonly ICitaTipoDat _ITipoCitaDat;
        public CitaTipoDom(ICitaTipoDat ITipoCitaDat)
        {
            this._ITipoCitaDat = ITipoCitaDat;
        }
        public async Task<IEnumerable<CitaTipoEnt>> Obtener()
        {
            return await _ITipoCitaDat.Obtener();
        }

        public async Task<IEnumerable<CitaTipoEnt>> ObtenerByLikeNombre(string Descripcion)
        {
            return await _ITipoCitaDat.ObtenerByLikeNombre(Descripcion);
        }
        public async Task<Respuesta<CitaTipoEnt>> Insertar(CitaTipoEnt model)
        {
            return await _ITipoCitaDat.Insertar(model);
        }

        public async Task<CitaTipoEnt> ObtenerById(int idsede)
        {
            return await _ITipoCitaDat.ObtenerById(idsede);
        }

        public async Task<Respuesta<CitaTipoEnt>> Modificar(CitaTipoEnt model)
        {
            return await _ITipoCitaDat.Modificar(model);
        }
    }
}
