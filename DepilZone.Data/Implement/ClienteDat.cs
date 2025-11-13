using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data
{
    public class ClienteDat : IClienteDat
    {

        private readonly string _connectionString;

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        private readonly configEnt _config;
        public ClienteDat(configEnt ConfigAppsetting, string connectionString) {
            _config = ConfigAppsetting;
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<ClienteGridDTO>> Obtener(int top)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cliente_Obtener", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pTopMax", top);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public async Task<ClienteDTO> ObtenerById(int Id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cliente_ObtenerById", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", Id);
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
        public async Task<ClienteDTO> ObtenerPerfilById(int Id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cliente_ObtenerPerfilById", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", Id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadPerfil(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<IEnumerable<ClienteZonaCorporalHistoricoDTO>> ObtenerTodasLasZonasCorporales(int Id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cliente_ObtenerZonaCorporalHistorica", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", Id);
                var reader = await cmd.ExecuteReaderAsync();

                IList<ClienteZonaCorporalHistoricoDTO> lista = new List<ClienteZonaCorporalHistoricoDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteZonaCorporalHistoricoDTO item = new ClienteZonaCorporalHistoricoDTO()
                    {
                        IdZonaCorporal = Convert.ToInt32(reader["IdZona"]),
                        NumCitasPorZona = Convert.ToInt32(reader["Citas"]),
                        ZonaCorporal = reader["Descripcion"].ToString()
                    };
                    lista.Add(item);
                }


                conn.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> VerificarClientePorDni(string documento)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cliente_VerificarPorDocumento", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pDocumento", documento);
                var reader = await cmd.ExecuteReaderAsync();

                bool result = false;
                while (await reader.ReadAsync())
                {
                    result = Convert.ToBoolean(reader["total"]);
                }


                conn.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<ClienteZonaCorporalHistoricoDTO>> ObtenerTodasLasZonasCorporalesPorServicio(int IdCliente, int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cliente_ObtenerZonaCorporalHistoricaPorServicio", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", IdCliente);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();

                IList<ClienteZonaCorporalHistoricoDTO> lista = new List<ClienteZonaCorporalHistoricoDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteZonaCorporalHistoricoDTO item = new ClienteZonaCorporalHistoricoDTO()
                    {
                        IdZonaCorporal = Convert.ToInt32(reader["IdZona"]),
                        NumCitasPorZona = Convert.ToInt32(reader["Citas"]),
                        ZonaCorporal = reader["Descripcion"].ToString()
                    };
                    lista.Add(item);
                }


                conn.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ClienteEnt> ObtenerFirmaById(int Id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cliente_ObtenerFirmaById", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                cmd.Parameters.AddWithValue("Id", Id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadFirma(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<ClienteDatosMaestrosDTO> ObtenerDatosMaestros()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cliente_ObtenerDatosMaestros", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadDatosMaestros(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<ClienteEnt>> Insertar(ClienteEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cliente_Insertar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Nombres", model.Nombres.ToUpper());
                cmd.Parameters.AddWithValue("Apellidos", model.Apellidos.ToUpper());
                cmd.Parameters.AddWithValue("Seudonimo", model.Seudonimo.ToUpper());
                cmd.Parameters.AddWithValue("IdGenero", model.IdGenero);
                cmd.Parameters.AddWithValue("Celular1", model.Celular1);
                cmd.Parameters.AddWithValue("PaisCelular1", model.PaisCelular1);
                cmd.Parameters.AddWithValue("Celular2", model.Celular2);
                cmd.Parameters.AddWithValue("PaisCelular2", model.PaisCelular2);
                cmd.Parameters.AddWithValue("Correo", model.Correo);
                cmd.Parameters.AddWithValue("IdUbicacion", model.IdUbicacion);
                cmd.Parameters.AddWithValue("Direccion", model.Direccion);
                cmd.Parameters.AddWithValue("Publicidad", model.Publicidad);
                cmd.Parameters.AddWithValue("FechaNacimiento", model.FechaNacimiento);
                cmd.Parameters.AddWithValue("UsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("SerieFirma", model.SerieFirma);
                cmd.Parameters.AddWithValue("SerieHuella", model.SerieHuella);
                cmd.Parameters.AddWithValue("IdDocumentoIdentidadTipo", model.IdDocumentoIdentidadTipo);
                cmd.Parameters.AddWithValue("Documento", model.Documento);
                cmd.Parameters.AddWithValue("IdMedioContacto", model.IdMedioContacto);
                cmd.Parameters.AddWithValue("OtroMedioContacto", model.OtroMedioContacto);
                cmd.Parameters.AddWithValue("Foto", model.Foto);
                cmd.Parameters.AddWithValue("IdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("IdHistoriaClinica", model.IdHistoriaClinica);
                cmd.Parameters.AddWithValue("IdPreferente", model.IdPreferente);
                cmd.Parameters.AddWithValue("IdEspecialista", model.IdEspecialista);
                cmd.Parameters.AddWithValue("ruc", model.ruc);
                cmd.Parameters.AddWithValue("razonSocial", model.razonSocial);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadInsertar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<IEnumerable<ClienteGridDTO>> ObtenerByLikeNombre(string Nombre)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cliente_ObtenerByLikeNombre", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pCadenaFiltro", Nombre);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                
                throw EX;
            }
        }
        public async Task<IEnumerable<ClienteGridDTO>> ObtenerPorPreferente(string Nombres, string Apellidos, string Numeros, string Email)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cliente_BuscarPorPreferente", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Nombres", Nombres);
                cmd.Parameters.AddWithValue("Apellidos", Apellidos);
                cmd.Parameters.AddWithValue("Email", Email);
                cmd.Parameters.AddWithValue("Celular", Numeros);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            { 
                throw EX;
            }
        }
        public async Task<Respuesta<ClienteEnt>> Modificar(ClienteEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_Cliente_Modificar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", model.Id);
                cmd.Parameters.AddWithValue("Nombres", model.Nombres.ToUpper());
                cmd.Parameters.AddWithValue("Apellidos", model.Apellidos.ToUpper());
                cmd.Parameters.AddWithValue("Seudonimo", model.Seudonimo.ToUpper());
                cmd.Parameters.AddWithValue("IdGenero", model.IdGenero);
                cmd.Parameters.AddWithValue("Celular1", model.Celular1);
                cmd.Parameters.AddWithValue("PaisCelular1", model.PaisCelular1);
                cmd.Parameters.AddWithValue("Celular2", model.Celular2);
                cmd.Parameters.AddWithValue("PaisCelular2", model.PaisCelular2);
                cmd.Parameters.AddWithValue("Correo", model.Correo);
                cmd.Parameters.AddWithValue("IdUbicacion", model.IdUbicacion);
                cmd.Parameters.AddWithValue("Direccion", model.Direccion);
                cmd.Parameters.AddWithValue("Publicidad", model.Publicidad);
                cmd.Parameters.AddWithValue("FechaNacimiento", model.FechaNacimiento);
                cmd.Parameters.AddWithValue("IdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("UsuarioEdita", model.UsuarioEdita);
                cmd.Parameters.AddWithValue("SerieFirma", model.SerieFirma);
                cmd.Parameters.AddWithValue("SerieHuella", model.SerieHuella);
                cmd.Parameters.AddWithValue("IdDocumentoIdentidadTipo", model.IdDocumentoIdentidadTipo);
                cmd.Parameters.AddWithValue("Documento", model.Documento);
                cmd.Parameters.AddWithValue("IdMedioContacto", model.IdMedioContacto);
                cmd.Parameters.AddWithValue("OtroMedioContacto", model.OtroMedioContacto);
                cmd.Parameters.AddWithValue("Foto", model.Foto);
                cmd.Parameters.AddWithValue("IdHistoriaClinica", model.IdHistoriaClinica);
                cmd.Parameters.AddWithValue("IdEspecialista", model.IdEspecialista);
                cmd.Parameters.AddWithValue("ruc", model.ruc);
                cmd.Parameters.AddWithValue("razonSocial", model.razonSocial);
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
        public async Task<Respuesta<ClienteEnt>> ModificarFirma(ClienteEnt model)
        {

            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_Cliente_ModificarFirma", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", model.Id);
                cmd.Parameters.AddWithValue("SerieFirma", model.SerieFirma);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItem(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<int>> ValidarNumeroCelular(int idCliente, string numeroCelular1, string numeroCelular2)
        {

            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_Cliente_ValidaCelular", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                cmd.Parameters.AddWithValue("pNumeroCelular1", numeroCelular1);
                cmd.Parameters.AddWithValue("pNumeroCelular2", numeroCelular2);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadValidarCelular(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<IEnumerable<ClienteGridDTO>> ObtenerByNumeroCelular(string numero1Pais, string numero1, string numero2Pais, string numero2)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_Cliente_ObtenerByNumeroCelular", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                numero1 = numero1.Replace(" ", "");
                numero2 = numero2.Replace(" ", "");
                if (numero1Pais == "51") numero1 = numero1.Substring(0, 9);
                if (numero2Pais == "51") numero2 = numero2.Substring(0, 9);
                cmd.Parameters.AddWithValue("pNumero1", numero1);
                if (numero2 != "")
                {
                    cmd.Parameters.AddWithValue("pNumero2", numero2);
                }
                else
                {
                    cmd.Parameters.AddWithValue("pNumero2", null);
                }
                    
                var reader = await cmd.ExecuteReaderAsync();

                var output = await ReadItems(reader);
                
                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Respuesta<FichaAdmisionDTO>> ObtenerFichaAdmisionByIdCliente(int idCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_Cliente_ObtenerFichaAdmisionById", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadConsultaFicha(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Respuesta<ClienteEnt>> ActualizarFicha(FichaAdmisionEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_Cliente_ActualizarFicha", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
               
                cmd.Parameters.AddWithValue("pId", model.Id);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);

                cmd.Parameters.AddWithValue("pTieneMedicacion", model.TieneMedicacion);
                cmd.Parameters.AddWithValue("pIndiqueMedicacion", model.IndiqueMedicacion);
                cmd.Parameters.AddWithValue("pAplicaProductoTopico", model.AplicaProductoTopico);
                cmd.Parameters.AddWithValue("pAntecedentePatologico", model.AntecedentePatologico);
                cmd.Parameters.AddWithValue("pTipoCicatrizacion", model.TipoCicatrizacion);
                cmd.Parameters.AddWithValue("pBebeAlcohol", model.BebeAlcohol);
                cmd.Parameters.AddWithValue("pEsFumador", model.EsFumador);
                cmd.Parameters.AddWithValue("pObservaciones", model.Observaciones);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
                
                cmd.Parameters.AddWithValue("pCliente", JsonSerializer.Serialize(model.Cliente));
                cmd.Parameters.AddWithValue("pZonasConsultar", JsonSerializer.Serialize(model.ZonasConsultar));
                cmd.Parameters.AddWithValue("pZonasRealizar", JsonSerializer.Serialize(model.ZonasRealizar));
                cmd.Parameters.AddWithValue("pPatologias", JsonSerializer.Serialize(model.Patologias));
                cmd.Parameters.AddWithValue("pPatologiaRespuestas", JsonSerializer.Serialize(model.PatologiaRespuestas));
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadFicha(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ClienteDTO>> BuscarParametros(string p)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_Cliente_Buscar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("pParametro", p);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarParametros(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CitaDTO>> BuscarCitasAtendidas(int idCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_Cliente_CitasAtendidas", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarCitasAtendidas(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> ActualizarDocumentoIdentidad(int idCliente, ClienteDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_Cliente_ActualizarDocumentoIdentidad", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                cmd.Parameters.AddWithValue("pIdDocumentoIdentidadTipo", model.IdDocumentoIdentidadTipo);
                cmd.Parameters.AddWithValue("pDocumento", model.Documento);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioModifico);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadActualizarDocumentoIdentidad(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<ClienteNuevoDTO>> ObtenerReporteDeNuevosClientes(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_Cliente_ReporteClientesNuevos", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("pFechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaHasta);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerReporteDeNuevosClientes(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ClienteRucDTO> ObtenerRazonSocialClientebyRuc(string ruc)
        {
            try
            {
                ClienteRucDTO oClienteRuc = new ClienteRucDTO();
                var options = new RestClientOptions("https://apiperu.dev")
                {
                    MaxTimeout = -1,
                };


                var client = new RestClient(options);
                var request = new RestRequest($"/api/ruc/{ruc}", Method.Get);
                request.AddHeader("Authorization", $"Bearer {_config.TokenConsultaDocumentos}");
                request.AddHeader("Accept", "application/json");
                RestResponse response = await client.ExecuteAsync(request);
                if (response != null && response.IsSuccessStatusCode)
                {
                     oClienteRuc = JsonSerializer.Deserialize<ClienteRucDTO>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


                }
                return oClienteRuc;
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public async Task<ClienteDniDTO> ObtenerDatosClientebyDNI(string dni)
        {
            try
            {
                ClienteDniDTO oClienteDNI = new ClienteDniDTO();
                var options = new RestClientOptions("https://apiperu.dev")
                {
                    MaxTimeout = -1,
                };


                var client = new RestClient(options);
                var request = new RestRequest($"/api/dni/{dni}", Method.Get);
                request.AddHeader("Authorization", $"Bearer {_config.TokenConsultaDocumentos}");
                request.AddHeader("Accept", "application/json");
                RestResponse response = await client.ExecuteAsync(request);
                if (response != null && response.IsSuccessStatusCode)
                {
                    oClienteDNI = JsonSerializer.Deserialize<ClienteDniDTO>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


                }
                return oClienteDNI;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        //READING
        static async Task<Respuesta<int>> ReadValidarCelular(DbDataReader reader)
        {
            try
            {
                Respuesta<int> obj = new Entidad.Respuesta<int>
                {
                    Response = 0
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                }



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<ClienteDTO> Read(DbDataReader reader)
        {
            try
            {
                ClienteDTO obj = new ClienteDTO();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombres = Convert.ToString(reader["Nombres"]);
                    obj.Apellidos = Convert.ToString(reader["Apellidos"]);
                    obj.Seudonimo = Convert.ToString(reader["Seudonimo"]);
                    obj.IdGenero = reader["IdGenero"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdGenero"]);
                    obj.Celular1 = Convert.ToString(reader["Celular1"]);
                    obj.Celular2 = Convert.ToString(reader["Celular2"]);
                    obj.PaisCelular1 = Convert.ToInt32(reader["PaisCelular1"]);
                    obj.PaisCelular2 = reader["PaisCelular2"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["PaisCelular2"]);
                    obj.Correo = Convert.ToString(reader["Correo"]);
                    obj.IdMedioContacto = Convert.ToInt32(reader["IdMedioContacto"]);
                    obj.OtroMedioContacto = Convert.ToString(reader["OtroMedioContacto"]);
                    obj.Publicidad = Convert.ToString(reader["Publicidad"]);
                    obj.FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    obj.UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]);
                    obj.FechaEdita = reader["FechaEdita"] as DateTime? ?? null;
                    obj.UsuarioEdita = Convert.ToString(reader["UsuarioEdita"]);
                    obj.SerieFirma = Convert.ToString(reader["SerieFirma"]);
                    obj.SerieHuella = Convert.ToString(reader["SerieHuella"]);
                    obj.Documento = Convert.ToString(reader["Documento"]);
                    obj.IdDocumentoIdentidadTipo = reader["IdDocumentoIdentidadTipo"] as int? ?? null;

                    obj.IdUbicacion = Convert.ToString(reader["IdUbicacion"]);
                    obj.Direccion = Convert.ToString(reader["Direccion"]);
                    obj.Distrito = reader["Distrito"] as string;
                    obj.Provincia = reader["Provincia"] as string;
                    obj.Departamento = reader["Departamento"] as string;
                    obj.Foto = reader["Foto"] as string;
                    obj.IdHistoriaClinica = reader["IdHistoriaClinica"] as string;
                    obj.Genero = reader["Genero"] == DBNull.Value ? null : Convert.ToString(reader["Genero"]);

                    obj.IdEspecialista = Convert.ToInt32(reader["IdEspecialista"]);
                    obj.Especialista = reader["Especialista"] == DBNull.Value ? null : Convert.ToString(reader["Especialista"]);
                    obj.ruc = reader["ruc"] as string;
                    obj.razonSocial = reader["razonSocial"] as string;


                }

                if (reader.NextResult())
                {
                    obj.CitaNotas = new List<CitaMensajeNotaEnt>();
                    while (await reader.ReadAsync())
                    {
                        obj.CitaNotas.Add(new CitaMensajeNotaEnt
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nota = reader["Nota"].ToString(),
                            FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            IdCita = Convert.ToInt32(reader["IdCita"]),
                            IdCliente = Convert.ToInt32(reader["Idcliente"])
                        });
                    }
                }

                return obj;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }


        static async Task<List<ClienteDTO>> ReadBuscarParametros(DbDataReader reader)
        {
            try
            {
                List<ClienteDTO> collection = new List<ClienteDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteDTO obj = new ClienteDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombres = Convert.ToString(reader["Nombres"]);
                    obj.Apellidos = Convert.ToString(reader["Apellidos"]);
                    obj.Documento = Convert.ToString(reader["Documento"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        static async Task<List<CitaDTO>> ReadBuscarCitasAtendidas(DbDataReader reader)
        {
            try
            {
                List<CitaDTO> collection = new List<CitaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaDTO obj = new CitaDTO();

                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                    obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.ColorEstado = Convert.ToString(reader["EstadoColor"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        static async Task<ClienteDTO> ReadPerfil(DbDataReader reader)
        {
            try
            {
                ClienteDTO obj = new ClienteDTO();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombres = Convert.ToString(reader["Nombres"]);
                    obj.Apellidos = Convert.ToString(reader["Apellidos"]);
                    obj.Seudonimo = Convert.ToString(reader["Seudonimo"]);
                    obj.IdGenero = reader["IdGenero"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["IdGenero"]);
                    obj.Celular1 = Convert.ToString(reader["Celular1"]);
                    obj.Celular2 = Convert.ToString(reader["Celular2"]);
                    obj.Correo = Convert.ToString(reader["Correo"]);
                    obj.Direccion = Convert.ToString(reader["Direccion"]);
                    obj.MedioContacto = Convert.ToString(reader["MedioContacto"]);
                    obj.Publicidad = Convert.ToString(reader["Publicidad"]);
                    obj.FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    obj.UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]);
                    obj.FechaEdita = reader["FechaEdita"] as DateTime? ?? null;
                    obj.UsuarioEdita = Convert.ToString(reader["UsuarioEdita"]);
                    obj.SerieFirma = Convert.ToString(reader["SerieFirma"]);
                    obj.SerieHuella = Convert.ToString(reader["SerieHuella"]);
                    obj.Documento = Convert.ToString(reader["Documento"]);
                    obj.IdDocumentoIdentidadTipo = reader["IdDocumentoIdentidadTipo"] as int? ?? null;
                    obj.IdUbicacion = Convert.ToString(reader["IdUbicacion"]);
                    obj.Distrito = reader["Distrito"].ToString();
                    obj.Incidencias = Convert.ToInt32(reader["Incidencias"]);
                    obj.NumCitas = Convert.ToInt32(reader["Citas"]);

                    obj.NumCitasDepilacion = Convert.ToInt32(reader["CitasDepilacion"]);
                    obj.NumCitasBlanqueamiento = Convert.ToInt32(reader["CitasBlanqueamiento"]);
                    obj.NumCitasTratamientoFacial = Convert.ToInt32(reader["CitasTratamientoFacial"]);
                    obj.NumCitasCorporalHollywood = Convert.ToInt32(reader["CitasCorporalHollywood"]);
                    obj.NumCitasExfoliacion = Convert.ToInt32(reader["CitasExfoliacion"]);
                    obj.NumCitasDermatologia = Convert.ToInt32(reader["CitasDermatologia"]);

                    obj.NumCitasCorporal = Convert.ToInt32(reader["CitasCorporal360"]);
                    obj.NumCitasHollywood = Convert.ToInt32(reader["CitasHollywood"]);

                    obj.NumZonas = Convert.ToInt32(reader["Zonas"]);
                    obj.Foto = Convert.ToString(reader["Foto"]);
                    obj.IdHistoriaClinica = Convert.ToString(reader["IdHistoriaClinica"]);
                    obj.Genero = reader["Genero"] == DBNull.Value ? null : reader["Genero"].ToString();
                    obj.ruc = Convert.ToString(reader["ruc"]);
                    obj.razonSocial= Convert.ToString(reader["razonSocial"]);

                    obj.ClienteDocumento = reader["IdDocumentoIdentidadTipo"] == DBNull.Value ? null : new OClientedDocumentoDTO()
                    {
                        Id = reader["IdDocumentoIdentidadTipo"] as int? ?? null,
                        Documento = Convert.ToString(reader["Documento"]),
                        TipoDocumento = Convert.ToString(reader["DocumentoIdentidadTipo"])
                    };
                }



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<ClienteEnt> ReadFirma(DbDataReader reader)
        {
            try
            {
                ClienteEnt obj = new ClienteEnt();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.SerieFirma = Convert.ToString(reader["SerieFirma"]);
                }



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<ClienteDatosMaestrosDTO> ReadDatosMaestros(DbDataReader reader)
        {
            try
            {
                ClienteDatosMaestrosDTO obj = new ClienteDatosMaestrosDTO();

                IList<DocumentoIdentidadTipoEnt> tipos = new List<DocumentoIdentidadTipoEnt>();
                IList<GeneroEnt> generos = new List<GeneroEnt>();
                IList<MedioContactoEnt> medios = new List<MedioContactoEnt>();
                IList<DepartamentoDTO> departamentos = new List<DepartamentoDTO>();

                while (await reader.ReadAsync())
                {
                    DocumentoIdentidadTipoEnt tipo = new DocumentoIdentidadTipoEnt()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Descripcion = reader["Descripcion"].ToString()
                    };
                    tipos.Add(tipo);
                }

                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        GeneroEnt genero = new GeneroEnt()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Descripcion = reader["Descripcion"].ToString()
                        };
                        generos.Add(genero);
                    }

                    if (reader.NextResult())
                    {
                        while (await reader.ReadAsync())
                        {
                            MedioContactoEnt medioContacto = new MedioContactoEnt()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString()
                            };
                            medios.Add(medioContacto);
                        }

                        if (reader.NextResult())
                        {
                            while (await reader.ReadAsync())
                            {
                                DepartamentoDTO dep = new DepartamentoDTO()
                                {
                                    IdDepartamento = reader["IdDepartamento"].ToString(),
                                    Departamento = reader["Departamento"].ToString()
                                };
                                departamentos.Add(dep);
                            }
                        }
                    }
                }

                obj.MaestroDepartamento = departamentos;
                obj.MaestroDocumentoIdentidadTipo = tipos;
                obj.MaestroGenero = generos;
                obj.MaestroMedioContacto = medios;



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<Respuesta<ClienteEnt>> ReadInsertar(DbDataReader reader)
        {
            try
            {
                Respuesta<ClienteEnt> obj = new Respuesta<ClienteEnt>
                {
                    Response = new ClienteEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    obj.Response.Id = Convert.ToInt32(reader["Id"]);
                    if (obj.Exito)
                    {
                        obj.Response.Nombres = Convert.ToString(reader["Nombres"]);
                        obj.Response.Apellidos = Convert.ToString(reader["Apellidos"]);
                        obj.Response.Seudonimo = Convert.ToString(reader["Seudonimo"]);
                        obj.Response.IdGenero = reader["IdGenero"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdGenero"]);
                        obj.Response.Celular1 = Convert.ToString(reader["Celular1"]);
                        obj.Response.PaisCelular1 = Convert.ToInt32(reader["PaisCelular1"]);
                        obj.Response.Celular2 = Convert.ToString(reader["Celular2"]);
                        obj.Response.PaisCelular2 = Convert.ToInt32(reader["PaisCelular2"]);
                        obj.Response.Correo = Convert.ToString(reader["Correo"]);
                        obj.Response.IdUbicacion = Convert.ToString(reader["IdUbicacion"]);
                        obj.Response.Direccion = Convert.ToString(reader["Direccion"]);
                        obj.Response.Publicidad = Convert.ToString(reader["Publicidad"]);
                        obj.Response.FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]);
                        obj.Response.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.Response.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                        obj.Response.UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]);
                        obj.Response.SerieFirma = Convert.ToString(reader["SerieFirma"]);
                        obj.Response.SerieHuella = Convert.ToString(reader["SerieHuella"]);
                        obj.Response.IdDocumentoIdentidadTipo = reader["IdDocumentoIdentidadTipo"] as int? ?? null;
                        obj.Response.Documento = Convert.ToString(reader["Documento"]);
                        obj.Response.IdMedioContacto = Convert.ToInt32(reader["IdMedioContacto"]);
                        obj.Response.OtroMedioContacto = reader["OtroMedioContacto"].ToString();
                        obj.Response.IdPreferente = Convert.ToInt32(reader["IdPreferente"]);
                        obj.Response.ruc= Convert.ToString(reader["Ruc"]);
                        obj.Response.razonSocial= Convert.ToString(reader["RazonSocial"]);

                    }
                }



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<Respuesta<ClienteEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<ClienteEnt> obj = new Respuesta<ClienteEnt>
                {
                    Response = new ClienteEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    obj.Response.Id = Convert.ToInt32(reader["Id"]);
                    if (obj.Exito)
                    {
                        obj.Response.Nombres = Convert.ToString(reader["Nombres"]);
                        obj.Response.Apellidos = Convert.ToString(reader["Apellidos"]);
                        obj.Response.Seudonimo = Convert.ToString(reader["Seudonimo"]);
                        obj.Response.IdGenero = reader["IdGenero"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdGenero"]);
                        obj.Response.Celular1 = Convert.ToString(reader["Celular1"]);
                        obj.Response.PaisCelular1 = Convert.ToInt32(reader["PaisCelular1"]);
                        obj.Response.Celular2 = Convert.ToString(reader["Celular2"]);
                        obj.Response.PaisCelular2 = Convert.ToInt32(reader["PaisCelular2"]);
                        obj.Response.Correo = Convert.ToString(reader["Correo"]);
                        obj.Response.IdUbicacion = Convert.ToString(reader["IdUbicacion"]);
                        obj.Response.Direccion = Convert.ToString(reader["Direccion"]);
                        obj.Response.Publicidad = Convert.ToString(reader["Publicidad"]);
                        obj.Response.FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]);
                        obj.Response.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.Response.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                        obj.Response.UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]);
                        obj.Response.SerieFirma = Convert.ToString(reader["SerieFirma"]);
                        obj.Response.SerieHuella = Convert.ToString(reader["SerieHuella"]);
                        obj.Response.IdDocumentoIdentidadTipo = reader["IdDocumentoIdentidadTipo"] as int? ?? null;
                        obj.Response.Documento = Convert.ToString(reader["Documento"]);
                        obj.Response.IdMedioContacto = Convert.ToInt32(reader["IdMedioContacto"]);
                        obj.Response.OtroMedioContacto = reader["OtroMedioContacto"].ToString();
                        obj.Response.ruc = reader["ruc"].ToString();
                        obj.Response.razonSocial= reader["razonSocial"].ToString();
                    }
                }



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<IEnumerable<ClienteGridDTO>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<ClienteGridDTO> lista = new List<ClienteGridDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteGridDTO obj = new ClienteGridDTO()
                    {
                        Id = reader.GetFieldValue<int>(0),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Seudonimo = reader["Seudonimo"].ToString(),
                        IdGenero = reader["IdGenero"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdGenero"]),
                        Genero = reader["Genero"].ToString(),
                        Celular1 = reader["Celular1"].ToString(),
                        Celular2 = reader["Celular2"].ToString(),
                        Correo = reader["Correo"].ToString(),
                        Direccion = reader["Direccion"].ToString(),
                        MedioContacto = reader["MedioContacto"].ToString(),
                        Publicidad = reader["Publicidad"].ToString(),
                        FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                        SerieFirma = reader["SerieFirma"].ToString(),
                        SerieHuella = reader["SerieHuella"].ToString(),
                        Documento = reader["Documento"].ToString(),
                        IdDocumentoIdentidadTipo = reader["IdDocumentoIdentidadTipo"] as int? ?? null,
                        IdUbicacion = reader["IdUbicacion"].ToString(),
                        IdHistoriaClinica = reader["IdHistoriaClinica"].ToString(),
                        DocumentoIdentidadTipo = reader["TipoDocumento"].ToString()
                    };
                    lista.Add(obj);
                }



                return lista;
            }
            catch (Exception EX)
            {
                throw EX;
            }
           
        }
        static async Task<Respuesta<ClienteEnt>> ReadFicha(DbDataReader reader)
        {

            try
            {
                Respuesta<ClienteEnt> obj = new Entidad.Respuesta<ClienteEnt>
                {
                    Response = new ClienteEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    if (obj.Exito)
                    {
                        obj.Response.Id = Convert.ToInt32(reader["Id"]);
                    }
                }



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<Respuesta<FichaAdmisionDTO>> ReadConsultaFicha(DbDataReader reader)
        {
            try
            {
                Respuesta<FichaAdmisionDTO> obj = new Entidad.Respuesta<FichaAdmisionDTO>
                {
                    Response = new FichaAdmisionDTO()
                };

                obj.Response.Cliente = new ClienteEnt();
                while (await reader.ReadAsync())
                {
                    obj.Response.Cliente.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Response.Cliente.Nombres = reader["Nombres"].ToString();
                    obj.Response.Cliente.Apellidos = reader["Apellidos"].ToString();
                    obj.Response.Cliente.Seudonimo = reader["Seudonimo"].ToString();

                    obj.Response.Cliente.IdGenero = reader["IdGenero"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdGenero"].ToString());
                    obj.Response.Cliente.Celular1 = reader["Celular1"].ToString();
                    obj.Response.Cliente.PaisCelular1 = Convert.ToInt32(reader["PaisCelular1"].ToString());
                    obj.Response.Cliente.IdDocumentoIdentidadTipo = reader["IdDocumentoIdentidadTipo"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdDocumentoIdentidadTipo"].ToString());
                    obj.Response.Cliente.Documento = reader["Documento"].ToString();
                    obj.Response.Cliente.FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]);
                    obj.Response.Cliente.IdEstadoCivil = reader["IdEstadoCivil"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdEstadoCivil"]);
                    obj.Response.Cliente.Profesion = reader["Profesion"] == DBNull.Value ? "" : reader["Profesion"].ToString();
                    obj.Response.Cliente.Correo = reader["Correo"].ToString();
                    obj.Response.Cliente.IdUbicacion = reader["IdUbicacion"] == DBNull.Value ? "" : reader["IdUbicacion"].ToString();
                    obj.Response.Cliente.Direccion = reader["Direccion"] == DBNull.Value ? "" : reader["Direccion"].ToString();
                    obj.Response.Cliente.IdComunicacionCliente = reader["IdComunicacionCliente"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdComunicacionCliente"]);
                    obj.Response.Cliente.IdMedioContacto = reader["IdMedioContacto"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdMedioContacto"]);
                    obj.Response.Cliente.Peso = reader["Peso"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Peso"]);
                    obj.Response.Cliente.Altura = reader["Altura"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Altura"]);
                    obj.Response.Cliente.NumHijos = reader["NumHijos"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NumHijos"]);
                }

                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        obj.Response.Id = Convert.ToInt32(reader["Id"]);
                        obj.Response.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.Response.TieneMedicacion = Convert.ToBoolean(reader["TieneMedicacion"]);
                        obj.Response.IndiqueMedicacion = reader["IndiqueMedicacion"].ToString();
                        obj.Response.AplicaProductoTopico = Convert.ToBoolean(reader["AplicaProductoTopico"]);
                        obj.Response.AntecedentePatologico = Convert.ToBoolean(reader["AntecedentePatologico"]);
                        obj.Response.TipoCicatrizacion = Convert.ToInt32(reader["TipoCicatrizacion"]);
                        obj.Response.BebeAlcohol = Convert.ToInt32(reader["BebeAlcohol"]);
                        obj.Response.EsFumador = Convert.ToBoolean(reader["EsFumador"]);
                        obj.Response.Observaciones = reader["Observaciones"].ToString();
                    }
                }

                if (reader.NextResult())
                {
                    obj.Response.Patologias = new List<FichaAdmisionPatologiaDTO>();
                    while (await reader.ReadAsync())
                    {
                        obj.Response.Patologias.Add(new FichaAdmisionPatologiaDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdFichaAdmision = Convert.ToInt32(reader["IdFichaAdmision"]),
                            IdPatologia = Convert.ToInt32(reader["IdPatologia"])
                        }
                        );
                    }
                }

                if (reader.NextResult())
                {
                    obj.Response.PatologiaRespuestas = new List<FichaAdmisionPatologiaRespuestaDTO>();
                    while (await reader.ReadAsync())
                    {
                        obj.Response.PatologiaRespuestas.Add(new FichaAdmisionPatologiaRespuestaDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdFichaAdmision = Convert.ToInt32(reader["IdFichaAdmision"]),
                            IdPatologia = Convert.ToInt32(reader["IdPatologia"]),
                            IdPatologiaPregunta = Convert.ToInt32(reader["IdPatologiaPregunta"]),
                            Respuesta = reader["Respuesta"].ToString()
                        }
                        );
                    }
                }

                List<FichaAdmisionZonasDTO> fichaZonas = new List<FichaAdmisionZonasDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        fichaZonas.Add(new FichaAdmisionZonasDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdFichaAdmision = Convert.ToInt32(reader["IdFichaAdmision"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            IdTipoAccion = Convert.ToInt32(reader["IdTipoAccion"]),
                            IdZonaCorporal = Convert.ToInt32(reader["IdZonaCorporal"])
                        }
                        );
                    }
                }
                obj.Response.ZonasConsultar = fichaZonas.Where(x => x.IdTipoAccion == 1).ToList();
                obj.Response.ZonasRealizar = fichaZonas.Where(x => x.IdTipoAccion == 2).ToList();



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        static async Task<bool> ReadActualizarDocumentoIdentidad(DbDataReader reader)
        {
            try
            {
                bool Exito = false;
                string Mensaje = "";
                int ErrorNumero = 0;
                string ErrorDetalle = "";
                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito) { 
                        Mensaje = Convert.ToString(reader["Mensaje"]);
                        ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                        ErrorDetalle = reader["ErrorDetalle"].ToString();
                        throw new AlertException(Mensaje);
                    }
                }

                return Exito;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<List<ClienteNuevoDTO>> ReadObtenerReporteDeNuevosClientes(DbDataReader reader)
        {
            try
            {
                List<ClienteNuevoDTO> collection = new List<ClienteNuevoDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteNuevoDTO obj = new ClienteNuevoDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]); 
                    obj.Nombres = Convert.ToString(reader["Nombres"]);
                    obj.Apellidos = Convert.ToString(reader["Apellidos"]);
                    obj.TipoCliente = DBNull.Value == reader["TipoCliente"] ? null : Convert.ToString(reader["TipoCliente"]);
                    obj.Genero = DBNull.Value == reader["Genero"]? null : Convert.ToString(reader["Genero"]);
                    obj.Celular = DBNull.Value ==  reader["Celular"]? null : Convert.ToString(reader["Celular"]);
                    obj.Correo = DBNull.Value ==  reader["Correo"]? null : Convert.ToString(reader["Correo"]);
                    obj.NumeroDocumento = DBNull.Value ==  reader["NumeroDocumento"]? null : Convert.ToString(reader["NumeroDocumento"]);
                    obj.Documento = DBNull.Value ==  reader["Documento"]? null : Convert.ToString(reader["Documento"]);
                    obj.MedioContacto = DBNull.Value ==  reader["MedioContacto"]? null : Convert.ToString(reader["MedioContacto"]);
                    obj. FechaRegistro = Convert.ToDateTime(reader["FechaRegistra"]);
                    obj.Distrito = DBNull.Value ==  reader["Distrito"]? null : Convert.ToString(reader["Distrito"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



    }
}
