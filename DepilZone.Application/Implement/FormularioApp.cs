using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class FormularioApp : IFormularioApp
    {
        private readonly IFormularioDom _IFormularioDom;
        public FormularioApp(IFormularioDom IFormularioDom)
        {
            _IFormularioDom = IFormularioDom;
        }
        public async Task<IEnumerable<PromocionFormDTO>> ObtenerPromocion(int id)
        {
           return await _IFormularioDom.ObtenerPromocion(id);
        }

        public async Task<IEnumerable<ServicioPromocionDTO>> ObtenerServiciosPorPromocion(int idPromocion, int idUsuario)
        {
            return await _IFormularioDom.ObtenerServiciosPorPromocion(idPromocion, idUsuario);
        }

        public async Task<IEnumerable<TipoClienteDTO>> ObtenerTipoCliente(int id)
        {
            return await _IFormularioDom.ObtenerTipoCliente(id);
        }

        public async Task<bool> RegistrarVenta(FormDTO formDTO)
        {
            return await _IFormularioDom.RegistrarVenta(formDTO);
        }

        public async Task<List<Dictionary<string, object>>> ReporteVenta(FilterFormDTO filterDTO)
        {
            return await _IFormularioDom.ReporteVenta(filterDTO);
        }
    }
}
