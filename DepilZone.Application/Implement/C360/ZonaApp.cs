
using DepilZone.Application.Interface.C360;
using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.C360
{
	public class ZonaApp : IZonaApp
	{
		private readonly IZonaDom _IZonaDom;
        public ZonaApp(IZonaDom IZonaDom)
        {
            this._IZonaDom = IZonaDom;
        }

        public async Task<List<ZonaDTO>> Listar()
        {
            return await _IZonaDom.Listar();
        }

        public async Task<List<ZonaDTO>> ListarByEstado(int idEstado)
        {
            return await _IZonaDom.ListarByEstado(idEstado);
        }

        public async Task<bool> Registrar(ZonaDTO model)
        {
            return await _IZonaDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, ZonaDTO model)
        {
            return await _IZonaDom.Modificar(id, model);
        }
        
    }
}
