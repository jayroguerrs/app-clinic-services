using DepilZone.Application.Interface;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Domain;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class UsuarioApp: IUsuarioApp
    {

        private readonly IUsuarioDom _IUsuarioDom;
        public UsuarioApp(IUsuarioDom IUsuarioDom)
        {
            this._IUsuarioDom = IUsuarioDom;
        }

        public async Task<IEnumerable<UsuarioGridDTO>> Obtener(bool idEstado)
        {
            return await _IUsuarioDom.Obtener(idEstado);
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerListadoGrilla()
        {
            return await _IUsuarioDom.ObtenerListadoGrilla();
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByLikeNombre(string Nombre)
        {
            return await _IUsuarioDom.ObtenerByLikeNombre(Nombre);
        }
        public async Task<UsuarioEnt> ObtenerByIdUsuario(int IdUsuario)
        {
            return await _IUsuarioDom.ObtenerByIdUsuario(IdUsuario);
        }

        public async Task<Respuesta<UsuarioEnt>> Insertar(UsuarioEnt model)
        {
            return await  _IUsuarioDom.Insertar(model);
        }
        public async Task<Respuesta<UsuarioEnt>> Modificar(UsuarioEnt model)
        {
            return await _IUsuarioDom.Modificar(model);
        }

        public async Task<Respuesta<UsuarioCambiarClaveDTO>> CambiarClave(UsuarioCambiarClaveDTO model)
        {
            return await _IUsuarioDom.CambiarClave(model);
        }

        public async Task<Respuesta<LoginDTO>> Login(LoginDTO model)
        {
            return await _IUsuarioDom.Login(model);
        }

        public async Task<List<MenuRutaDetDTO>> MenuUsuario(LoginDTO model)
        {
            return await _IUsuarioDom.MenuUsuario(model);
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByIdPerfil(string idPerfil, int idSede)
        {
            return await _IUsuarioDom.ObtenerByIdPerfil(idPerfil, idSede);
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByIdPerfilUsuario(int idUsuario)
        {
            return await _IUsuarioDom.ObtenerByIdPerfilUsuario(idUsuario);
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerResponsableCaja()
        {
            return await _IUsuarioDom.ObtenerResponsableCaja();
        }

        public async Task<List<UsuarioGridDTO>> ListarParaPreferentes()
        {
            return await _IUsuarioDom.ListarParaPreferentes();
        }
        public async Task<List<EmpleadoDTO>> ListarParaPreferentesPorUsuario(int idPerfil)
        {
            return await _IUsuarioDom.ListarParaPreferentesPorUsuario(idPerfil);
        }

        public async Task<List<MenuDTO>> ObtenerMenuByPerfil(int idPerfil)
        {
            return await _IUsuarioDom.ObtenerMenuByPerfil(idPerfil);
        }

        public async Task<List<ShortUser>> CollectionByEstado(int idEstado)
        {
            return await _IUsuarioDom.CollectionByEstado(idEstado);
        }

        public async Task<string> ObtenerClave(int idUsuario)
        {
            return await _IUsuarioDom.ObtenerClave(idUsuario);
        }


        public async Task<bool> CambiarClave(int idUsuario, string clave)
        {
            return await _IUsuarioDom.CambiarClave(idUsuario, clave);
        }


        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerParaCita()
        {
            return await _IUsuarioDom.ObtenerParaCita();
        }

        public async Task<string> ObtenerClaveUsuario(int id)
        {
            return await _IUsuarioDom.ObtenerClaveUsuario(id);

        }
        public async Task<UsuarioActualizarDatosDTO> ActualizarDatos(UsuarioActualizarDatosDTO model)
        {
            return await _IUsuarioDom.ActualizarDatos(model);
        }
        public async Task<PersonalizarClinicDTO> PerzonalizarClinic(PersonalizarClinicDTO model)
        {
            return await _IUsuarioDom.PerzonalizarClinic(model);
        }

        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerListadoGrillaBySupervisor(int idSupervisor)
        {
            return await _IUsuarioDom.ObtenerListadoGrillaBySupervisor(idSupervisor);
        }
        public async Task<GeneralResponse<RespuestaConfirmarSupervisorDTO>> ConfirmarSupervisor(int idUsuario, string usuarioSupervisor)
        {
            return await _IUsuarioDom.ConfirmarSupervisor(idUsuario, usuarioSupervisor);

        }
        public async Task<GeneralResponse<bool>> CambiarEstadoAprobacion(int idUsuario, byte estadoUsuario)
        {
            return await _IUsuarioDom.CambiarEstadoAprobacion(idUsuario, estadoUsuario);

        }
        public async Task<byte> ObtenerEstadoAprobacionUsuario(int idUsuario)
        {
            return await _IUsuarioDom.ObtenerEstadoAprobacionUsuario(idUsuario);
        }
        public async Task<AccesoUsuarioDTO> ObtenerEstadoPrivilegioUsuario(int idUsuario)
        {
            return await _IUsuarioDom.ObtenerEstadoPrivilegioUsuario(idUsuario);
        }
        public async Task<IEnumerable<SupervisorDTO>> ObtenerListadoSupervisores()
        {
            return await _IUsuarioDom.ObtenerListadoSupervisores();
        }
        public async Task<GeneralResponse<ClaveGenericaResult>> GenerarClaveGenerica(int idUsuario)
        {
            return await _IUsuarioDom.GenerarClaveGenerica(idUsuario);
        }
        public async Task<bool> CambiarClaveGenerica(int idUsuario, string clave)
        {
            return await _IUsuarioDom.CambiarClaveGenerica(idUsuario, clave);
        }
    }
}
