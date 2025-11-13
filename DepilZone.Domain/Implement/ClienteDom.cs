using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;

namespace DepilZone.Domain
{
    public class ClienteDom : IClienteDom
    {

        private readonly IClienteDat _IClienteDat;
        public ClienteDom(IClienteDat IClienteDat)
        {
            this._IClienteDat = IClienteDat;
        }
        public async Task<IEnumerable<ClienteGridDTO>> Obtener(int topMax)
        {
            return await _IClienteDat.Obtener(topMax);
        }
        public async Task<IEnumerable<ClienteGridDTO>> ObtenerByLikeNombre(string Nombre)
        {
            return await _IClienteDat.ObtenerByLikeNombre(Nombre);
        }
        public async Task<IEnumerable<ClienteGridDTO>> ObtenerPorPreferente(string Nombres, string Apellidos, string Numeros, string Email)
        {
            return await _IClienteDat.ObtenerPorPreferente(Nombres, Apellidos, Numeros, Email);
        }

        public async Task<Respuesta<ClienteEnt>> Insertar(ClienteEnt model)
        {
            return await _IClienteDat.Insertar(model);
        }
        public async Task<Respuesta<ClienteEnt>> Modificar(ClienteEnt model)
        {
            return await _IClienteDat.Modificar(model);
        }
        public async Task<Respuesta<ClienteEnt>> ModificarFirma(ClienteEnt model)
        {
            return await _IClienteDat.ModificarFirma(model);
        }
        public async Task<ClienteDTO> ObtenerById(int Id)
        {
            return await _IClienteDat.ObtenerById(Id);
        }
        public async Task<ClienteDTO> ObtenerPerfilById(int Id)
        {
            return await _IClienteDat.ObtenerPerfilById(Id);
        }
        public async Task<IEnumerable<ClienteZonaCorporalHistoricoDTO>> ObtenerTodasLasZonasCorporales(int Id)
        {
            return await _IClienteDat.ObtenerTodasLasZonasCorporales(Id);
        }

        public async Task<IEnumerable<ClienteZonaCorporalHistoricoDTO>> ObtenerTodasLasZonasCorporalesPorServicio(int IdCliente, int idServicio)
        {
            return await _IClienteDat.ObtenerTodasLasZonasCorporalesPorServicio(IdCliente, idServicio);
        }
        public async Task<ClienteEnt> ObtenerFirmaById(int Id)
        {
            return await _IClienteDat.ObtenerFirmaById(Id);
        }
        public async Task<ClienteDatosMaestrosDTO> ObtenerDatosMaestros()
        {
            return await _IClienteDat.ObtenerDatosMaestros();
        }
        public async Task<Respuesta<int>> ValidarNumeroCelular(int idCliente, string numeroCelular1, string numeroCelular2)
        {
            return await _IClienteDat.ValidarNumeroCelular(idCliente, numeroCelular1, numeroCelular2);
        }
        public async Task<IEnumerable<ClienteGridDTO>> ObtenerByNumeroCelular(string numero1Pais, string numero1, string numero2Pais, string numero2)
        {
            return await _IClienteDat.ObtenerByNumeroCelular(numero1Pais, numero1, numero2Pais, numero2);
        }
        public async Task<Respuesta<FichaAdmisionDTO>> ObtenerFichaAdmisionByIdCliente(int idCliente)
        {
            return await _IClienteDat.ObtenerFichaAdmisionByIdCliente(idCliente);
        }

        public async Task<List<ClienteDTO>> BuscarParametros(string p)
        {
            return await _IClienteDat.BuscarParametros(p);
        }

        public async Task<List<CitaDTO>> BuscarCitasAtendidas(int idCliente)
        {
            return await _IClienteDat.BuscarCitasAtendidas(idCliente);
        }

        public async Task<bool> VerificarClientePorDni(string documento)
        {
            return await _IClienteDat.VerificarClientePorDni(documento);
        }


        public async Task<bool> ActualizarDocumentoIdentidad(int idCliente, ClienteDTO model)
        {
            return await _IClienteDat.ActualizarDocumentoIdentidad(idCliente, model);
        }

        public async Task<List<ClienteNuevoDTO>> ObtenerReporteDeNuevosClientes(DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _IClienteDat.ObtenerReporteDeNuevosClientes(fechaDesde, fechaHasta);
        }







        public async Task<ClienteRucDTO> ObtenerRazonSocialClientebyRuc(string ruc) {
            return await _IClienteDat.ObtenerRazonSocialClientebyRuc(ruc);
        }


        public async Task<ClienteDniDTO> ObtenerDatosClientebyDNI(string dni)
        {
            return await _IClienteDat.ObtenerDatosClientebyDNI (dni);
        }







        #region Funciones de Consulta DNI online
        public async Task<ClienteConsultaDniDTO> BuscarPorDNIOnline(string dni)
        {
            return await consultarDNI_Online(dni);
        }
        private async Task<ClienteConsultaDniDTO> consultarDNI_Online(string dni)
        {
            //int tipoRespuesta = 2;
            string mensajeRespuesta = "";

            if (string.IsNullOrWhiteSpace(dni))
            {
                return null;
            }

            Stopwatch oCronometro = new Stopwatch();
            oCronometro.Start();

            CookieContainer cookies = new CookieContainer();
            HttpClientHandler controladorMensaje = new HttpClientHandler();
            controladorMensaje.CookieContainer = cookies;
            controladorMensaje.UseCookies = true;

            ClienteConsultaDniDTO datos = new ClienteConsultaDniDTO();

            using (HttpClient cliente = new HttpClient(controladorMensaje))
            {
                cliente.DefaultRequestHeaders.Add("Host", "eldni.com");
                cliente.DefaultRequestHeaders.Add("sec-ch-ua", "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"90\", \"Google Chrome\";v=\"90\"");
                cliente.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
                cliente.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                cliente.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.93 Safari/537.36");

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 |
                                                       SecurityProtocolType.Tls12;

                string url = "https://eldni.com/pe/buscar-por-dni";
                using (HttpResponseMessage resultadoConsultaToken = await cliente.GetAsync(new Uri(url)))
                {
                    if (resultadoConsultaToken.IsSuccessStatusCode)
                    {
                        mensajeRespuesta = await resultadoConsultaToken.Content.ReadAsStringAsync();

                        string token = ExtraerContenidoEntreNombreString(mensajeRespuesta, 0, "name=\"_token\" value=\"", "\">");

                        cliente.DefaultRequestHeaders.Remove("Sec-Fetch-Site");

                        cliente.DefaultRequestHeaders.Add("Origin", "https://eldni.com");
                        cliente.DefaultRequestHeaders.Add("Referer", "https://eldni.com/pe/buscar-por-dni");
                        cliente.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                       
                        datos._token = token;
                        datos.dni = dni;
                       

                        using (HttpResponseMessage resultadoConsultaDatos = await cliente.PostAsync(url, new StringContent(JsonSerializer.Serialize(datos), Encoding.UTF8, "application/json")))
                        {
                            if (resultadoConsultaDatos.IsSuccessStatusCode)
                            {
                                string contenidoHTML = await resultadoConsultaDatos.Content.ReadAsStringAsync();
                                string nombreInicio = "<table class=\"table table-striped table-scroll\">";
                                string nombreFin = "</table>";
                                string contenidoDNI = ExtraerContenidoEntreNombreString(contenidoHTML, 0, nombreInicio, nombreFin);
                                if (contenidoDNI == "")
                                {
                                    nombreInicio = "<h3 class=\"text-error\">";
                                    nombreFin = "</h3>";
                                    mensajeRespuesta = ExtraerContenidoEntreNombreString(contenidoHTML, 0, nombreInicio, nombreFin);
                                    mensajeRespuesta = mensajeRespuesta == ""
                                        ? string.Format(
                                            "No se pudo realizar la consulta del número de DNI {0}.", dni)
                                        : string.Format(
                                            "No se pudo realizar la consulta del número de DNI {0}.\r\nDetalle: {1}",
                                            dni,
                                            mensajeRespuesta);
                                }
                                else
                                {
                                    nombreInicio = "<td>";
                                    nombreFin = "</td>";
                                    string[] arrResultado = ExtraerContenidoEntreNombre(contenidoDNI, 0,
                                        nombreInicio,
                                        nombreFin);
                                    if (arrResultado != null)
                                    {
                                        // Nombres
                                        arrResultado = ExtraerContenidoEntreNombre(contenidoDNI,
                                            Convert.ToInt32(arrResultado[0]),
                                            nombreInicio, nombreFin);
                                        if (arrResultado != null)
                                        {
                                            datos.dni = dni;
                                            datos.Nombres = arrResultado[1];

                                            // Apellido Paterno
                                            arrResultado = ExtraerContenidoEntreNombre(contenidoDNI,
                                                Convert.ToInt32(arrResultado[0]),
                                                nombreInicio, nombreFin);

                                            if (arrResultado != null)
                                            {
                                                datos.Paterno = arrResultado[1];

                                                // Apellido Materno
                                                arrResultado = ExtraerContenidoEntreNombre(contenidoDNI,
                                                    Convert.ToInt32(arrResultado[0]),
                                                    nombreInicio, nombreFin);

                                                if (arrResultado != null)
                                                {
                                                    datos.Materno = arrResultado[1];
                                                    datos.Respuesta = string.Format("Se realizó exitosamente la consulta del número de DNI {0}", dni);
                                                    //tipoRespuesta = 1;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                mensajeRespuesta = await resultadoConsultaDatos.Content.ReadAsStringAsync();
                                datos.Respuesta = string.Format("Ocurrió un inconveniente al consultar los datos del DNI {0}.\r\nDetalle:{1}", dni, mensajeRespuesta);
                            }
                        }
                    }
                    else
                    {
                        mensajeRespuesta = await resultadoConsultaToken.Content.ReadAsStringAsync();
                        datos.Respuesta = string.Format("Ocurrió un inconveniente al consultar el número de DNI {0}.\r\nDetalle:{1}", dni, mensajeRespuesta);
                    }
                }
            }

            oCronometro.Stop();
            datos.TiempoProcesamiento = oCronometro.Elapsed.TotalSeconds;

            return datos;
        }
        private string ExtraerContenidoEntreNombreString(string cadena, int posicion, string nombreInicio, string nombreFin, StringComparison reglaComparacion = StringComparison.OrdinalIgnoreCase)
        {
            string respuesta = "";
            int posicionInicio = cadena.IndexOf(nombreInicio, posicion, reglaComparacion);
            if (posicionInicio > -1)
            {
                posicionInicio += nombreInicio.Length;
                int posicionFin = cadena.IndexOf(nombreFin, posicionInicio, reglaComparacion);
                if (posicionFin > -1)
                    respuesta = cadena.Substring(posicionInicio, posicionFin - posicionInicio);
            }

            return respuesta;
        }
        private string[] ExtraerContenidoEntreNombre(string cadena, int posicion, string nombreInicio, string nombreFin, StringComparison reglaComparacion = StringComparison.OrdinalIgnoreCase)
        {
            string[] arrRespuesta = null;
            int posicionInicio = cadena.IndexOf(nombreInicio, posicion, reglaComparacion);
            if (posicionInicio > -1)
            {
                posicionInicio += nombreInicio.Length;
                int posicionFin = cadena.IndexOf(nombreFin, posicionInicio, reglaComparacion);
                if (posicionFin > -1)
                {
                    posicion = posicionFin + nombreFin.Length;
                    arrRespuesta = new string[2];
                    arrRespuesta[0] = posicion.ToString();
                    arrRespuesta[1] = cadena.Substring(posicionInicio, posicionFin - posicionInicio);
                }
            }

            return arrRespuesta;
        }
        #endregion


        public async Task<Respuesta<ClienteEnt>> ActualizarFicha(FichaAdmisionEnt model)
        {
            return await _IClienteDat.ActualizarFicha(model);
        }

    }




}
