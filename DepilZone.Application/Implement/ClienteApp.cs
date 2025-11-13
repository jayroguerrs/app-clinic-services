using DepilZone.Application.Interface;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ClienteApp: IClienteApp
    {
        private readonly IClienteDom _IClienteDom;
        public ClienteApp(IClienteDom IClienteDom)
        {
            this._IClienteDom = IClienteDom;
        }

        public async Task<IEnumerable<ClienteGridDTO>> Obtener(int topMax)
        {
            return await _IClienteDom.Obtener(topMax);
        }
        public async Task<IEnumerable<ClienteGridDTO>> ObtenerByLikeNombre(string Nombre)
        {
            return await _IClienteDom.ObtenerByLikeNombre(Nombre);
        }
        public async Task<IEnumerable<ClienteGridDTO>> ObtenerPorPreferente(string Nombres, string Apellidos, string Numeros, string Email)
        {
            return await _IClienteDom.ObtenerPorPreferente(Nombres, Apellidos, Numeros, Email);
        }

        public async Task<ClienteDTO> ObtenerById(int Id)
        {
            return await _IClienteDom.ObtenerById(Id);
        }
        public async Task<ClienteDTO> ObtenerPerfilById(int Id)
        {
            return await _IClienteDom.ObtenerPerfilById(Id);
        }
        public async Task<IEnumerable<ClienteZonaCorporalHistoricoDTO>> ObtenerTodasLasZonasCorporales(int Id)
        {
            return await _IClienteDom.ObtenerTodasLasZonasCorporales(Id);
        }

        public async Task<IEnumerable<ClienteZonaCorporalHistoricoDTO>> ObtenerTodasLasZonasCorporalesPorServicio(int Id, int IdServicio)
        {
            return await _IClienteDom.ObtenerTodasLasZonasCorporalesPorServicio(Id, IdServicio);
        }

        public async Task<Respuesta<ClienteEnt>> Insertar(ClienteEnt model)
        {
            return await _IClienteDom.Insertar(model);
        }
        public async Task<Respuesta<ClienteEnt>> Modificar(ClienteEnt model)
        {
            return await _IClienteDom.Modificar(model);
        }
        public async Task<Respuesta<ClienteEnt>> ModificarFirma(ClienteEnt model)
        {
            return await _IClienteDom.ModificarFirma(model);
        }

        public async Task<ClienteEnt> ObtenerFirmaById(int Id)
        {
            return await _IClienteDom.ObtenerFirmaById(Id);
        }
        public async Task<ClienteDatosMaestrosDTO> ObtenerDatosMaestros()
        {
            return await _IClienteDom.ObtenerDatosMaestros();
        }

        public async Task<Respuesta<int>> ValidarNumeroCelular(int idCliente, string numeroCelular1, string numeroCelular2)
        {
            return await _IClienteDom.ValidarNumeroCelular(idCliente, numeroCelular1, numeroCelular2);
        }
        public async Task<IEnumerable<ClienteGridDTO>> ObtenerByNumeroCelular(string numero1Pais, string numero1, string numero2Pais, string numero2)
        {
            return await _IClienteDom.ObtenerByNumeroCelular(numero1Pais, numero1, numero2Pais, numero2);
        }

        public async Task<Respuesta<FichaAdmisionDTO>> ObtenerFichaAdmisionByIdCliente(int idCliente)
        {
            return await _IClienteDom.ObtenerFichaAdmisionByIdCliente(idCliente);
        }


        public async Task<ClienteConsultaDniDTO> BuscarPorDNIOnline(string dni)
        {
            return await _IClienteDom.BuscarPorDNIOnline(dni);
        }
        public async Task<Respuesta<ClienteEnt>> ActualizarFicha(FichaAdmisionEnt model)
        {
            return await _IClienteDom.ActualizarFicha(model);
        }

        public async Task<List<ClienteDTO>> BuscarParametros(string p)
        {
            return await _IClienteDom.BuscarParametros(p);
        }

        public async Task<List<CitaDTO>> BuscarCitasAtendidas(int idCliente)
        {
            return await _IClienteDom.BuscarCitasAtendidas(idCliente);
        }

        public async Task<bool> VerificarClientePorDni(string documento)
        {
            return await _IClienteDom.VerificarClientePorDni(documento);
        }

        public async Task<bool> ActualizarDocumentoIdentidad(int idCliente, ClienteDTO model)
        {
            return await _IClienteDom.ActualizarDocumentoIdentidad(idCliente, model);
        }

        public async Task<List<ClienteNuevoDTO>> ObtenerReporteDeNuevosClientes(DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _IClienteDom.ObtenerReporteDeNuevosClientes(fechaDesde, fechaHasta);
        }
        public async Task<ClienteRucDTO> ObtenerRazonSocialClientebyRuc(string ruc) { 
        return await _IClienteDom.ObtenerRazonSocialClientebyRuc(ruc);
        }
        public async Task<ClienteDniDTO> ObtenerDatosClientebyDNI(string dni)
        {
            return await _IClienteDom.ObtenerDatosClientebyDNI(dni);
        }

    }
}
