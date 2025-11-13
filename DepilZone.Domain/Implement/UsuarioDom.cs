using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace DepilZone.Domain
{
    public class UsuarioDom: IUsuarioDom
    {

        private readonly IUsuarioDat _IUsuarioDat;
        public UsuarioDom(IUsuarioDat IUsuarioDat)
        {
            this._IUsuarioDat = IUsuarioDat;
        }
        public async Task<IEnumerable<UsuarioGridDTO>> Obtener(bool idEstado)
        {
            return await _IUsuarioDat.Obtener(idEstado);
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerListadoGrilla()
        {
            return await _IUsuarioDat.ObtenerListadoGrilla();
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByLikeNombre(string Nombre)
        {
            return await _IUsuarioDat.ObtenerByLikeNombre(Nombre);
        }

        public async Task<Respuesta<UsuarioEnt>> Insertar(UsuarioEnt model)
        {
            return await _IUsuarioDat.Insertar(model);
        }
        public async Task<Respuesta<UsuarioEnt>> Modificar(UsuarioEnt model)
        {
            return await _IUsuarioDat.Modificar(model);
        }

        public async Task<Respuesta<UsuarioCambiarClaveDTO>> CambiarClave(UsuarioCambiarClaveDTO model)
        {
            return await _IUsuarioDat.CambiarClave(model);
        }

        public async Task<UsuarioEnt> ObtenerByIdUsuario(int IdUsuario)
        {
            return await _IUsuarioDat.ObtenerByIdUsuario(IdUsuario);
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByIdPerfil(string idPerfil, int idSede)
        {
            return await _IUsuarioDat.ObtenerByIdPerfil(idPerfil, idSede);
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByIdPerfilUsuario(int idUsuario)
        {
            return await _IUsuarioDat.ObtenerByIdPerfilUsuario(idUsuario);
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerResponsableCaja()
        {
            return await _IUsuarioDat.ObtenerResponsableCaja();
        }


        public async Task<Respuesta<LoginDTO>> Login(LoginDTO model)
        {
            return await _IUsuarioDat.Login(model);
        }
        public async Task<List<MenuRutaDetDTO>> MenuUsuario(LoginDTO model)
        {
            return await _IUsuarioDat.MenuUsuario(model);
        }

        public async Task<List<UsuarioGridDTO>> ListarParaPreferentes()
        {
            return await _IUsuarioDat.ListarParaPreferentes();
        }
        public async Task<List<EmpleadoDTO>> ListarParaPreferentesPorUsuario(int idPerfil)
        {
            return await _IUsuarioDat.ListarParaPreferentesPorUsuario(idPerfil);
        }

        public async Task<List<MenuDTO>> ObtenerMenuByPerfil(int idPerfil)
        {
            return await _IUsuarioDat.ObtenerMenuByPerfil(idPerfil);
        }

        public async Task<List<ShortUser>> CollectionByEstado(int idEstado)
        {
            return await _IUsuarioDat.CollectionByEstado(idEstado);
        }


        public async Task<string> ObtenerClave(int idUsuario)
        {
            return await _IUsuarioDat.ObtenerClave(idUsuario);
        }

        public async Task<bool> CambiarClave(int idUsuario, string clave)
        {
            return await _IUsuarioDat.CambiarClave( idUsuario, clave);
        }


        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerParaCita()
        {
            return await _IUsuarioDat.ObtenerParaCita();
        }

        public async Task<string> ObtenerClaveUsuario(int id)
        {
            return await _IUsuarioDat.ObtenerClaveUsuario(id);

        }

        public async Task<UsuarioActualizarDatosDTO> ActualizarDatos(UsuarioActualizarDatosDTO model)
        {
            return await _IUsuarioDat.ActualizarDatos(model);
        }
        public async Task<PersonalizarClinicDTO> PerzonalizarClinic(PersonalizarClinicDTO model)
        {
            return await _IUsuarioDat.PerzonalizarClinic(model);

        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerListadoGrillaBySupervisor(int idSupervisor)
        {
            return await _IUsuarioDat.ObtenerListadoGrillaBySupervisor(idSupervisor);
        }
        public async Task<GeneralResponse<RespuestaConfirmarSupervisorDTO>> ConfirmarSupervisor(int idUsuario, string usuarioSupervisor)
        {
            return await _IUsuarioDat.ConfirmarSupervisor(idUsuario, usuarioSupervisor);

        }
        public async Task<GeneralResponse<bool>> CambiarEstadoAprobacion(int idUsuario, byte estadoUsuario)
        {
            return await _IUsuarioDat.CambiarEstadoAprobacion(idUsuario, estadoUsuario);

        }
        public async Task<byte> ObtenerEstadoAprobacionUsuario(int idUsuario)
        {
            return await _IUsuarioDat.ObtenerEstadoAprobacionUsuario(idUsuario);
        }
        public async Task<AccesoUsuarioDTO> ObtenerEstadoPrivilegioUsuario(int idUsuario)
        {
            return await _IUsuarioDat.ObtenerEstadoPrivilegioUsuario(idUsuario);
        }
        public async Task<IEnumerable<SupervisorDTO>> ObtenerListadoSupervisores()
        {
            return await _IUsuarioDat.ObtenerListadoSupervisores();
        }

    }
}
