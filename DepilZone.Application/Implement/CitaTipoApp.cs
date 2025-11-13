using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class CitaTipoApp : ICitaTipoApp
    {

        
        private readonly ICitaTipoDom _ITipoCitaDom;
        public CitaTipoApp(ICitaTipoDom ITipoCitaDom)
        {
            this._ITipoCitaDom = ITipoCitaDom;
        }
        public async Task<IEnumerable<CitaTipoEnt>> Obtener()
        {
            return await _ITipoCitaDom.Obtener();
        }
        public async Task<CitaTipoEnt> ObtenerById(int IdTipoCita)
        {
            return await _ITipoCitaDom.ObtenerById(IdTipoCita);
        }
        public async Task<IEnumerable<CitaTipoEnt>> ObtenerByLikeNombre(string Descripcion)
        {
            return await _ITipoCitaDom.ObtenerByLikeNombre(Descripcion);
        }
        public async Task<Respuesta<CitaTipoEnt>> Insertar(CitaTipoEnt model)
        {
            return await _ITipoCitaDom.Insertar(model);
        }
        public async Task<Respuesta<CitaTipoEnt>> Modificar(CitaTipoEnt model)
        {
            return await _ITipoCitaDom.Modificar(model);
        }
    }
}
