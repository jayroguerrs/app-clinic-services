using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement.C360
{
    public class ServicioDom: IServicioDom
	{
		private readonly IServicioDat _IServicioDat;
		public ServicioDom(IServicioDat IServicioDat)
		{
			this._IServicioDat = IServicioDat;
		}
		public async Task<List<Servicio360DTO>> Listar()
		{
			return await _IServicioDat.Listar();
		}
		public async Task<List<Servicio360DTO>> ListarByEstado(int idEstado)
		{
			return await _IServicioDat.ListarByEstado(idEstado);
		}
		public async Task<bool> Registrar(Servicio360DTO model)
        {
            return await _IServicioDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, Servicio360DTO model)
        {
            return await _IServicioDat.Modificar(id, model);
        }
		public async Task<Servicios360DTO> BuscarById(int id)
		{
			return await _IServicioDat.BuscarById(id);
		}

	}
}
