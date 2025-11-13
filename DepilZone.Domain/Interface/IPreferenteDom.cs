using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IPreferenteDom
    {
        Task<IEnumerable<PreferenteVentasDTO>> ObtenerPreferentesVentas(int IdUsuario, DateTime? FechaDesde, DateTime? FechaHasta);

        Task<IEnumerable<PreferenteGrillaDTO>> Obtener(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdTeleoperador, int? IdMedioContacto, int IdUsuarioSistema, int idEstadoAtencion, int esCliente);
        Task<IEnumerable<PreferenteGrillaDTO>> ObtenerReportePreferente(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdTeleoperador, int? IdMedioContacto, int IdUsuarioSistema, int idEstadoAtencion, int esCliente);
        Task<IEnumerable<PreferenteGrillaDTO>> ObtenerConTelefono(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdTeleoperador, int? IdMedioContacto, int IdUsuarioSistema, int idEstadoAtencion, int esCliente);
        Task<PreferenteDTO> ObtenerById(int Id, int IdUsuarioSistema);
        Task<PreferenteDTO> ObtenerByFacebookUser(string facebookUser);
        Task<PreferenteDTO> ObtenerByInstagramUser(string instagramUser);
        Task<Respuesta<PreferenteEnt>> Insertar(PreferenteEnt model);
        Task<Respuesta<PreferenteEnt>> Modificar(PreferenteEnt model);
        Task<Respuesta<PreferenteEnt>> Asignar(PreferenteEnt model);
        Task<Respuesta<PreferenteEnt>> Atendido(PreferenteEnt model);

        Task<bool> ImportarExcel(List<PreferenteImportarDTO> listado);

        Task<string> AsignarLista(List<PreferenteAsignarListaDTO> listado);

        Task<int> ObtenerSinAtender();
        Task<int> ActualizaEstadoVisto(ListaIdsDTO idsPreferente);
        Task<int> ObtenerNumeroAsignados(int idUsuario, DateTime fecha);
        Task<List<PreferenteDTO>> ObtenerAsignadosDelDia();
        Task<List<PreferenteDTO>> ObtenerRetornados();
        Task<bool> AtendiendoPreferente(int idPreferente, int termino);

        Task<bool> FormularioWeb(FormularioWebDTO model);
        Task<bool> FormularioWebLanding(FormularioWebLandingDTO model);
        Task<int> ObtenerPendientesActuales();

        Task<List<PreferenteHistoriaDTO>> ObtenerHistoria(int idPreferente);

        Task<bool> Reasignar(PreferenteReasignarDTO model);

        Task<List<PreferenteGrillaDTO>> Buscar(BuscarPreferenteDTO model);

        Task<IEnumerable<PreferenteMobileGrillaDTO>> ObtenerMobilePreferentes();
        Task<GeneralResponse<PreferenteMobileResponseDTO>> UpdateMobilePreferenteEstado(int IdCita, int EstadoId);

    }
}
