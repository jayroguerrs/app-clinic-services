using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement.C360
{
    public class SalaDom: ISalaDom
	{
		private readonly ISalaDat _IBoxDat;
		public SalaDom(ISalaDat IBoxDat)
		{
			this._IBoxDat = IBoxDat;
		}
		public async Task<List<SalaDTO>> Listar()
		{
			return await _IBoxDat.Listar();
		}
		public async Task<List<SalaDTO>> ListarByEstado(int idEstado)
		{
			return await _IBoxDat.ListarByEstado(idEstado);
		}
		public async Task<bool> Registrar(SalaDTO model)
        {
            return await _IBoxDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, SalaDTO model)
        {
            return await _IBoxDat.Modificar(id, model);
        }
        
    }
}
