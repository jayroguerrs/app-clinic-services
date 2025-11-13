
using DepilZone.Application.Interface.C360;
using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.C360
{
	public class TipoCitaApp : ITipoCitaApp
	{
		private readonly ITipoCitaDom _ITipoCitaDom;
        public TipoCitaApp(ITipoCitaDom ITipoCitaDom)
        {
            this._ITipoCitaDom = ITipoCitaDom;
        }

        public async Task<List<TipoCitaDTO>> Listar()
        {
            return await _ITipoCitaDom.Listar();
        }

        public async Task<List<TipoCitaDTO>> ListarByEstado(int idEstado)
        {
            return await _ITipoCitaDom.ListarByEstado(idEstado);
        }

        public async Task<bool> Registrar(TipoCitaDTO model)
        {
            return await _ITipoCitaDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, TipoCitaDTO model)
        {
            return await _ITipoCitaDom.Modificar(id, model);
        }
        
    }
}
