using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class PreferenteDom: IPreferenteDom
    {

        private readonly IPreferenteDat _IPreferenteDat;
        public PreferenteDom(IPreferenteDat IPreferenteDat)
        {
            this._IPreferenteDat = IPreferenteDat;
        }

        public async Task<Respuesta<PreferenteEnt>> Asignar(PreferenteEnt model)
        {
            return await _IPreferenteDat.Asignar(model);
        }

        public async Task<Respuesta<PreferenteEnt>> Atendido(PreferenteEnt model)
        {
            return await _IPreferenteDat.Atendido(model);
        }

        public async Task<Respuesta<PreferenteEnt>> Insertar(PreferenteEnt model)
        {
            return await _IPreferenteDat.Insertar(model);
        }

        public async Task<Respuesta<PreferenteEnt>> Modificar(PreferenteEnt model)
        {
            return await _IPreferenteDat.Modificar(model);
        }

        public async Task<IEnumerable<PreferenteGrillaDTO>> Obtener(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdUsuario, int? IdMedioContacto, int IdUsuarioSistema, int IdEstadoAtencion, int esCliente)
        {
            return await _IPreferenteDat.Obtener(FechaDesde, FechaHasta, IdEstado, IdUsuario, IdMedioContacto, IdUsuarioSistema, IdEstadoAtencion, esCliente);
        }
        public async Task<IEnumerable<PreferenteGrillaDTO>> ObtenerReportePreferente(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdUsuario, int? IdMedioContacto, int IdUsuarioSistema, int IdEstadoAtencion, int esCliente)
        {
            return await _IPreferenteDat.ObtenerReportePreferente(FechaDesde, FechaHasta, IdEstado, IdUsuario, IdMedioContacto, IdUsuarioSistema, IdEstadoAtencion, esCliente);
        }

        public async Task<IEnumerable<PreferenteGrillaDTO>> ObtenerConTelefono(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdUsuario, int? IdMedioContacto, int IdUsuarioSistema, int IdEstadoAtencion, int esCliente)
        {
            return await _IPreferenteDat.ObtenerConTelefono(FechaDesde, FechaHasta, IdEstado, IdUsuario, IdMedioContacto, IdUsuarioSistema, IdEstadoAtencion, esCliente);
        }

        public async Task<PreferenteDTO> ObtenerById(int Id, int IdUsuarioSistema)
        {
            return await _IPreferenteDat.ObtenerById(Id, IdUsuarioSistema);
        }

        public async Task<int> ObtenerSinAtender()
        {
            return await _IPreferenteDat.RetornarSinAtender();
        }

        public async Task<int> ActualizaEstadoVisto(ListaIdsDTO idsPreferente)
        {
            return await _IPreferenteDat.ActualizaEstadoVisto(idsPreferente);
        }

        public async Task<bool> ImportarExcel(List<PreferenteImportarDTO> listado)
        {
            return await _IPreferenteDat.ImportarExcel(listado);
        }

        public async Task<string> AsignarLista(List<PreferenteAsignarListaDTO> listado)
        {
            return await _IPreferenteDat.AsignarLista(listado);
        }

        public async Task<int> ObtenerNumeroAsignados(int idUsuario, DateTime fecha)
        {
            return await _IPreferenteDat.ObtenerNumeroAsignados(idUsuario, fecha);
        }

        public async Task<List<PreferenteDTO>> ObtenerAsignadosDelDia()
        {
            return await _IPreferenteDat.ObtenerAsignadosDelDia();
        }
        public async Task<List<PreferenteDTO>> ObtenerRetornados()
        {
            return await _IPreferenteDat.ObtenerRetornados();
        }

        public async Task<bool> AtendiendoPreferente(int idPreferente, int termino)
        {
            return await _IPreferenteDat.AtendiendoPreferente(idPreferente, termino);
        }

        public async Task<bool> FormularioWeb(FormularioWebDTO model)
        {
            return await _IPreferenteDat.FormularioWeb(model);
        }
        public async Task<bool> FormularioWebLanding(FormularioWebLandingDTO model)
        {
            return await _IPreferenteDat.FormularioWebLanding(model);
        }

        public async Task<int> ObtenerPendientesActuales()
        {
            return await _IPreferenteDat.ObtenerPendientesActuales();
        }

        public async Task<List<PreferenteHistoriaDTO>> ObtenerHistoria(int idPreferente)
        {
            return await _IPreferenteDat.ObtenerHistoria(idPreferente);
        }

        public async Task<bool> Reasignar(PreferenteReasignarDTO model)
        {
            return await _IPreferenteDat.Reasignar(model);
        }

        public async Task<PreferenteDTO> ObtenerByFacebookUser(string facebookUser)
        {
            return await _IPreferenteDat.ObtenerByFacebookUser(facebookUser);
        }

        public async Task<PreferenteDTO> ObtenerByInstagramUser(string instagramUser)
        {
            return await _IPreferenteDat.ObtenerByInstagramUser(instagramUser);
        }

        public async Task<List<PreferenteGrillaDTO>> Buscar(BuscarPreferenteDTO model)
        {
            return await _IPreferenteDat.Buscar(model);
        }

        public async Task<IEnumerable<PreferenteVentasDTO>> ObtenerPreferentesVentas(int IdUsuario, DateTime? FechaDesde, DateTime? FechaHasta)
        {
            return await _IPreferenteDat.ObtenerPreferentesVentas(IdUsuario, FechaDesde, FechaHasta);
        }
        public async Task<IEnumerable<PreferenteMobileGrillaDTO>> ObtenerMobilePreferentes()
        {
            return await _IPreferenteDat.ObtenerMobilePreferentes();

        }
        public async Task<GeneralResponse<PreferenteMobileResponseDTO>> UpdateMobilePreferenteEstado(int IdCita, int EstadoId)
        {
            return await _IPreferenteDat.UpdateMobilePreferenteEstado(IdCita, EstadoId);
        }

    }
}
