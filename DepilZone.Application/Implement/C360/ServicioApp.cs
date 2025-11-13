
using DepilZone.Application.Interface.C360;
using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.C360
{
	public class ServicioApp : IServicioApp
	{
		private readonly IServicioDom _IServicioDom;
        public ServicioApp(IServicioDom IServicioDom)
        {
            this._IServicioDom = IServicioDom;
        }

        public async Task<List<Servicio360DTO>> Listar()
        {
            return await _IServicioDom.Listar();
        }

        public async Task<List<Servicio360DTO>> ListarByEstado(int idEstado)
        {
            return await _IServicioDom.ListarByEstado(idEstado);
        }

        public async Task<bool> Registrar(Servicio360DTO model)
        {
            return await _IServicioDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, Servicio360DTO model)
        {
            return await _IServicioDom.Modificar(id, model);
        }
        public async Task<Servicios360DTO> BuscarById(int id)
        {
            return await _IServicioDom.BuscarById(id);
        }

    }
}
