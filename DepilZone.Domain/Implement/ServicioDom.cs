using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ServicioDom: IServicioDom
	{
		private readonly IServicioDat _IServicioDat;
		public ServicioDom(IServicioDat IServicioDat)
		{
			this._IServicioDat = IServicioDat;
		}
		public async Task<List<ServicioDTO>> Listar()
		{
			return await _IServicioDat.Listar();
		}
		public async Task<List<ServicioDTO>> ListarByEstado(int idEstado)
		{
			return await _IServicioDat.ListarByEstado(idEstado);
		}
		public async Task<bool> Registrar(ServicioDTO model)
        {
            return await _IServicioDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, ServicioDTO model)
        {
            return await _IServicioDat.Modificar(id, model);
        }
        
    }
}
