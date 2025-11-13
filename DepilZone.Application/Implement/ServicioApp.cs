
using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class ServicioApp : IServicioApp
	{
		private readonly IServicioDom _IServicioDom;
        public ServicioApp(IServicioDom IServicioDom)
        {
            this._IServicioDom = IServicioDom;
        }

        public async Task<List<ServicioDTO>> Listar()
        {
            return await _IServicioDom.Listar();
        }

        public async Task<List<ServicioDTO>> ListarByEstado(int idEstado)
        {
            return await _IServicioDom.ListarByEstado(idEstado);
        }

        public async Task<bool> Registrar(ServicioDTO model)
        {
            return await _IServicioDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, ServicioDTO model)
        {
            return await _IServicioDom.Modificar(id, model);
        }
        
    }
}
