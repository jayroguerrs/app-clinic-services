using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;

namespace DepilZone.Api.CustomFilter
{
    public class LandingFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //------------------------- QUALITY --------------------------

            // Cloud Azure
            //String ConnectionString = "Server=tcp:servqa-depilzone-dbsql.database.windows.net,1433;Initial Catalog=dbqa-clinic;Persist Security Info=False;User ID=saqa-xi;Password=3tN<=b559}F4;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            // Windows Serv
            //String ConnectionString = "Server=52.149.219.141,1444;Database=PDBDepilZoneQA;User ID=usrappclinic;Password=j0p67MzN%uYj;Connection Timeout=300;Encrypt=false;TrustServerCertificate=true;";
            //String ConnectionString = "Server=.;Database=PDBDepilZoneQA;User ID=usrappclinic;password=j0p67MzN%uYj;Connection Timeout=300;";

            // PreDeploy Windows Serv
            //String ConnectionString = "Server=52.147.202.172,1433;Database=PDBDepilzone;User ID=usrappclinic;password=testing$123;Connection Timeout=300;";

            // Phisic Serv Local
            //String ConnectionString = "Server=172.16.1.8;Database=PDBDepilZone;User ID=usrappclinic;Password=temporal$123;Connection Timeout=300;Encrypt=false;TrustServerCertificate=true;";

            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

            //------------------------- DEVELOPMENT --------------------------
            // Local Server - PC1
            //String ConnectionString = "Server=.;Database=PDBDepilZone090925;User ID=sa;password=123456;Connection Timeout=300;";

            // Server Local - PC2
            //String ConnectionString = "Server=localhost\\SQLEXPRESS;Database=PDBDepilZone;User ID=sa;password=123456;Connection Timeout=300;";

            // Docker
            //String ConnectionString = "Server=192.168.56.1,1433;Database=PDBDepilZone_250825;User ID=sa;password=123456;Connection Timeout=300;";    
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

            //------------------------- PRODUCTION --------------------------
            // Windows Serv
            String ConnectionString = "Server=52.149.219.141,1444;Database=PDBDepilZone;User ID=usrappclinic;Password=mT9B2x97A5$4;Connection Timeout=300;Encrypt=false;TrustServerCertificate=true;";

            // Cloud Azure
            //String ConnectionString = "Server=tcp:serv-alpha.database.windows.net,1433;Initial Catalog=sa-xiii;Persist Security Info=False;User ID=sa-xii;Password=#0A00Dwo},r@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; 
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

            var request = context.HttpContext.Request;
            var ipConn = context.HttpContext.Connection.RemoteIpAddress?.ToString();
            var method = request.Method;
            var path = request.Path;
            var queryString = request.QueryString;            
            var userAgent = request.Headers["User-Agent"].ToString();

            /* Token */
            var token = request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            var jwtToken = handler.ReadJwtToken(token);
            var claims = jwtToken.Claims;
            var _usuario = claims.FirstOrDefault(c => c.Type == "User")?.Value;
            var _token = claims.FirstOrDefault(c => c.Type == "Token")?.Value;

            try {                
                var isWebRequest = userAgent.Contains("Mozilla") || userAgent.Contains("Chrome") || userAgent.Contains("Safari");

                if (context.HttpContext.Request.Method == HttpMethods.Post)
                {
                    if (!isWebRequest)
                    {
                        throw new Exception("Acceso denegado Peticion Incorrecta !!!");                        
                    }
                    else
                    {                       
                        /* VALIDACION ACCESO USUARIO */
                        /* INICIO */
                        Boolean Flag = false;
                        using SqlConnection conn = new SqlConnection(ConnectionString);
                        conn.Open();
                        using SqlCommand cmd = new SqlCommand("SP_VAL_USUARIO_SERVICIOS", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };
                        cmd.Parameters.AddWithValue("Usuario", _usuario);
                        cmd.Parameters.AddWithValue("Token", _token);                        

                        using SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int Res = 0;

                            if (reader["Res"] != DBNull.Value && Int32.TryParse(reader["Res"].ToString(), out Res)) {
                                if (Res > 0)
                                {
                                    Flag = true;
                                }
                                else
                                {
                                    Flag = false;
                                }
                            }                            
                        }

                        conn.Close();

                        if (!Flag) { 
                            throw new Exception("Acceso denegado Usuario y/o Token Incorrecto !!!");
                        }
                        int auditUserId = 1;
                        if (!string.IsNullOrWhiteSpace(_usuario) && int.TryParse(_usuario, out var parsedId))
                        {
                            auditUserId = parsedId;
                        }

                        /* FIN */
                        String rpta = "";
                        using SqlConnection conn_ = new SqlConnection(ConnectionString);
                        conn_.Open();
                        using SqlCommand cmd_ = new SqlCommand("SP_INS_AuditRequest", conn_)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };
                        cmd_.Parameters.AddWithValue("IpSolicitud", ipConn);
                        cmd_.Parameters.AddWithValue("Metodo", method + "  ||  " + path + " || " + queryString);
                        cmd_.Parameters.AddWithValue("ParamHeader", "Peticion Ext Landing Web");
                        cmd_.Parameters.AddWithValue("ParamJson", "");
                        cmd_.Parameters.AddWithValue("FechaHoraSolicitud", DateTime.Now);
                        cmd_.Parameters.AddWithValue("Usuario", auditUserId);
                        cmd_.Parameters.AddWithValue("Accion", "Petición Correcta");
                        cmd_.Parameters.AddWithValue("LugarConexion", userAgent);

                        if (cmd_.ExecuteNonQuery() > 0)
                        {
                            rpta = "Registro con exito";
                        }

                        conn_.Close();
                    }
                }
                else
                {
                    throw new Exception("Acceso denegado Metodo Incorrecto !!!");
                }
            }
            catch(Exception ex) {

                String rpta = "";

                using SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                using SqlCommand cmd = new SqlCommand("SP_INS_AuditRequest", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IpSolicitud", ipConn);
                cmd.Parameters.AddWithValue("Metodo", method + "  ||  " + path + " || " + queryString);
                cmd.Parameters.AddWithValue("ParamHeader", "Peticion Interna");
                cmd.Parameters.AddWithValue("ParamJson", "");
                cmd.Parameters.AddWithValue("FechaHoraSolicitud", DateTime.Now);
                cmd.Parameters.AddWithValue("Usuario", 1);
                cmd.Parameters.AddWithValue("Accion", ex.Message);
                cmd.Parameters.AddWithValue("LugarConexion", userAgent);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    rpta = "Registro con exito";
                }

                conn.Close();

                context.Result = new JsonResult(new { message = ex.Message })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
                return;
            }
        }
    }
}
