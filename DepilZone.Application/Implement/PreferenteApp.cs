using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class PreferenteApp: IPreferenteApp
    {

        private readonly IPreferenteDom _IPreferenteDom;
        public PreferenteApp(IPreferenteDom IPreferenteDom)
        {
            _IPreferenteDom = IPreferenteDom;
        }

        public async Task<Respuesta<PreferenteEnt>> Asignar(PreferenteEnt model)
        {
            return await _IPreferenteDom.Asignar(model);
        }
        public async Task<Respuesta<PreferenteEnt>> Atendido(PreferenteEnt model)
        {
            return await _IPreferenteDom.Atendido(model);
        }


        public async Task<Respuesta<PreferenteEnt>> Insertar(PreferenteEnt model)
        {
            return await _IPreferenteDom.Insertar(model);
        }

        public async Task<Respuesta<PreferenteEnt>> Modificar(PreferenteEnt model)
        {
            return await _IPreferenteDom.Modificar(model);
        }

        public async Task<IEnumerable<PreferenteGrillaDTO>> Obtener(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdUsuario, int? IdMedioContacto, int IdUsuarioSistema, int IdEstadoAtencion, int esCliente)
        {
            return await _IPreferenteDom.Obtener(FechaDesde, FechaHasta, IdEstado, IdUsuario, IdMedioContacto, IdUsuarioSistema, IdEstadoAtencion, esCliente);
        }

        public async Task<IEnumerable<PreferenteGrillaDTO>> ObtenerReportePreferente(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdUsuario, int? IdMedioContacto, int IdUsuarioSistema, int IdEstadoAtencion, int esCliente)
        {
            return await _IPreferenteDom.ObtenerReportePreferente(FechaDesde, FechaHasta, IdEstado, IdUsuario, IdMedioContacto, IdUsuarioSistema, IdEstadoAtencion, esCliente);
        }        

        public async Task<IEnumerable<PreferenteGrillaDTO>> ObtenerConTelefono(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdUsuario, int? IdMedioContacto, int IdUsuarioSistema, int IdEstadoAtencion, int esCliente)
        {
            return await _IPreferenteDom.ObtenerConTelefono(FechaDesde, FechaHasta, IdEstado, IdUsuario, IdMedioContacto, IdUsuarioSistema, IdEstadoAtencion, esCliente);
        }

        public async Task<PreferenteDTO> ObtenerById(int Id, int IdUsuarioSistema)
        {
            return await _IPreferenteDom.ObtenerById(Id, IdUsuarioSistema);
        }

        public async Task<int> ObtenerSinAtender()
        {
            return await _IPreferenteDom.ObtenerSinAtender();
        }
        public async Task<int> ActualizaEstadoVisto(ListaIdsDTO idsPreferente)
        {
            return await _IPreferenteDom.ActualizaEstadoVisto(idsPreferente);
        }

        public async Task<bool> ImportarExcel(List<PreferenteImportarDTO> listado)
        {
            return await _IPreferenteDom.ImportarExcel(listado);
        }

        public async Task<string> AsignarLista(List<PreferenteAsignarListaDTO> listado)
        {
            return await _IPreferenteDom.AsignarLista(listado);
        }

        public async Task<int> ObtenerNumeroAsignados(int idUsuario, DateTime fecha)
        {
            return await _IPreferenteDom.ObtenerNumeroAsignados(idUsuario, fecha);
        }

        public async Task<List<PreferenteDTO>> ObtenerAsignadosDelDia()
        {
            return await _IPreferenteDom.ObtenerAsignadosDelDia();
        }
        public async Task<List<PreferenteDTO>> ObtenerRetornados()
        {
            return await _IPreferenteDom.ObtenerRetornados();
        }
        public async Task<bool> AtendiendoPreferente(int idPreferente, int termino)
        {
            return await _IPreferenteDom.AtendiendoPreferente(idPreferente, termino);
        }

        public async Task<bool> FormularioWeb(FormularioWebDTO model)
        {
            return await _IPreferenteDom.FormularioWeb(model);
        }

        public async Task<bool> FormularioWebLanding(FormularioWebLandingDTO model)
        {
            return await _IPreferenteDom.FormularioWebLanding(model);
        }

        public async Task<int> ObtenerPendientesActuales()
        {
            return await _IPreferenteDom.ObtenerPendientesActuales();
        }


        public async Task<List<PreferenteHistoriaDTO>> ObtenerHistoria(int idPreferente)
        {
            return await _IPreferenteDom.ObtenerHistoria( idPreferente);
        }

        public async Task<bool> Reasignar(PreferenteReasignarDTO model)
        {
            return await _IPreferenteDom.Reasignar(model);
        }

        public async Task<PreferenteDTO> ObtenerByFacebookUser(string facebookUser)
        {
            return await _IPreferenteDom.ObtenerByFacebookUser(facebookUser);
        }

        public async Task<PreferenteDTO> ObtenerByInstagramUser(string instagramUser)
        {
            return await _IPreferenteDom.ObtenerByInstagramUser(instagramUser);
        }

        public async Task<List<PreferenteGrillaDTO>> Buscar(BuscarPreferenteDTO model)
        {
            return await _IPreferenteDom.Buscar(model);
        }

        public async Task<IEnumerable<PreferenteVentasDTO>> ObtenerPreferentesVentas(int IdUsuario, DateTime? FechaDesde, DateTime? FechaHasta)
        {
            return await _IPreferenteDom.ObtenerPreferentesVentas(IdUsuario, FechaDesde, FechaHasta);
        }
        public async Task<IEnumerable<PreferenteMobileGrillaDTO>> ObtenerMobilePreferentes()
        {
            return await _IPreferenteDom.ObtenerMobilePreferentes();

        }
        public async Task<GeneralResponse<PreferenteMobileResponseDTO>> UpdateMobilePreferenteEstado(int IdCita, int EstadoId)
        {
            return await _IPreferenteDom.UpdateMobilePreferenteEstado(IdCita, EstadoId);
        }
    }
}
