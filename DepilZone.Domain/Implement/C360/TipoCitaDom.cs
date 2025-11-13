using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement.C360
{
    public class TipoCitaDom: ITipoCitaDom
	{
		private readonly ITipoCitaDat _ITipoCitaDat;
		public TipoCitaDom(ITipoCitaDat ITipoCitaDat)
		{
			this._ITipoCitaDat = ITipoCitaDat;
		}
		public async Task<List<TipoCitaDTO>> Listar()
		{
			return await _ITipoCitaDat.Listar();
		}
		public async Task<List<TipoCitaDTO>> ListarByEstado(int idEstado)
		{
			return await _ITipoCitaDat.ListarByEstado(idEstado);
		}
		public async Task<bool> Registrar(TipoCitaDTO model)
        {
            return await _ITipoCitaDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, TipoCitaDTO model)
        {
            return await _ITipoCitaDat.Modificar(id, model);
        }
        
    }
}
