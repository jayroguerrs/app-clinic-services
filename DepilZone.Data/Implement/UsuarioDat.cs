using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace DepilZone.Data
{
    public class UsuarioDat: IUsuarioDat
    {
        private readonly string _connectionString;

        private static readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        private const int MAX_INTENTOS = 3;
        private const int BLOQUEO_MINUTOS = 3;

        public UsuarioDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<UsuarioGridDTO>> Obtener(bool idEstado)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdEstado", idEstado);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsObtener(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerListadoGrilla()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerListadoGrilla", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsObtener(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<SupervisorDTO>> ObtenerListadoSupervisores()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ObtenerUsuariosConPrivilegios", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsObtenerSupervisores(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerListadoGrillaBySupervisor(int idSupervisor)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerListadoBySupervisor", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("idSupervisor", idSupervisor);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsObtener(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GeneralResponse<RespuestaConfirmarSupervisorDTO>> ConfirmarSupervisor(int idUsuario, string usuarioSupervisor)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ConfirmarSupervisor", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("usuarioSupervisor", usuarioSupervisor);


                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadConfirmarSupervisor(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GeneralResponse<bool>> CambiarEstadoAprobacion(int IdUsuario, byte EstadoUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_Aprobar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("idUsuario", IdUsuario);
                cmd.Parameters.AddWithValue("aprobado", EstadoUsuario);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadAprobarUsuario(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<byte> ObtenerEstadoAprobacionUsuario(int IdUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ObtenerUsuarioEstadoAprobado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("idUsuario", IdUsuario);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerEstadoAprobado(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<AccesoUsuarioDTO> ObtenerEstadoPrivilegioUsuario(int IdUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ObtenerUsuarioEstadoPrivilegio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("idUsuario", IdUsuario);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerEstadoPrivilegio(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<UsuarioEnt> ObtenerByIdUsuario(Int32 IdUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", IdUsuario);
                cmd.Parameters.AddWithValue("pParametro", DBConn.ParametroCripto());
                var reader = await cmd.ExecuteReaderAsync();
                var output = await Read(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByIdPerfil(string idPerfil, int idSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerByIdPerfil", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                if (idPerfil == "0") idPerfil = "";

                cmd.Parameters.AddWithValue("IdPerfil", idPerfil);
                cmd.Parameters.AddWithValue("IdSede", idSede);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsByPerfil(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByIdPerfilUsuario(int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerByIdPerfil2", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };                

                cmd.Parameters.AddWithValue("IdUsuario", idUsuario);                
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsByPerfil(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerParaCita()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerParaCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerParaCita(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerResponsableCaja()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerResponsableCaja", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsByPerfil(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByLikeNombre(string Nombre)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerByLikeNombre", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Nombre", Nombre);
                var reader = await cmd.ExecuteReaderAsync();
                UsuarioGridDTO obj = null;
                IList<UsuarioGridDTO> lista = new List<UsuarioGridDTO>();
                while (await reader.ReadAsync())
                {
                    obj = new UsuarioGridDTO
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nombre = reader["Nombre"].ToString(),
                        Usuario = reader["Usuario"].ToString(),
                        Clave = reader["Clave"].ToString(),
                        IdPerfil = Convert.ToInt32(reader["IdPerfil"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        Perfil = reader["Perfil"].ToString(),
                        Sede = reader["Sede"].ToString(),
                        UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]).ToString("dd-MM-yyyy")
                    };
                    lista.Add(obj);
                }


                conn.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> ObtenerClaveUsuario(int id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("VERClave", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", id);
                var reader = await cmd.ExecuteReaderAsync();

                string clave = "";
                while (await reader.ReadAsync())
                {
                    clave = reader["Clave"] == DBNull.Value? "" : reader["Clave"].ToString();
                }


                conn.Close();

                return clave;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioActualizarDatosDTO> ActualizarDatos(UsuarioActualizarDatosDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ActualizarDatos", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("pDni", model.Dni);
                cmd.Parameters.AddWithValue("pNombre", model.Nombres);
                cmd.Parameters.AddWithValue("FechaNacimiento", model.FechaNacimiento);
                cmd.Parameters.AddWithValue("Celular", model.Celular);
                cmd.Parameters.AddWithValue("pCorreo", model.Correo);
                cmd.Parameters.AddWithValue("pClaveNueva", model.NuevaClave);

                cmd.Parameters.AddWithValue("pColorSidebarDeFondo", model.ColorSidebarDeFondo);
                cmd.Parameters.AddWithValue("pColorSidebarDeTexto", model.ColorSidebarDeTexto);
                cmd.Parameters.AddWithValue("pImagenFondo", model.ImagenFondo);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemUpdateData(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<PersonalizarClinicDTO> PerzonalizarClinic(PersonalizarClinicDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Perzonalizar_Clinic", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);

                cmd.Parameters.AddWithValue("pColorSidebarDeFondo", model.ColorSidebarDeFondo);
                cmd.Parameters.AddWithValue("pColorSidebarDeTexto", model.ColorSidebarDeTexto);
                cmd.Parameters.AddWithValue("pImagenFondo", model.ImagenFondo);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemPersonalizarCLinic(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public async Task<Respuesta<UsuarioEnt>> Insertar(UsuarioEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pUsuario", model.Usuario);
                cmd.Parameters.AddWithValue("pClave", model.Clave);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdPerfil", model.IdPerfil);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pFoto", model.Foto);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pParametro", DBConn.ParametroCripto());
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItem(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Respuesta<UsuarioEnt>> Modificar(UsuarioEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pUsuario", model.Usuario);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdPerfil", model.IdPerfil);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pFoto", model.Foto);
                cmd.Parameters.AddWithValue("pUsuarioEdita", model.UsuarioEdita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItem(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Respuesta<UsuarioCambiarClaveDTO>> CambiarClave(UsuarioCambiarClaveDTO model)
        {
            try
            {
                var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");

                if (!regex.IsMatch(model.ClaveNueva))
                {
                    throw new Exception("La nueva contraseña no cumple con los requisitos de seguridad: mínimo 8 caracteres, incluir mayúscula, minúscula, número y un carácter especial.");
                }

                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_CambiarClave", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("pClaveActual", model.ClaveActual);
                cmd.Parameters.AddWithValue("pClaveNueva", model.ClaveNueva);
                cmd.Parameters.AddWithValue("pParametro", DBConn.ParametroCripto());
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemCambiarClave(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Respuesta<LoginDTO>> Login(LoginDTO model)
        {
            try
            {
                //var usuario = model.Usuario.ToLower();

                var secretKey = "x6dXs49$z@vQpR7!kLm*WnTyEa5";
                var saltBase64 = "u8mV3jvYgkX5+2sQ0YkX9w==";
                string decryptedPassword = string.Empty;
                string decryptedUser = string.Empty;

                decryptedUser = DecryptAesGcmFromBase64(model.Usuario, secretKey, saltBase64);
                decryptedPassword = DecryptAesGcmFromBase64(model.Password, secretKey, saltBase64);

                var usuario = decryptedUser.ToLower();

                // 🔍 Verificar si está bloqueado completamente
                if (_cache.TryGetValue($"bloqueado_{usuario}", out _))
                {
                    throw new Exception("Demasiados intentos fallidos. Espere unos minutos antes de volver a intentar.");
                }

                // 🔍 Verificar si ya tiene 3 intentos -> pedir Turnstile
                if (_cache.TryGetValue($"intentos_{usuario}", out int intentos) && intentos >= MAX_INTENTOS)
                {
                    var captchaValido = await ValidarTurnstileAsync(model.CaptchaToken);

                    if (!captchaValido)
                    {
                        throw new Exception("Captcha inválido o expirado. Inténtalo nuevamente.");
                    }
                }

                bool tieneDatosActualizados = await VerificarUsuarioNuevo(decryptedUser);

                if (tieneDatosActualizados)
                {
                    var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");

                    if (!regex.IsMatch(decryptedPassword))
                    {
                        throw new Exception("La contraseña no cumple con los requisitos de seguridad: mínimo 8 caracteres, incluir mayúscula, minúscula, número y un carácter especial.");
                    }
                }

                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Login", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pUsuario", decryptedUser);
                cmd.Parameters.AddWithValue("pClave", decryptedPassword);
                cmd.Parameters.AddWithValue("pParametro", DBConn.ParametroCripto());
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadLogin(reader);

                conn.Close();

                if (output.Exito != false)
                {
                    _cache.Remove($"intentos_{usuario}");
                }
                else
                {
                    IncrementarIntento(usuario);
                }

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Deriva una key AES-256 con PBKDF2 (Rfc2898) — mismas params que el front
        public static byte[] DeriveAesKey(string secret, string saltBase64, int iterations = 100000)
        {
            var salt = Convert.FromBase64String(saltBase64);
            using (var kdf = new Rfc2898DeriveBytes(secret, salt, iterations, HashAlgorithmName.SHA256))
            {
                return kdf.GetBytes(32); // 256 bits
            }
        }

        // Input: base64 string con iv (12 bytes) + cipherWithTag
        public static string DecryptAesGcmFromBase64(string base64IvCipher, string secret, string saltBase64, int iterations = 100000)
        {
            var combined = Convert.FromBase64String(base64IvCipher);

            // iv de 12 bytes
            const int ivLength = 12;
            const int tagLength = 16; // AES-GCM tag 128 bits

            if (combined.Length < ivLength + tagLength)
                throw new ArgumentException("El payload es demasiado corto para AES-GCM");

            var iv = new byte[ivLength];
            Array.Copy(combined, 0, iv, 0, ivLength);

            var cipherWithTag = new byte[combined.Length - ivLength];
            Array.Copy(combined, ivLength, cipherWithTag, 0, cipherWithTag.Length);

            // separar cipher y tag
            var tag = new byte[tagLength];
            var cipher = new byte[cipherWithTag.Length - tagLength];
            Array.Copy(cipherWithTag, cipherWithTag.Length - tagLength, tag, 0, tagLength);
            Array.Copy(cipherWithTag, 0, cipher, 0, cipher.Length);

            var key = DeriveAesKey(secret, saltBase64, iterations);

            // Decrypt
            var plaintext = new byte[cipher.Length];
            try
            {
                using (var aes = new AesGcm(key))
                {
                    aes.Decrypt(iv, cipher, tag, plaintext, null);
                }
            }
            catch (CryptographicException ex)
            {
                throw new Exception("Fallo en desencriptar, datos inválidos o clave incorrecta.", ex);
            }

            return Encoding.UTF8.GetString(plaintext);
        }

        public async Task<bool> VerificarUsuarioNuevo(string usuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_EsUsuarioNuevo", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pUsuario", usuario);
                var reader = cmd.ExecuteReader();

                bool esUsuarioNuevo = false;

                while (reader.Read())
                {
                   esUsuarioNuevo = Convert.ToBoolean(reader["DatosActualizados"]);
                }

                conn.Close();
                return esUsuarioNuevo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IncrementarIntento(string usuario)
        {
            string keyIntentos = $"intentos_{usuario}";

            if (!_cache.TryGetValue(keyIntentos, out int intentos))
                intentos = 0;

            intentos++;

            _cache.Set(keyIntentos, intentos, TimeSpan.FromMinutes(BLOQUEO_MINUTOS));

            // ⚠️ Bloquear solo a partir del cuarto intento
            if (intentos > MAX_INTENTOS) // es decir, 4 o más
            {
                _cache.Set($"bloqueado_{usuario}", true, TimeSpan.FromMinutes(BLOQUEO_MINUTOS));
                _cache.Remove(keyIntentos);
            }
        }

        public async Task<bool> ValidarTurnstileAsync(string token)
        {
            const string secretKey = "0x4AAAAAAB4MQCR-2kJH9UPGXvUZ_mdRdRk";

            using var client = new HttpClient();
            var response = await client.PostAsync(
                "https://challenges.cloudflare.com/turnstile/v0/siteverify",
                new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "secret", secretKey },
                    { "response", token }
                }));

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

            return data != null
                   && data.ContainsKey("success")
                   && ((JsonElement)data["success"]).GetBoolean();
        }


        public async Task<IList<MenuDTO>> ObtenerMenuConPrivilegios()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Menu_ObtenerConPrivilegios", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerMenuConPrivilegios(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<MenuRutaDetDTO>> MenuUsuario(LoginDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MenuUsuario", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pUsuario", model.Usuario);                
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadRutaMenu(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public async Task<List<MenuDTO>> ObtenerMenuByPerfil(int idPerfil)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerMenuByPerfil", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPerfil", idPerfil);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerMenuByPerfil(reader);

                conn.Close();

                return output.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UsuarioGridDTO>> ListarParaPreferentes()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerByPreferentes", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                UsuarioGridDTO obj = null;
                List<UsuarioGridDTO> lista = new List<UsuarioGridDTO>();
                while (await reader.ReadAsync())
                {
                    obj = new UsuarioGridDTO
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nombre = reader["Nombre"].ToString(),
                        Usuario = reader["Usuario"].ToString(),
                    };
                    lista.Add(obj);
                }


                conn.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<EmpleadoDTO>> ListarParaPreferentesPorUsuario(int idPerfil)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerPreferentes_ByUsu", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Asumiendo que idPerfil es un parámetro que necesitas enviar al SP
                cmd.Parameters.AddWithValue("@vi_IdUsuario", idPerfil);

                var reader = await cmd.ExecuteReaderAsync();
                List<EmpleadoDTO> lista = new List<EmpleadoDTO>();

                while (await reader.ReadAsync())
                {
                    var obj = new EmpleadoDTO
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nombre = reader["Nombre"].ToString(),
                        Usuario = reader["Usuario"].ToString(),
                    };
                    lista.Add(obj);
                }

                conn.Close();
                return lista;
            }
            catch (SqlException sqlEx)
            {
                // Manejo específico de errores de SQL Server
                var message = $"Error en la base de datos: {sqlEx.Message}";

                // Aquí podrías registrar el error (en un archivo de logs, por ejemplo)
                // Logger.LogError(sqlEx, "Error ejecutando SP_Usuario_ObtenerPreferentes_ByUsu");

                // Lanza una excepción más amigable si es necesario
                throw new Exception(message, sqlEx);
            }
            catch (Exception ex)
            {
                // Manejo general de otros errores no relacionados a SQL Server
                var message = $"Ocurrió un error: {ex.Message}";

                // Podrías registrar este error también
                // Logger.LogError(ex, "Error en ListarParaPreferentesPorUsuario");

                throw new Exception(message, ex);
            }
        }



        public async Task<List<ShortUser>> CollectionByEstado(int idEstado)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_CollectionByEstado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdEstado", idEstado);
                var reader = await cmd.ExecuteReaderAsync();
                List<ShortUser> lista = new List<ShortUser>();
                while (await reader.ReadAsync())
                {
                    var obj = new ShortUser
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString()
                    };
                    lista.Add(obj);
                }


                conn.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<string> ObtenerClave(int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerClave", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                var reader = await cmd.ExecuteReaderAsync();

                bool Exito = false;
                string clave = "";
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;


                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);

                    }
                    clave = Convert.ToString(reader["Clave"]);
                }


                conn.Close();

                return clave;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public async Task<bool> CambiarClave(int idUsuario, string clave)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_CambiarClave2", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pClave", clave);
                cmd.Parameters.AddWithValue("pParametro", DBConn.ParametroCripto());
                var reader = await cmd.ExecuteReaderAsync();

                bool Exito = false;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;


                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);

                    }
                }

                conn.Close();

                return Exito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // READERS

        static async Task<Respuesta<UsuarioCambiarClaveDTO>> ReadItemCambiarClave(DbDataReader reader)
        {
            try
            {
                Respuesta<UsuarioCambiarClaveDTO> obj = new Respuesta<UsuarioCambiarClaveDTO>
                {
                    Response = new UsuarioCambiarClaveDTO()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    if (obj.Exito)
                    {
                        obj.Response.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<UsuarioEnt> Read(DbDataReader reader)
        {
            try
            {
                UsuarioEnt obj = new UsuarioEnt();
                while (await reader.ReadAsync())
                {
                    obj.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"]);
                    obj.Usuario = Convert.ToString(reader["Usuario"]);
                    obj.Clave = Convert.ToString(reader["Clave"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.IdPerfil = Convert.ToInt32(reader["IdPerfil"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]);
                    obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    obj.Foto = reader["Foto"].ToString();
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<PersonalizarClinicDTO> ReadItemPersonalizarCLinic(DbDataReader reader)
        {
            try
            {
                PersonalizarClinicDTO obj = new PersonalizarClinicDTO();

                while (await reader.ReadAsync())
                {
                    obj.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    obj.ColorSidebarDeFondo = reader["ColorSidebarDeFondo"] != DBNull.Value ? reader["ColorSidebarDeFondo"].ToString() : null;
                    obj.ColorSidebarDeTexto = reader["ColorSidebarDeTexto"] != DBNull.Value ? reader["ColorSidebarDeTexto"].ToString() : null;
                    obj.ImagenFondo = reader["ImagenDeFondo"] != DBNull.Value ? reader["ImagenDeFondo"].ToString() : null;
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<UsuarioActualizarDatosDTO> ReadItemUpdateData(DbDataReader reader)
        {
            try
            {
                UsuarioActualizarDatosDTO obj = new UsuarioActualizarDatosDTO();

                while (await reader.ReadAsync())
                {
                    obj.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    obj.Dni = Convert.ToString(reader["DNI"]);
                    obj.Nombres = Convert.ToString(reader["Nombre"]);
                    obj.Celular = Convert.ToString(reader["NumeroCelular"]);
                    obj.Correo = Convert.ToString(reader["CorreoElectronico"]);
                    obj.FechaNacimiento = Convert.ToDateTime(reader["FechaDeNacimiento"]).ToString("dd-MM-yyyy");
                    obj.ColorSidebarDeFondo = reader["ColorSidebarDeFondo"] != DBNull.Value ? reader["ColorSidebarDeFondo"].ToString() : null;
                    obj.ColorSidebarDeTexto = reader["ColorSidebarDeTexto"] != DBNull.Value ? reader["ColorSidebarDeTexto"].ToString() : null;
                    obj.ImagenFondo = reader["ImagenDeFondo"] != DBNull.Value ? reader["ImagenDeFondo"].ToString() : null;
                    obj.DatosActualizados = Convert.ToBoolean(reader["DatosActualizados"]);
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<Respuesta<UsuarioEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<UsuarioEnt> obj = new Respuesta<UsuarioEnt>
                {
                    Response = new UsuarioEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    if (obj.Exito)
                    {
                        obj.Response.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        obj.Response.Nombre = Convert.ToString(reader["Nombre"]);
                        obj.Response.Usuario = Convert.ToString(reader["Usuario"]);
                        obj.Response.Clave = Convert.ToString(reader["Clave"]);
                        obj.Response.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.Response.IdPerfil = Convert.ToInt32(reader["IdPerfil"]);
                        obj.Response.IdSede = Convert.ToInt32(reader["IdSede"]);
                        obj.Response.Foto = reader["Foto"] != DBNull.Value ? reader["Foto"].ToString() : null;
                        obj.Response.UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]);
                        obj.Response.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Respuesta<LoginDTO>> ReadLogin(DbDataReader reader)
        {
            try
            {
                Respuesta<LoginDTO> obj = new Respuesta<LoginDTO>
                {
                    Response = new LoginDTO()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    if (obj.Exito)
                    {
                        obj.Response.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        obj.Response.Nombre = Convert.ToString(reader["Nombre"]);
                        obj.Response.Usuario = Convert.ToString(reader["Usuario"]);                        
                        obj.Response.Perfil = Convert.ToString(reader["Perfil"]);
                        obj.Response.IdPerfil = Convert.ToInt32(reader["IdPerfil"]);
                        obj.Response.Foto = reader["Foto"].ToString();
                        obj.Response.IdSede = Convert.ToInt32(reader["idSede"]);
                        obj.Response.Sede = reader["Sede"].ToString();
                        obj.Response.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);

                        obj.Response.ColorSidebarDeFondo = reader["ColorSidebarDeFondo"] != DBNull.Value ? reader["ColorSidebarDeFondo"].ToString() : null;
                        obj.Response.ColorSidebarDeTexto = reader["ColorSidebarDeTexto"] != DBNull.Value ? reader["ColorSidebarDeTexto"].ToString() : null;
                        obj.Response.ImagenDeFondo = reader["ImagenDeFondo"] != DBNull.Value ? reader["ImagenDeFondo"].ToString() : null;

                        obj.Response.DatosActualizados = Convert.ToBoolean(reader["DatosActualizados"]);
                        obj.Response.Privilegio = Convert.ToInt32(reader["Privilegio"]);
                        obj.Response.Aprobado = Convert.ToInt32(reader["Aprobado"]);
                        obj.Response.IdSupervisor = reader["IdSupervisor"] != DBNull.Value ? Convert.ToInt32(reader["IdSupervisor"]) : 0;


                        var menuJson = Convert.ToString(reader["Menu"]);

                        object menuUsuario = JsonSerializer.Deserialize<object>(menuJson);
                        obj.Response.MenuUsuario = menuUsuario;
                    }
                }

                //Leer el menu
                List<MenuDTO> listaMenu = new List<MenuDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        MenuDTO menu = new MenuDTO()
                        {
                            IdMenu = Convert.ToInt32(reader["IdMenu"]),
                            IdPadre = reader["IdPadre"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPadre"]),
                            Title = reader["Title"].ToString(),
                            IdMenuTipo = reader["IdMenuTipo"].ToString(),
                            Icon = reader["Icon"] == DBNull.Value ? "" : reader["Icon"].ToString(),
                            Url = reader["Url"].ToString(),
                            Id = reader["Id"].ToString(),
                            Visible = Convert.ToBoolean(reader["Visible"]),
                            Nivel = Convert.ToInt32(reader["Nivel"]),
                            Type = reader["Type"].ToString()
                        };
                        listaMenu.Add(menu);
                    }                    
                }

                if (obj.Response.Privilegio > 0)
                {
                    IList<MenuDTO> menuPrivilegio = await ObtenerMenuConPrivilegios();
                    var privilegio = obj.Response.Privilegio;

                    var idsExistentes = new HashSet<int>(listaMenu.Select(m => m.IdMenu));

                    var filtrados = menuPrivilegio
                        .Where(m => m.Privilegios?.Contains(privilegio) == true && !idsExistentes.Contains(m.IdMenu))
                        .ToList();

                    listaMenu.AddRange(filtrados);
                }



                IList<MenuDTO> resultado = OrdenarMenuPadreHijos(listaMenu, null);
                obj.Response.Menu = resultado;

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        static async Task<List<MenuRutaDetDTO>> ReadRutaMenu(DbDataReader reader)
        {
            try
            {                                
                List<MenuRutaDetDTO> listaMenuRuta = new List<MenuRutaDetDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        MenuRutaDetDTO menuRuta = new MenuRutaDetDTO()
                        {
                            IdMenu = Convert.ToInt32(reader["IdMenu"]),
                            Proceso = reader["Proceso"].ToString(),                            
                            Metodo = reader["Metodo"].ToString(),
                            Estado = reader["Estado"].ToString()
                        };
                        listaMenuRuta.Add(menuRuta);
                    }
                }                

                return listaMenuRuta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IList<MenuDTO>> ReadObtenerMenuConPrivilegios(DbDataReader reader)
        {
            try
            {
                //Leer el menu
                List<MenuDTO> listaMenu = new List<MenuDTO>();

                while (await reader.ReadAsync())
                {
                    MenuDTO menu = new MenuDTO()
                    {
                        IdMenu = Convert.ToInt32(reader["IdMenu"]),
                        IdPadre = reader["IdPadre"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPadre"]),
                        Title = reader["Title"].ToString(),
                        IdMenuTipo = reader["IdMenuTipo"].ToString(),
                        Icon = reader["Icon"] == DBNull.Value ? "" : reader["Icon"].ToString(),
                        Url = reader["Url"].ToString(),
                        Id = reader["Id"].ToString(),
                        Visible = Convert.ToBoolean(reader["Visible"]),
                        Nivel = Convert.ToInt32(reader["Nivel"]),
                        Type = reader["Type"].ToString(),
                        Privilegios = reader["Privilegios"] == DBNull.Value ? new List<int>() : JsonSerializer.Deserialize<List<int>>(reader["Privilegios"].ToString())
                    };
                    listaMenu.Add(menu);
                }

                return listaMenu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IList<MenuDTO>> ReadObtenerMenuByPerfil(DbDataReader reader)
        {
            try
            {               
                //Leer el menu
                List<MenuDTO> listaMenu = new List<MenuDTO>();
               
                while (await reader.ReadAsync())
                {
                    MenuDTO menu = new MenuDTO()
                    {
                        IdMenu = Convert.ToInt32(reader["IdMenu"]),
                        IdPadre = reader["IdPadre"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPadre"]),
                        Title = reader["Title"].ToString(),
                        IdMenuTipo = reader["IdMenuTipo"].ToString(),
                        Icon = reader["Icon"] == DBNull.Value ? "" : reader["Icon"].ToString(),
                        Url = reader["Url"].ToString(),
                        Id = reader["Id"].ToString(),
                        Visible = Convert.ToBoolean(reader["Visible"]),
                        Nivel = Convert.ToInt32(reader["Nivel"]),
                        Type = reader["Type"].ToString()
                    };
                    listaMenu.Add(menu);
                }

                List<MenuRutaDetDTO> listaMenuRuta = new List<MenuRutaDetDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        MenuRutaDetDTO menuRuta = new MenuRutaDetDTO()
                        {
                            IdMenu = Convert.ToInt32(reader["IdMenu"]),
                            Proceso = reader["Proceso"].ToString(),                            
                            Metodo = reader["Metodo"].ToString(),
                            Estado = reader["Estado"].ToString()
                        };
                        listaMenuRuta.Add(menuRuta);
                    }
                }

                IList<MenuDTO> resultado = OrdenarMenuPadreHijos(listaMenu, null);
              
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static IList<MenuDTO> OrdenarMenuPadreHijos(List<MenuDTO> Menus, int? IdPadre)
        {
            try
            {
                List<MenuDTO> MenuResultado = new List<MenuDTO>();

                //obtener los datos del nivel indicado
                List<MenuDTO> menuNivel = Menus.Where(x => x.IdPadre == IdPadre).ToList();
                
                foreach (MenuDTO menu in menuNivel)
                {
                    // Obtener Rutas por Menu
                    //List<MenuRutaDet> menuRuta = MenuRutas.Where(x => x.IdMenu == Convert.ToInt32(menu.IdMenu)).ToList();

                    MenuDTO menuDto = new MenuDTO
                    {
                        Id = menu.Id,
                        Title = menu.Title,
                        IdPadre = menu.IdPadre,
                        Type = menu.Type,
                        Url = menu.Url,
                        Icon = menu.Icon,
                        IdMenu = menu.IdMenu,
                        Visible = menu.Visible,                        
                        Children = OrdenarMenuPadreHijos(Menus, menu.IdMenu),                        
                    };
                    MenuResultado.Add(menuDto);
                }

                return MenuResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<IEnumerable<UsuarioGridDTO>> ReadItemsByPerfil(DbDataReader reader)
        {
            try
            {
                IList<UsuarioGridDTO> lista = new List<UsuarioGridDTO>();
                while (await reader.ReadAsync())
                {
                    UsuarioGridDTO obj = new UsuarioGridDTO
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nombre = reader["Nombre"].ToString(),
                        Usuario = reader["Usuario"].ToString(),
                        Clave = reader["Clave"].ToString(),
                        IdPerfil = Convert.ToInt32(reader["IdPerfil"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        Perfil = reader["Perfil"].ToString(),
                        UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]).ToString("dd-MM-yyyy"),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        Sede = reader["Sede"].ToString(),
                        Foto = reader["Foto"].ToString()
                    };
                    lista.Add(obj);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<IEnumerable<UsuarioGridDTO>> ReadObtenerParaCita(DbDataReader reader)
        {
            try
            {
                IList<UsuarioGridDTO> lista = new List<UsuarioGridDTO>();
                while (await reader.ReadAsync())
                {
                    UsuarioGridDTO obj = new UsuarioGridDTO
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nombre = reader["Nombre"].ToString(),
                        Usuario = reader["Usuario"].ToString(),
                        Clave = reader["Clave"].ToString(),
                        IdPerfil = Convert.ToInt32(reader["IdPerfil"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        Perfil = reader["Perfil"].ToString(),
                        UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]).ToString("dd-MM-yyyy"),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        Sede = reader["Sede"].ToString(),
                        Foto = reader["Foto"].ToString()
                    };
                    lista.Add(obj);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GeneralResponse<RespuestaConfirmarSupervisorDTO>> ReadConfirmarSupervisor(DbDataReader reader)
        {
            try
            {
                GeneralResponse<RespuestaConfirmarSupervisorDTO> generalRes = new GeneralResponse<RespuestaConfirmarSupervisorDTO>
                {
                    Data = new RespuestaConfirmarSupervisorDTO()
                };


                if (await reader.ReadAsync())
                {
                    generalRes.Message = "Solicitud enviada a supervisión exitosamente.";
                    generalRes.Status = 200;

                    generalRes.Data.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    generalRes.Data.IdSupervisor = Convert.ToInt32(reader["IdSupervisor"]);
                    generalRes.Data.Nombre = Convert.ToString(reader["Nombre"]);
                }

                return generalRes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GeneralResponse<bool>> ReadAprobarUsuario(DbDataReader reader)
        {
            try
            {
                GeneralResponse<bool> generalRes = new GeneralResponse<bool>
                {
                    Data = false
                };


                if (await reader.ReadAsync())
                {
                    generalRes.Message = "Solicitud enviada a supervisión exitosamente.";
                    generalRes.Status = 200;

                    generalRes.Data = true;
                }

                return generalRes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<byte> ReadObtenerEstadoAprobado(DbDataReader reader)
        {
            try
            {
                if (await reader.ReadAsync())
                {
                    return Convert.ToByte(reader["Aprobado"]);
                }

                return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<AccesoUsuarioDTO> ReadObtenerEstadoPrivilegio(DbDataReader reader)
        {
            try
            {
                AccesoUsuarioDTO resp = new AccesoUsuarioDTO();

                if (await reader.ReadAsync())
                {
                    resp.Privilegio = Convert.ToByte(reader["Privilegio"]);
                    resp.EstadoAprobacion = Convert.ToByte(reader["Aprobado"]);

                    //return Convert.ToByte(reader["Privilegio"]);
                }

                return resp;

                //return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<IEnumerable<UsuarioGridDTO>> ReadItemsObtener(DbDataReader reader)
        {
            try
            {
                IList<UsuarioGridDTO> lista = new List<UsuarioGridDTO>();
                while (await reader.ReadAsync())
                {
                    UsuarioGridDTO obj = new UsuarioGridDTO
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nombre = reader["Nombre"].ToString(),
                        Usuario = reader["Usuario"].ToString(),
                        Clave = reader["Clave"].ToString(),
                        IdPerfil = Convert.ToInt32(reader["IdPerfil"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        Perfil = reader["Perfil"].ToString(),
                        UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]).ToString("dd-MM-yyyy"),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        Sede = reader["Sede"].ToString(),
                    };
                    lista.Add(obj);
                }
                
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IEnumerable<SupervisorDTO>> ReadItemsObtenerSupervisores(DbDataReader reader)
        {
            try
            {
                IList<SupervisorDTO> lista = new List<SupervisorDTO>();
                while (await reader.ReadAsync())
                {
                    SupervisorDTO obj = new SupervisorDTO
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nombre = reader["Nombre"].ToString(),
                        Usuario = reader["Usuario"].ToString(),
                    };
                    lista.Add(obj);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
