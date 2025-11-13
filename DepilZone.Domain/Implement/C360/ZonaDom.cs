using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement.C360
{
    public class ZonaDom: IZonaDom
	{
		private readonly IZonaDat _IZonaDat;
		public ZonaDom(IZonaDat IZonaDat)
		{
			this._IZonaDat = IZonaDat;
		}
		public async Task<List<ZonaDTO>> Listar()
		{
			return await _IZonaDat.Listar();
		}
		public async Task<List<ZonaDTO>> ListarByEstado(int idEstado)
		{
			return await _IZonaDat.ListarByEstado(idEstado);
		}
		public async Task<bool> Registrar(ZonaDTO model)
        {
            return await _IZonaDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, ZonaDTO model)
        {
            return await _IZonaDat.Modificar(id, model);
        }
        
    }
}
