using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Data.Response;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
     
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApp _cliente;
        public ClienteController(IClienteApp ClienteApp)
        {
            _cliente = ClienteApp;
        }
        [HttpPost]
        [CustomFilter("000005")]
        public async Task<Respuesta<ClienteEnt>> Post(ClienteEnt model)
        {
            try
            {
                return await _cliente.Insertar(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        [HttpPut]
        [CustomFilter("000006")]
        public async Task<Respuesta<ClienteEnt>> Put(ClienteEnt model)
        {
            try
            {
                return await _cliente.Modificar(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpPut("{action}")]
        [CustomFilter("000007")]
        public async Task<Respuesta<ClienteEnt>> ModificarFirma(ClienteEnt model)
        {
            return await _cliente.ModificarFirma(model);
        }
        [HttpGet]
        [CustomFilter("000008")]
        public async Task<IEnumerable<ClienteGridDTO>> Get()
        {
           return await _cliente.Obtener(0);
        }
        [HttpGet("listar10Ultimos")]
        [CustomFilter("000009")]
        public async Task<IEnumerable<ClienteGridDTO>> Listar10Ultimos()
        {
            return await _cliente.Obtener(10);
        }
        [HttpGet("buscar/{str}")]
        [CustomFilter("000010")]
        public async Task<IEnumerable<ClienteGridDTO>> LikeNombre(string str = "")
        {
            return await _cliente.ObtenerByLikeNombre(str);
        }
        [HttpGet("{id}")]
        [CustomFilter("000011")]
        public async Task<ClienteDTO> Get(int id)
        {
            return await _cliente.ObtenerById(id);
        }
        [HttpGet("perfil/{id}")]
        [CustomFilter("000012")]
        public async Task<ClienteDTO> GetPerfil(int id)
        {
            return await _cliente.ObtenerPerfilById(id);
        }
        [HttpGet("zonasCorporalesAtendidas/{id}")]
        [CustomFilter("000013")]
        public async Task<IEnumerable<ClienteZonaCorporalHistoricoDTO>> GetTodasLasZonasCorporales(int id)
        {
            return await _cliente.ObtenerTodasLasZonasCorporales(id);

        }
        [HttpGet("zonasCorporalesAtendidas/{idCliente}/servicio/{idServicio}")]
        [CustomFilter("000014")]
        public async Task<IEnumerable<ClienteZonaCorporalHistoricoDTO>> GetTodasLasZonasCorporalesPorServicio(int idCliente, int idServicio)
        {
            return await _cliente.ObtenerTodasLasZonasCorporalesPorServicio(idCliente, idServicio);

        }
        [HttpGet("buscar/preferente/{nombres}/{apellidos}/{numeros}/{email}")]
        [CustomFilter("000015")]
        public async Task<IEnumerable<ClienteGridDTO>> GetPorPreferente(string nombres, string apellidos, string numeros, string email)
        {
            return await _cliente.ObtenerPorPreferente(nombres, apellidos, numeros, email);
        }
        [HttpGet("firma/{id}")]
        [CustomFilter("000016")]
        public async Task<ClienteEnt> GetFirmaById(int id)
        {
            return await _cliente.ObtenerFirmaById(id);
        }
        [HttpGet("datosMaestros")]
        [CustomFilter("000017")]
        public async Task<ClienteDatosMaestrosDTO> ObtenerDatosMaestros()
        {
            return await _cliente.ObtenerDatosMaestros();
        }
        [HttpGet("validarCelular/{idCliente},{numeroCelular1},{numeroCelular2}")]
        [CustomFilter("000018")]
        public async Task<Respuesta<int>> ValidarNumeroCelular(int idCliente, string numeroCelular1, string numeroCelular2)
        {
            return await _cliente.ValidarNumeroCelular(idCliente, numeroCelular1, numeroCelular2);
        }
        [HttpGet("obtenerFichaAdmisionByIdCliente/{idCliente}")]
        [CustomFilter("000019")]
        public async Task<Respuesta<FichaAdmisionDTO>> ObtenerFichaAdmisionByIdCliente(int idCliente)
        {
            try
            {
                return await _cliente.ObtenerFichaAdmisionByIdCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpGet("byNumeroCelularSinCodigo/{numero1}/{numero2}")]
        [CustomFilter("000020")]
        public async Task<IEnumerable<ClienteGridDTO>> ObtenerByNumeroCelularSinCodigo(string numero1, string numero2)
        {
            try
            {
                return await _cliente.ObtenerByNumeroCelular("", numero1, "", numero2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpGet("byNumeroCelular/{telefonoPais}/{telefono}")]
        [CustomFilter("000021")]
        public async Task<IEnumerable<ClienteGridDTO>> ObtenerByNumeroCelular(string telefonoPais, string telefono)
        {
            try
            {
                return await _cliente.ObtenerByNumeroCelular(telefonoPais, telefono, "", "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("buscarPorDNIOnline/{dni}")]
        [CustomFilter("000022")]
        public async Task<ClienteConsultaDniDTO> BuscarPorDNIOnline(string dni)
        {
            return await _cliente.BuscarPorDNIOnline(dni);
        }
        [HttpPut("fichaRegistro")]
        [CustomFilter("000023")]
        public async Task<Respuesta<ClienteEnt>> ActualizarFicha(FichaAdmisionEnt model)
        {
            return await _cliente.ActualizarFicha(model);
        }
        [HttpGet("buscarParametros/{p}")]
        [CustomFilter("000024")]
        public async Task<ActionResult> BuscarParametros(string p)
        {
            try
            {
                var collection = await _cliente.BuscarParametros(p);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
                throw e;
            }
        }
        [HttpGet("citasAtendidas/{idCliente}")]
        [CustomFilter("000025")]
        public async Task<ActionResult> BuscarCitasAtendidas(int idCliente)
        {
            try
            {
                var collection = await _cliente.BuscarCitasAtendidas(idCliente);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
                throw e;
            }
        }
        [HttpGet("verificar-dni/{documento}")]
        [CustomFilter("000026")]
        public async Task<ActionResult> VerificarClientePorDni(string documento)
        {
            try
            {
                bool data = await _cliente.VerificarClientePorDni(documento);
                return Ok(new
                {
                    data = data,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
                throw e;
            }
        }
        [HttpPut("actualizar-documento-identidad/{idCliente}")]
        [CustomFilter("000027")]
        public async Task<ActionResult> ActualizarDocumentoIdentidad(int idCliente, ClienteDTO model)
        {
            try
            {
                bool data = await _cliente.ActualizarDocumentoIdentidad(idCliente, model);
                return Ok(new
                {
                    data = data,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException e)
            {
                return Ok(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
                throw e;
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
                throw e;
            }
        }
        [HttpGet("reporte-nuevos/{fechaDesde}/{fechaHasta}")]
        [CustomFilter("000028")]
        public async Task<ActionResult> ObtenerReporteDeNuevosClientes(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                List<ClienteNuevoDTO> data = await _cliente.ObtenerReporteDeNuevosClientes(fechaDesde, fechaHasta);
                return Ok(new JsonResponse()
                {
                    Data = data,
                    Error = "",
                    Status = StatusCodes.Status200OK
                });
            }
            catch (AlertException e)
            {
                return Ok(new JsonResponse()
                {
                    Data = new { },
                    Error = e.Message,
                    Status = StatusCodes.Status400BadRequest
                });
                throw e;
            }
            catch (Exception e)
            {
                return BadRequest(new JsonResponse()
                {
                    Data = new { },
                    Error = e.Message,
                    Status = StatusCodes.Status400BadRequest
                });
                throw e;
            }
        }
        [HttpGet("numeroTelefonico/{telefono}")]
        [CustomFilter("000029")]
        public async Task<ActionResult> buscarTelefono(string telefono)
        {
            try
            {
                //int tipoRespuesta = 2;
                string mensajeRespuesta = "";

                if (string.IsNullOrWhiteSpace(telefono))
                {
                    return null;
                }

                Stopwatch oCronometro = new Stopwatch();
                oCronometro.Start();

                List<RClienteConsultaTelefonoDTO> output = new List<RClienteConsultaTelefonoDTO>();


                ClienteConsultaTelefonoDTO datos = new ClienteConsultaTelefonoDTO();
                CookieContainer Cookies = new CookieContainer();
                var handler = new HttpClientHandler();
                handler.UseDefaultCredentials = true;
                handler.UseProxy = false;
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, error) =>
                {
                    /// Access cert object.
                    return true;
                };
                handler.CookieContainer = Cookies;
                handler.UseCookies = true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Add("Host", "numeracionyoperadores.cnmc.es");
                    client.DefaultRequestHeaders.Add("sec-ch-ua", "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"90\", \"Google Chrome\";v=\"90\"");
                    client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
                    client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
                    client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
                    client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
                    client.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
                    client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.93 Safari/537.36");

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 |
                                                           SecurityProtocolType.Tls12;

                    using (HttpResponseMessage response = await client.GetAsync("https://numeracionyoperadores.cnmc.es/portabilidad/movil"))
                    {
                        using (HttpContent content = response.Content)
                        {
                            mensajeRespuesta = await response.Content.ReadAsStringAsync();
                            
                            if (response.IsSuccessStatusCode)
                            {
                                string token = ExtraerContenidoEntreNombreString(mensajeRespuesta, 0, "name=\"_token\" type=\"hidden\" value=\"", "\">");

                                client.DefaultRequestHeaders.Remove("Sec-Fetch-Site");

                                client.DefaultRequestHeaders.Add("Origin", "https://numeracionyoperadores.cnmc.es");
                                client.DefaultRequestHeaders.Add("Referer", "https://numeracionyoperadores.cnmc.es/portabilidad/movil");
                                client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");

                                datos._token = token;
                                datos.numero = telefono;
                                datos.reCaptchaToken = "03ADUVZwC4_jEdrBqkEM2RhjfNoyKlGTCTEw0ax_xq99URubufcITslLwcLywIEyggzLN5lqBBvOXpKDnPBAaucLfY4M4g0f61-CZ43IRDegKy-WWjzCHFOI2a1k50z1pRLrAg4aI49pJZy44DrrI0ALILIMoUi-vmIo0EOpBUjd8jCLbx_hhntZ7CAtKGoFlFvU8-3JiWrR6cGTxRzTmzWvdZ--BQs5n0pOxQWeLb0Lk1se4V9kvXrYpay6V9gSposNNcen059sOpowQjTx7u7OdBoMuazsAFtgJrP86-LMbx7Tav3vPUlx6sYKZpW0bEGMNOYn_8kc7SS6ltQQgwsg1YN0cbFppj6so5YPgIPHRoXaFvOB_vys6v81NsRmBXoXXIkE9EfaOFtiB3CLIcFyQweM0YflFenPe2UgVxGhgSJbgXcpOq8U9nrwh8X7XPwJil19lV2Dtgux6MDJC4uTWk8pinM7Zi_04oifs-ZgHGjX8oohknM8rl_x27oSoChDZjotO1__RsyHDrR4CSRU9bFJ5v36x090_PgNuMv14iBx2V77d4uKnryD2vKfS54L6gYd8jWYouf5kuZjs2wxo5CatBwUCVL2amZUo1fZ8qZjj61390LuBRmFkIt4Kfzlq99tU6XFTzHPqASAN56l9BQmI6SUH523n6pYuYd2k_vQfzbjWt0m4QBrAadfvYROqbRiT1lhPG_wne350L--7DBxwWuHSiB2cJ4YgeiocwwX-Y9sZwuh-40XgKEpV0a1iALcRhXWcvdQ4aBBi0xsCiKKhJNR2jzYfB21wJJwsAxUKjDoQMVHdSK_l6BtUYgMAmuI0Dp1lEn89WLqewEUyMXLfCT-ts52ZfyHYpuekvDXV1rYxfYW1_igjvoCwLi-wbdYkJ1AYLPNrTpe__m_UuRsR_V5DXTC3Vg4oFbcTEzyhy3_Hhz2PorFS_ZPZ-lf-1LkK-frDbx7Mt6Djck_fkO0Pl5trfe9pR7Pp8pvyowlKHstF-mKdffrZUGi6Jmf2jnN0YifvEsATviXxTEJOyiP6oFqzcFxPJEqITJ5f2ibDb0YqAzeVKJzKudQpCP2NZjD7e3gO3kMKwgXu9t_17IUjBm64fE6_mkTeyic7UBNN-SICoqNiIrVwM5BwJYlCMjz24dGm_O_5_VmZJIToVtDR8Gnsl2rZE3PxYrXW594anRPDqCSHnszxJEAQgwXsP8TgVq9Q5-7eBMTnfZElhBRrejfLljH0PYPzXqOAdV0QFSaONAkqaUm7yRmsN4MvZOBloH9M-ehNukKe_jDLAMtalqfTc1wFkJyFfduGzCfSw9gx_9JgCPdh-ibnlCVlv2_j3ANoDCNJl_BafFPZ6PyptVfsFCQ";
                                //datos.g-recaptcha-response = "03ADUVZwABOkNu0Bb_NVtK_5Fl3zajs7Q2mFMcQ99vbSIvZGPQ__CozSXiq4Ho6EGe78AUD5egKp9UURZVJ_JOhqECUCFrX0a8yObQnmx-dqBbHEVuiI7qRHAXe8i4TX2SJfSHb-M1vsD0tVjCnFdHbgd25V52aCV1Kd8N1KD9jcr0NDw6KkqhsiTbvW2PNapQo2u1oQKGRNuU23O3bYfm2sYLuYCl-A5ZGPgs9oKjg7qiyVLvWxJy-8yyyd4TyAQNnv_KU4o8hru55fDhdTsyIiNCrz289MZmv_i8L-7WN-EMRFsK5OyxuIXEGY0q_vPFaStz-IpnQHey2-CpYt_-iqJeLHom7_GIRHqamYRxEgd3VHT2OWHCe3-3xX6Gaiwkor6yGDFRHE29ZL8TAbFyMFEhuy-X-_UHiH9bWhxMcUIkfPh3pQxrIobGbXpbpEj2MXYTEdAKKi-h-K8G2A9vuQaTFN33enoO40g737zN_izWLumF_cvcu0Ak12khZfFKLDLBDDGoTL6Siq4r2KeO72xIb6x-Fh0y0AhUTXdaY-HWz1guCiAYPP9GTgBGyZO-VLK_mAibj7nk";

                                // Consultar datos
                                using (HttpResponseMessage resultadoConsultaDatos = await client.PostAsync("https://numeracionyoperadores.cnmc.es/portabilidad/movil/operador", new StringContent(JsonSerializer.Serialize(new {
                                    _token = token,
                                    numero = telefono,
                                    reCaptchaToken = "03ADUVZwC4_jEdrBqkEM2RhjfNoyKlGTCTEw0ax_xq99URubufcITslLwcLywIEyggzLN5lqBBvOXpKDnPBAaucLfY4M4g0f61-CZ43IRDegKy-WWjzCHFOI2a1k50z1pRLrAg4aI49pJZy44DrrI0ALILIMoUi-vmIo0EOpBUjd8jCLbx_hhntZ7CAtKGoFlFvU8-3JiWrR6cGTxRzTmzWvdZ--BQs5n0pOxQWeLb0Lk1se4V9kvXrYpay6V9gSposNNcen059sOpowQjTx7u7OdBoMuazsAFtgJrP86-LMbx7Tav3vPUlx6sYKZpW0bEGMNOYn_8kc7SS6ltQQgwsg1YN0cbFppj6so5YPgIPHRoXaFvOB_vys6v81NsRmBXoXXIkE9EfaOFtiB3CLIcFyQweM0YflFenPe2UgVxGhgSJbgXcpOq8U9nrwh8X7XPwJil19lV2Dtgux6MDJC4uTWk8pinM7Zi_04oifs-ZgHGjX8oohknM8rl_x27oSoChDZjotO1__RsyHDrR4CSRU9bFJ5v36x090_PgNuMv14iBx2V77d4uKnryD2vKfS54L6gYd8jWYouf5kuZjs2wxo5CatBwUCVL2amZUo1fZ8qZjj61390LuBRmFkIt4Kfzlq99tU6XFTzHPqASAN56l9BQmI6SUH523n6pYuYd2k_vQfzbjWt0m4QBrAadfvYROqbRiT1lhPG_wne350L--7DBxwWuHSiB2cJ4YgeiocwwX-Y9sZwuh-40XgKEpV0a1iALcRhXWcvdQ4aBBi0xsCiKKhJNR2jzYfB21wJJwsAxUKjDoQMVHdSK_l6BtUYgMAmuI0Dp1lEn89WLqewEUyMXLfCT-ts52ZfyHYpuekvDXV1rYxfYW1_igjvoCwLi-wbdYkJ1AYLPNrTpe__m_UuRsR_V5DXTC3Vg4oFbcTEzyhy3_Hhz2PorFS_ZPZ-lf-1LkK-frDbx7Mt6Djck_fkO0Pl5trfe9pR7Pp8pvyowlKHstF-mKdffrZUGi6Jmf2jnN0YifvEsATviXxTEJOyiP6oFqzcFxPJEqITJ5f2ibDb0YqAzeVKJzKudQpCP2NZjD7e3gO3kMKwgXu9t_17IUjBm64fE6_mkTeyic7UBNN-SICoqNiIrVwM5BwJYlCMjz24dGm_O_5_VmZJIToVtDR8Gnsl2rZE3PxYrXW594anRPDqCSHnszxJEAQgwXsP8TgVq9Q5-7eBMTnfZElhBRrejfLljH0PYPzXqOAdV0QFSaONAkqaUm7yRmsN4MvZOBloH9M-ehNukKe_jDLAMtalqfTc1wFkJyFfduGzCfSw9gx_9JgCPdh-ibnlCVlv2_j3ANoDCNJl_BafFPZ6PyptVfsFCQ",
                                    //grecaptcharesponse = "03ADUVZwABOkNu0Bb_NVtK_5Fl3zajs7Q2mFMcQ99vbSIvZGPQ__CozSXiq4Ho6EGe78AUD5egKp9UURZVJ_JOhqECUCFrX0a8yObQnmx-dqBbHEVuiI7qRHAXe8i4TX2SJfSHb-M1vsD0tVjCnFdHbgd25V52aCV1Kd8N1KD9jcr0NDw6KkqhsiTbvW2PNapQo2u1oQKGRNuU23O3bYfm2sYLuYCl-A5ZGPgs9oKjg7qiyVLvWxJy-8yyyd4TyAQNnv_KU4o8hru55fDhdTsyIiNCrz289MZmv_i8L-7WN-EMRFsK5OyxuIXEGY0q_vPFaStz-IpnQHey2-CpYt_-iqJeLHom7_GIRHqamYRxEgd3VHT2OWHCe3-3xX6Gaiwkor6yGDFRHE29ZL8TAbFyMFEhuy-X-_UHiH9bWhxMcUIkfPh3pQxrIobGbXpbpEj2MXYTEdAKKi-h-K8G2A9vuQaTFN33enoO40g737zN_izWLumF_cvcu0Ak12khZfFKLDLBDDGoTL6Siq4r2KeO72xIb6x-Fh0y0AhUTXdaY-HWz1guCiAYPP9GTgBGyZO-VLK_mAibj7nk"
                            }), Encoding.UTF8, "application/json")))
                                {
                                    if (resultadoConsultaDatos.IsSuccessStatusCode )
                                    {
                                        string contenidoHTML = await resultadoConsultaDatos.Content.ReadAsStringAsync();

                                        string nombreDesde = "</form>";
                                        string nombreInicio = "<div class=\"col-md-12\">";
                                        string nombreFin = "</div>";
                                        string contenidoFormulario = ExtraerContenidoString(contenidoHTML, nombreDesde, nombreInicio, nombreFin);


                                        // Buscar si hay mensajes de error
                                        string error = ObtenerMensajeError(contenidoFormulario, "alert-danger");
                                        if(  error != "" )
                                        {
                                            DateTime now = DateTime.Now;
                                            return Ok(new
                                            {
                                                data = new {
                                                    number = telefono,
                                                    operador = "",
                                                    dateConsult = now.ToString("dd-MM-yyyy HH:mm:ss")
                                                },
                                                mensaje = error,
                                                status = 400
                                            });
                                        }

                                        string operador = ExtraerOperadorActual(contenidoFormulario,"Operador actual</p>", "<p>","</p>");

                                        return Ok(new{
                                            data = new {
                                                number = telefono,
                                                operador = operador,
                                                dateConsult = ""
                                            },
                                            mensaje = "",
                                            status = 200
                                        });
                                    }
                                    else
                                    {
                                        mensajeRespuesta = await resultadoConsultaDatos.Content.ReadAsStringAsync();
                                        return BadRequest(new
                                        {
                                            data = new { },
                                            mensaje = mensajeRespuesta,
                                            status = 400
                                        });
                                    }
                                }
                            }
                            else
                            {
                                return BadRequest(new{
                                    data = new { },
                                    mensaje = mensajeRespuesta,
                                    status = 400
                                });
                            }
                        }
                    }
                }

                oCronometro.Stop();
                //datos.TiempoProcesamiento = oCronometro.Elapsed.TotalSeconds;


                return Ok(new{
                    data = datos,
                    mensaje = "",
                    status = 200
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new{
                    data = new { },
                    mensaje = ex.Message,
                    status = 400
                });
            }
        }
        private string ExtraerContenidoString(string cadena, string nombreDesde, string nombreInicio, string nombreFin, int numeroFinEncontrado = 1 , StringComparison reglaComparacion = StringComparison.OrdinalIgnoreCase)
        {
            string respuesta = "";
            //int encontradoFin = 0;


            // obtenemos la posición desde donde inicia la busqueda
            int posicionDesde = cadena.IndexOf(nombreDesde, 0, reglaComparacion);
            if( posicionDesde > -1)
            {
                // actualizamos la posicion desde
                posicionDesde += nombreDesde.Length;

                // obtenemos la posición de la primera coincidencia
                int posicionInicio = cadena.IndexOf(nombreInicio, posicionDesde, reglaComparacion);
                if (posicionInicio > -1)
                {
                    posicionInicio += nombreInicio.Length;


                    int posicionFin = cadena.IndexOf(nombreFin, posicionInicio, reglaComparacion);
                    if (posicionFin > -1)
                    {
                        respuesta = cadena.Substring(posicionInicio, posicionFin - posicionInicio);
                    }

                }

            }

            return respuesta;
        }
        private string ObtenerMensajeError( string cadena, string claseGuia )
        {
            string output = "";
            int posicionInicio = cadena.IndexOf(claseGuia, 0, StringComparison.OrdinalIgnoreCase);
            if (posicionInicio > -1)
            {
                int posicionMensajeInicio = cadena.IndexOf("<li>", 0, StringComparison.OrdinalIgnoreCase);
                posicionMensajeInicio += "<li>".Length;
                int posicionMensajeFin = cadena.IndexOf("</li>", posicionMensajeInicio, StringComparison.OrdinalIgnoreCase);
                if(posicionMensajeFin > -1)
                {
                    output = cadena.Substring(posicionMensajeInicio, posicionMensajeFin - posicionMensajeInicio);
                }
            }
            return output;
        }
        private string ExtraerOperadorActual(string cadena, string primerNombre, string segundoNombre, string final , StringComparison reglaComparacion = StringComparison.OrdinalIgnoreCase)
        {
            string respuesta = "";
            int posicionInicio = cadena.IndexOf(primerNombre, 0, reglaComparacion);
            if (posicionInicio > -1)
            {
                posicionInicio += primerNombre.Length;
                posicionInicio = cadena.IndexOf(segundoNombre, posicionInicio, reglaComparacion);

                if (posicionInicio > -1) {
                    posicionInicio += segundoNombre.Length;

                    int posicionFin = cadena.IndexOf(final, posicionInicio, reglaComparacion);
                    if (posicionFin > -1)
                        respuesta = cadena.Substring(posicionInicio, posicionFin - posicionInicio);
                }
                
            }

            return respuesta;
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
        [HttpGet("ruc/{ruc}")]
        [CustomFilter("000030")]
        public async Task<ActionResult> ObtenerClienteRuc(string ruc) {
            try
            {
                ClienteRucDTO data = await _cliente.ObtenerRazonSocialClientebyRuc(ruc);

                if (data.data != null)
                {
                    return Ok(new
                    {
                        data.data,
                        mensaje = "",
                        status = StatusCodes.Status200OK
                    });
                }
                else {
                    return Ok(new
                    {
                        data.data,
                        mensaje = "No se encontro el ruc",
                        status = StatusCodes.Status404NotFound
                    });
                }
                
            }
            catch (Exception ex)
            {

                return Ok(new
                {
                    data = new { },
                    mensaje =ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            
        }
        [HttpGet("dni/{dni}")]
        [CustomFilter("000031")]
        public async Task<ActionResult> ObtenerClienteDni(string dni)
        {
            try
            {
                ClienteDniDTO data = await _cliente.ObtenerDatosClientebyDNI(dni);

                if (data.data != null)
                {
                    return Ok(new
                    {
                        data.data,
                        mensaje = "",
                        status = StatusCodes.Status200OK
                    });
                }
                else
                {
                    return Ok(new
                    {
                        data.data,
                        mensaje = "No se encontro el DNI",
                        status = StatusCodes.Status404NotFound
                    });
                }

            }
            catch (Exception ex)
            {

                return Ok(new
                {
                    data = new { },
                    mensaje = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }

        }
    }
}