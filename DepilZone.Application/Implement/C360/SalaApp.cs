
using DepilZone.Application.Interface.C360;
using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.C360
{
	public class SalaApp : ISalaApp
	{
		private readonly ISalaDom _IBoxDom;
        public SalaApp(ISalaDom IBoxDom)
        {
            this._IBoxDom = IBoxDom;
        }

        public async Task<List<SalaDTO>> Listar()
        {
            return await _IBoxDom.Listar();
        }

        public async Task<List<SalaDTO>> ListarByEstado(int idEstado)
        {
            return await _IBoxDom.ListarByEstado(idEstado);
        }

        public async Task<bool> Registrar(SalaDTO model)
        {
            return await _IBoxDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, SalaDTO model)
        {
            return await _IBoxDom.Modificar(id, model);
        }
        
    }
}
