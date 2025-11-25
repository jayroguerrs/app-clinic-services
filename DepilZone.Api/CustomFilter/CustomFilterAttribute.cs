using DepilZone.Application.Interface;
using DepilZone.Entidad.DTO;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace DepilZone.Api.CustomFilter
{

    public class CustomFilterAttribute : ActionFilterAttribute
    {
        private readonly string[] _someStrings;

        private const string VersionFrontEndRequerida = "3.2.1";

        public CustomFilterAttribute(params string[] someStrings)
        {
            _someStrings = someStrings ?? Array.Empty<string>();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //------------------------- QUALITY --------------------------

            // Cloud Azure
            //String ConnectionString = "Server=tcp:servqa-depilzone-dbsql.database.windows.net,1433;Initial Catalog=dbqa-clinic;Persist Security Info=False;User ID=saqa-xi;Password=3tN<=b559}F4;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            // Windows Serv
            //String ConnectionString = "Server=52.149.219.141,1444;Database=PDBDepilZoneQA;User ID=usrappclinic;Password=j0p67MzN%uYj;Connection Timeout=300;Encrypt=false;TrustServerCertificate=true;";
            //String ConnectionString = "Server=.;Database=PDBDepilZoneQA;User ID=usrappclinic;Password=j0p67MzN%uYj;Connection Timeout=300";

            // PreDeploy Windows Serv
            //String ConnectionString = "Server=52.147.202.172,1433;Database=PDBDepilzone;User ID=usrappclinic;password=testing$123;Connection Timeout=300;";

            // Phisic Serv Local
            //String ConnectionString = "Server=172.16.1.8;Database=PDBDepilZone;User ID=usrappclinic;Password=temporal$123;Connection Timeout=300;Encrypt=false;TrustServerCertificate=true;";

            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

            //------------------------- DEVELOPMENT --------------------------
            // Local Server - PC1
            //String ConnectionString = "Server=.;Database=PDBDepilZone090925;User ID=sa;password=123456;Connection Timeout=300;";

            // Server Local - PC2
            String ConnectionString = "Server=localhost\\SQLEXPRESS;Database=PDBDepilZone;User ID=sa;password=123456;Connection Timeout=300;";

            // Docker
            //String ConnectionString = "Server=192.168.56.1,1433;Database=PDBDepilZone_250825;User ID=sa;password=123456;Connection Timeout=300;";    
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

            //------------------------- PRODUCTION --------------------------
            // Windows Serv
            //String ConnectionString = "Server=52.149.219.141,1444;Database=PDBDepilZone;User ID=usrappclinic;Password=mT9B2x97A5$4;Connection Timeout=300;Encrypt=false;TrustServerCertificate=true;";

            // Cloud Azure
            //String ConnectionString = "Server=tcp:serv-alpha.database.windows.net,1433;Initial Catalog=sa-xiii;Persist Security Info=False;User ID=sa-xii;Password=#0A00Dwo},r@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; 
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

            List<MenuRutaDetDTO> listaMenuRuta = new List<MenuRutaDetDTO>();
            List<MenuPrivilegioDetDTO> listaMenuPrivilegioRuta = new List<MenuPrivilegioDetDTO>();
            int privilegioUsuarioActual = 0;
            /* Lectura Token */
            /* INICIO */
            var request = context.HttpContext.Request;
            var ipConn = context.HttpContext.Connection.RemoteIpAddress?.ToString();
            var method = request.Method;
            var path = request.Path;
            var queryString = request.QueryString;
            var token = request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var userAgent = request.Headers["User-Agent"].ToString();

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var jwtToken = handler.ReadJwtToken(token);
            var claims = jwtToken.Claims;
            var usuario = claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            /* FIN */




            /* VALIDACION VERSION DEL FRONTEND */
            if (!context.HttpContext.Request.Headers.TryGetValue("App-Version", out var frontendVersion) ||
                frontendVersion != VersionFrontEndRequerida)
            {
                context.Result = new JsonResult(new { message = "Tiene una versión de Frontend desactualizada. Por favor, actualícela." })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
                return;
            }

            /* VALIDACION VERSION DE LA DB */
            try
            {
                using SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                using SqlCommand cmd = new SqlCommand("SP_ObtenerParametroSistemaVersion", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string? dbVersion = null;

                    if (reader["Version"] != DBNull.Value)
                    {
                        dbVersion = reader["Version"].ToString();
                        if(dbVersion != VersionFrontEndRequerida)
                        {
                            context.Result = new JsonResult(new { message = "La version del Sistema esta desactualizada. Por favor, actualicela." })
                            {
                                StatusCode = StatusCodes.Status401Unauthorized
                            };
                            return;
                        }
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /* FIN */


            /* FIN DE LA VALIDACION DEL FRONTEND */

            /* INSERCION AUDIT REQUEST */
            // Json
            var body = "";
            var rpta = "";
            // Capturar cuerpo JSON (si está presente)
            if (context.HttpContext.Request.ContentType == "application/json")
            {
                context.HttpContext.Request.EnableBuffering(); // Permite leer el cuerpo varias veces
                using (var reader = new StreamReader(context.HttpContext.Request.Body))
                {
                    body = reader.ReadToEndAsync().Result; // Lee el cuerpo
                }
            }
                        
            #region Validacion Acceso Ip
            /* VALIDACION ACCESO IP */
            /* INICIO */

            Int32 Res = 0;
            try
            {
                using SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                using SqlCommand cmd = new SqlCommand("SP_SegSistema", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pIP", ipConn);
                cmd.Parameters.AddWithValue("@pIdUsuario", usuario);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["Res"] != DBNull.Value && int.TryParse(reader["Res"].ToString(), out Res)) {
                        Res = Convert.ToInt32(reader["Res"].ToString());
                    }
                    else {
                        Res = 0;
                    }                    
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /* FIN */
            #endregion
            //QA-AZURE ONLY CONECTION ABOUT CONTAINER

            //if (Res > 0)
            //{
                #region Consulta Accesos Usuario
                /* CONSULTA ACCESOS USUARIO */
                /* INICIO */
                try
                {
                    using SqlConnection conn = new SqlConnection(ConnectionString);
                    conn.Open();
                    using SqlCommand cmd = new SqlCommand("SP_MenuUsuario", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("pUsuario", usuario);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        MenuRutaDetDTO menuRuta = new MenuRutaDetDTO()
                        {
                            IdMenu = Convert.ToInt32(reader["IdMenu"]),
                            Proceso = reader["NombProc"].ToString(),
                            Metodo = reader["MetdCtrl"].ToString(),
                            Estado = reader["EstaAcc"].ToString(),
                            CodMenu = reader["CodgAcc"].ToString()
                        };
                        listaMenuRuta.Add(menuRuta);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                /* FIN */

                /* MENU CON PRIVILEGIOS */
                /* CONSULTA ACCESOS USUARIO */
                ///* INICIO */
                try
                {
                    using SqlConnection conn = new SqlConnection(ConnectionString);
                    conn.Open();
                    using SqlCommand cmd = new SqlCommand("SP_Menu_ObtenerConPrivilegios", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        MenuPrivilegioDetDTO menuRuta = new MenuPrivilegioDetDTO()
                        {
                            Id = Convert.ToInt32(reader["IdMenu"]),
                            Privilegios = reader["Privilegios"] == DBNull.Value ? new List<int>() : JsonSerializer.Deserialize<List<int>>(reader["Privilegios"].ToString()),
                            Ruta = reader["Url"].ToString()
                        };
                        listaMenuPrivilegioRuta.Add(menuRuta);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                try
                {
                    using SqlConnection conn = new SqlConnection(ConnectionString);
                    conn.Open();
                    using SqlCommand cmd = new SqlCommand("SP_ObtenerPrivilegioDeUsuario", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("pUsuario", usuario);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        privilegioUsuarioActual = Convert.ToInt32(reader["Privilegio"]);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                ///* FIN */
                #endregion
                #region Registro Auditoria
                /* REGISTRO AUDITORIA */
                /* INICIO */
                try
                {

                    using SqlConnection conn = new SqlConnection(ConnectionString);
                    conn.Open();
                    using SqlCommand cmd = new SqlCommand("SP_INS_AuditRequest", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("IpSolicitud", ipConn);
                    cmd.Parameters.AddWithValue("Metodo", method + "  ||  " + path + " || " + queryString);
                    cmd.Parameters.AddWithValue("ParamHeader", "Peticion Interna");
                    cmd.Parameters.AddWithValue("ParamJson", body);
                    cmd.Parameters.AddWithValue("FechaHoraSolicitud", DateTime.Now);
                    cmd.Parameters.AddWithValue("Usuario", usuario);
                    cmd.Parameters.AddWithValue("Accion", "Peticion Correcta");
                    cmd.Parameters.AddWithValue("LugarConexion", userAgent);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        rpta = "Registro con exito";
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                /* FIN */
                #endregion
                
                // Verificar Acceso
                var CodMenuCtl = _someStrings[0].ToString();

                if (CodMenuCtl.StartsWith("PRIV-", StringComparison.OrdinalIgnoreCase))
                {
                    var partesRuta = CodMenuCtl.Split('-');
                    var rutaConPrivilegio = partesRuta.Length > 1 ? partesRuta[1].Trim() : string.Empty;

                    if (string.IsNullOrEmpty(rutaConPrivilegio))
                    {
                        context.Result = new JsonResult(new { message = "Ruta de privilegio no válida." })
                        {
                            StatusCode = StatusCodes.Status400BadRequest
                        };
                        return;
                    }

                    // Buscar en la lista de rutas con privilegios
                    var menuConPrivilegio = listaMenuPrivilegioRuta
                        .Find(x => x.Ruta != null && x.Ruta.Trim().Equals(rutaConPrivilegio, StringComparison.OrdinalIgnoreCase));

                    if (menuConPrivilegio == null)
                    {
                        context.Result = new JsonResult(new { message = "Ruta de privilegio no encontrada." })
                        {
                            StatusCode = StatusCodes.Status401Unauthorized
                        };
                        return;
                    }

                    // Validar si el privilegio del usuario actual está dentro del array de privilegios de esa ruta
                    if (menuConPrivilegio.Privilegios != null &&
                        menuConPrivilegio.Privilegios.Contains(privilegioUsuarioActual))
                    {
                        // ✅ Tiene el privilegio → permitir acceso
                        base.OnActionExecuting(context);
                    }
                    else
                    {
                        // ❌ No tiene permiso
                        context.Result = new JsonResult(new { message = "No tienes el privilegio necesario para acceder a esta ruta. @111" })
                        {
                            StatusCode = StatusCodes.Status401Unauthorized
                        };
                        return;
                    }

                }
                else
                {
                    var IsCorrect = listaMenuRuta.Find(x => x.CodMenu.ToString().Trim() == CodMenuCtl.ToString().Trim() &&
                                                             x.Metodo.ToString().Trim() == method.ToString().Trim());
                    if (IsCorrect != null)
                    {
                        base.OnActionExecuting(context);
                    }
                    else
                    {
                        context.Result = new JsonResult(new { message = "Parece que necesitas más permisos para ingresar a este módulo !!! @222" })
                        {
                            StatusCode = StatusCodes.Status401Unauthorized
                        };
                        return;
                    }
                }

            //}
            //else {

            //    try
            //    {
            //        using SqlConnection conn = new SqlConnection(ConnectionString);
            //        conn.Open();
            //        using SqlCommand cmd = new SqlCommand("SP_INS_AuditRequest", conn)
            //        {
            //            CommandType = System.Data.CommandType.StoredProcedure
            //        };
            //        cmd.Parameters.AddWithValue("IpSolicitud", ipConn);
            //        cmd.Parameters.AddWithValue("Metodo", method + "  ||  " + path + " || " + queryString);
            //        cmd.Parameters.AddWithValue("ParamHeader", "Peticion Externa");
            //        cmd.Parameters.AddWithValue("ParamJson", body);
            //        cmd.Parameters.AddWithValue("FechaHoraSolicitud", DateTime.Now);
            //        cmd.Parameters.AddWithValue("Usuario", usuario);
            //        cmd.Parameters.AddWithValue("Accion", "Peticion Fallida");
            //        cmd.Parameters.AddWithValue("LugarConexion", userAgent);

            //        if (cmd.ExecuteNonQuery() > 0)
            //        {
            //            rpta = "Registro con exito";
            //        }

            //        conn.Close();
            //    }
            //    catch (Exception ex)
            //    {

            //    }

            //    context.Result = new JsonResult(new { message = "Parece que necesitas más permisos para ingresar a este módulo !!! @333" })
            //    {
            //        StatusCode = StatusCodes.Status401Unauthorized
            //    };
            //    return;
            //}                                        
        }
    }

}
