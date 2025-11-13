using DepilZone.Api.CustomFilter;
using DepilZone.Data.Response;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.DTO.Facturacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SunatController : ControllerBase
    {

        public SunatController()
        {
        }

        [HttpGet("consulta/{numero}/{idTipoDocumento}")]
        [CustomFilter("000449")]
        public async Task<ActionResult> Consulta(string numero, int idTipoDocumento)
        {

            //string json_de_respuesta = SendJson("https://apiperu.dev/api/dni/45846461", json_en_utf_8, "", "GET");

            String entidad = "";
            switch (idTipoDocumento) {
                case ((int)EnumTipoDocumento.Dni): entidad = "dni";break;
                case ((int)EnumTipoDocumento.Ruc): entidad = "ruc";break;
                default: entidad = "dni";break;
            }


            using (var client = new WebClient())
            {
                try
                {
                    client.UseDefaultCredentials = true;
                    client.Headers.Add("Content-Type:application/json");
                    //client.Headers.Add("Accept:application/json");
                    client.Headers.Add("Authorization:Bearer " + "a5bdef314a35982b50643ce82acc3471ca57cd074e3ef9f15e6132f6d38e8f83");
                    client.BaseAddress = "https://apiperu.dev/api/"+entidad+"/"+numero;


                    String json = client.DownloadString("");
                    dynamic r = JsonSerializer.Deserialize<dynamic>(json);
                    json = JsonSerializer.Serialize(r);
                    //Console.WriteLine(json);
                    byte[] bytes = Encoding.Default.GetBytes(json);
                    string json_en_utf_8 = Encoding.UTF8.GetString(bytes);

                    if (entidad == "dni")
                    {
                        RespuestaDni res = JsonSerializer.Deserialize<RespuestaDni>(json_en_utf_8);
                        //respuesta = res;

                        if (res.success) {
                            return Ok(new
                            {
                                data = new
                                {
                                    numero = res.data.numero,
                                    nombre = res.data.nombres + " " + res.data.apellido_paterno + " " + res.data.apellido_materno,
                                    direccion = "",
                                    fechanacimiento = res.data.fecha_nacimiento,
                                    sexo = res.data.sexo
                                },
                                error = new { },
                                status = StatusCodes.Status200OK
                            });
                        }
                        else
                        {
                            return Ok(new JsonResponse() {
                                     Data = null,
                                     Error = "Ocurrio un error con el servicio de consulta",
                                     Status = StatusCodes.Status400BadRequest
                                });
                        }

                        
                    }
                    else {
                        RespuestaRuc res = JsonSerializer.Deserialize<RespuestaRuc>(json_en_utf_8);
                        //respuesta = res;

                        if (res.success)
                        {
                            return Ok(new
                            {
                                data = new
                                {
                                    numero = res.data.ruc,
                                    nombre = res.data.nombre_o_razon_social,
                                    direccion = res.data.direccion_completa
                                },
                                error = new { },
                                status = StatusCodes.Status200OK
                            });
                        }
                        else {
                            return Ok(new JsonResponse()
                            {
                                Data = null,
                                Error = "Ocurrio un error con el servicio de consulta",
                                Status = StatusCodes.Status400BadRequest
                            });
                        }

                    }
                    


                }
                catch (WebException ex)
                {
                    // Http Error
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        var webResponse = (HttpWebResponse)ex.Response;
                        var statusCode = (int)webResponse.StatusCode;
                        var msg = webResponse.StatusDescription;

                        return Ok(new JsonResponse()
                        {
                            Data = null,
                            Error = "Ocurrio un error con el servicio de consulta",
                            Status = StatusCodes.Status400BadRequest
                        });
                        //throw new HttpException(statusCode, msg);
                    }
                    else
                    {
                        return Ok(new JsonResponse()
                        {
                            Data = null,
                            Error = "Ocurrio un error con el servicio de consulta",
                            Status = StatusCodes.Status400BadRequest
                        });

                        //throw new HttpException(500, ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    return Ok(new JsonResponse()
                    {
                        Data = null,
                        Error = "Ocurrio un error con el servicio de consulta",
                        Status = StatusCodes.Status400BadRequest
                    });
                }
            }


           /* return Ok(new
            {
                data = new { },
                status = StatusCodes.Status200OK
            });*/
        }
        static string SendJson(string ruta, string json, string token, string method)
        {
            try
            {
                using (var client = new WebClient())
                {
                    /// ESPECIFICAMOS EL TIPO DE DOCUMENTO EN EL ENCABEZADO
                    client.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                    /// ASI COMO EL TOKEN UNICO
                    client.Headers[HttpRequestHeader.Authorization] = "Bearer " + "a5bdef314a35982b50643ce82acc3471ca57cd074e3ef9f15e6132f6d38e8f83";
                    /// OBTENEMOS LA RESPUESTA
                    string respuesta = client.UploadString(ruta, method, json);
                    /// Y LA 'RETORNAMOS'
                    return respuesta;
                }
            }
            catch (WebException ex)
            {
                /// EN CASO EXISTA ALGUN ERROR, LO TOMAMOS
                var respuesta = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                /// Y LO 'RETORNAMOS'
                return respuesta;
            }
        }
    }

    public class RespuestaDni {
        public bool success { get; set; }
        public RespuestaDataDni data { get; set; }
    }
    public class RespuestaDataDni {
        public string numero { get; set; }
        public string nombre_completo { get; set; }
        public string nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public int codigo_verificacion { get; set; }
        public string fecha_nacimiento { get; set; }
        public string sexo { get; set; }

    }


    public class RespuestaRuc
    {
        public bool success { get; set; }
        public RespuestaDataRuc data { get; set; }
    }
    public class RespuestaDataRuc
    {
        public string origen { get; set; }
        public string ruc { get; set; }
        public string nombre_o_razon_social { get; set; }
        public string estado { get; set; }
        public string condicion { get; set; }
        public string direccion { get; set; }
        public string direccion_completa { get; set; }

    }
}
