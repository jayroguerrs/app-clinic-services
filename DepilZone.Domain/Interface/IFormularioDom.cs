using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IFormularioDom
    {
        Task<IEnumerable<TipoClienteDTO>> ObtenerTipoCliente(int id);
        Task<IEnumerable<PromocionFormDTO>> ObtenerPromocion(int id);
        Task<IEnumerable<ServicioPromocionDTO>> ObtenerServiciosPorPromocion(int idPromocion, int idUsuario);
        Task<bool> RegistrarVenta(FormDTO formDTO);
        Task<List<Dictionary<string, object>>> ReporteVenta(FilterFormDTO filterDTO);
    }
}
