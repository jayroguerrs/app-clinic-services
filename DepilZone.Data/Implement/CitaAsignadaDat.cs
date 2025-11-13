using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class CitaAsignadaDat : ICitaAsignadaDat
    {
        private readonly string _connectionString;

        public CitaAsignadaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<int> Insertar(CitaAsignadaListaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaAsignada_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pDatos", JsonSerializer.Serialize(model.CitasAsignadas));

                return await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerCitasAsignacion(DateTime fecha, bool sinAsignar, int idSede, int tipoCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaAsignada_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 360
                };
                cmd.Parameters.AddWithValue("pFechaCita", fecha);
                cmd.Parameters.AddWithValue("pSinAsignar", sinAsignar);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pTipoCliente", tipoCliente);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemListCitasAsignacion(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<CitaAsignadaGrillaDTO>> ObtenerCitasPasadasAsignacion(int idSede, DateTime fechaInicial, DateTime fechaFinal, bool sinAsignar, int idEstado, int idTipoCliente, int idMotivo)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaAsignada_ObtenerPasadas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 360
                };
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pFechaInicial", fechaInicial);
                cmd.Parameters.AddWithValue("pFechaFinal", fechaFinal);
                cmd.Parameters.AddWithValue("pSinAsignar", sinAsignar);
                cmd.Parameters.AddWithValue("pIdEstado", idEstado);
                cmd.Parameters.AddWithValue("pIdTipoCliente", idTipoCliente);
                cmd.Parameters.AddWithValue("pIdMotivo", idMotivo);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerCitasPasadasAsignacion(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerCitasAsignada(DateTime fecha, int idUsuarioReasignacion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaAsignada_ObtenerReasignacion", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaCita", fecha);
                cmd.Parameters.AddWithValue("pIdUsuarioReasignacion", idUsuarioReasignacion);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemList(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerByIdUsuario(int tipoAsignacion, DateTime fechaConfirmacion, int idUsuarioReasignacion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaAsignada_ObtenerByIdUsuario", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pTipoAsignacion", tipoAsignacion);
                cmd.Parameters.AddWithValue("pFechaConfirmacion", fechaConfirmacion);
                cmd.Parameters.AddWithValue("pIdUsuarioReasignacion", idUsuarioReasignacion);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemList(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerListado(DateTime fechaConfirmar, bool sinAsignar, int asignadoA, int tipoSiguiente, int asignadoPor, int idSede, int idUsuario, int tipoCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaAsignada_ObtenerListado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaConfirmar", fechaConfirmar);
                cmd.Parameters.AddWithValue("pSinAsignar", sinAsignar);
                cmd.Parameters.AddWithValue("pAsignadoA", asignadoA);
                cmd.Parameters.AddWithValue("pTipoSiguiente", tipoSiguiente);
                cmd.Parameters.AddWithValue("pAsignadoPor", asignadoPor);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pTipoCliente", tipoCliente);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerListado(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerReporte(DateTime fechaDesde, DateTime fechaHasta, bool sinAsignar, int asignadoA, int tipoSiguiente, int asignadoPor, int idSede, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaAsignada_ObtenerReporte", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaHasta);
                cmd.Parameters.AddWithValue("pSinAsignar", sinAsignar);
                cmd.Parameters.AddWithValue("pAsignadoA", asignadoA);
                cmd.Parameters.AddWithValue("pTipoSiguiente", tipoSiguiente);
                cmd.Parameters.AddWithValue("pAsignadoPor", asignadoPor);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerReporte(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<CitaAsignadaGrillaDTO>> ObtenerListadoAbandonados(DateTime fechaConfirmar, bool sinAsignar, int asignadoA, int asignadoPor, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaAbandonada_ObtenerListado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaConfirmar", fechaConfirmar);
                cmd.Parameters.AddWithValue("pSinAsignar", sinAsignar);
                cmd.Parameters.AddWithValue("pAsignadoA", asignadoA);
                cmd.Parameters.AddWithValue("pAsignadoPor", asignadoPor);
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerListadoAbandonados(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<CitaAsignadaGrillaDTO>> ObtenerCitasAbandonadasAsignacion(DateTime fecha, bool sinAsignar)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaAbandonadaAsignada_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaCita", fecha);
                cmd.Parameters.AddWithValue("pSinAsignar", sinAsignar);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerCitasAbandonadasAsignacion(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<CitaAsignadaGrillaDTO>> ObtenerCitasAbandonadasAsignacionEnEspera(DateTime fecha)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaAbandonadaAsignada_ObtenerEnEspera", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFecha", fecha);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerCitasAbandonadasAsignacion(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<CitaAsignadaGrillaDTO>> ObtenerAbandonadasByIdUsuario(int tipoAsignacion, DateTime fechaConfirmacion, int idUsuarioReasignacion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaAbandonadaAsignada_ObtenerByIdUsuario", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pTipoAsignacion", tipoAsignacion);
                cmd.Parameters.AddWithValue("pFechaConfirmacion", fechaConfirmacion);
                cmd.Parameters.AddWithValue("pIdUsuarioReasignacion", idUsuarioReasignacion);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerAbandonadasByIdUsuario(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CambiarFecha(CitaAsignadaGrillaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaAsignada_CambiarFechaLlamada", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("idCita", model.IdCita);
                cmd.Parameters.AddWithValue("idCitaAsignada", model.Id);
                cmd.Parameters.AddWithValue("idUsuarioModifica", model.IdUsuarioRegistra);
                cmd.Parameters.AddWithValue("fechaLlamada", model.FechaAsignacion);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadCambiarFecha(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> GuardarAbandonados(CitaAsignadaListaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaAbandonadosAsignada_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pDatos", JsonSerializer.Serialize(model.CitasAsignadas));

                return await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<int> AsignarAbandonadosEnEspera(CitaAsignadaListaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaAbandonadosEnEspera_Asignar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pDatos", JsonSerializer.Serialize(model.CitasAsignadas));

                return await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<int> MarcarVisto(List<CitaAsignadaEnt> citaAsignada)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaAsignada_MarcarVisto", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCitaAsignada", JsonSerializer.Serialize(citaAsignada));
                var output = await cmd.ExecuteNonQueryAsync();

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        // READERS


        static async Task<bool> ReadCambiarFecha(DbDataReader reader)
        {
            try
            {
                bool Exito = false;
                string Mensaje = "";
                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito)
                    {
                        Mensaje = Convert.ToString(reader["Mensaje"]);
                        throw new AlertException(Mensaje);
                    }
                }

                return Exito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IEnumerable<CitaAsignadaGrillaDTO>> ReadItemList(DbDataReader reader)
        {
            try
            {
                IList<CitaAsignadaGrillaDTO> lista = new List<CitaAsignadaGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaAsignadaGrillaDTO obj = new CitaAsignadaGrillaDTO
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Asignado = reader["Asignado"].ToString(),
                        FechaAsignacion = (reader["FechaAsignacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["FechaAsignacion"]),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        FechaCitaString = Convert.ToDateTime(reader["FechaCita"]).ToString("dd-MM-yyyy"),
                        FechaConfirmacion = (reader["FechaConfirmacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["FechaConfirmacion"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Tipo = Convert.ToInt32(reader["Tipo"]),
                        IdUsuarioRegistra = (reader["IdUsuarioRegistra"] == DBNull.Value) ? (int?)null : Convert.ToInt32(reader["IdUsuarioRegistra"]),
                        AsignadoPor = (reader["AsignadoPor"] == DBNull.Value) ? "" : reader["AsignadoPor"].ToString(),
                        EstadoAsignacion = (reader["EstadoAsignacion"] == DBNull.Value) ? "" : reader["EstadoAsignacion"].ToString(),
                        EstadoCita = (reader["EstadoCita"] == DBNull.Value) ? "" : reader["EstadoCita"].ToString(),
                       

                        IdEstadoAsignacion = (reader["IdEstadoAsignacion"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IdEstadoAsignacion"])
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

        static async Task<IEnumerable<CitaAsignadaGrillaDTO>> ReadItemListCitasAsignacion(DbDataReader reader)
        {
            try
            {
                IList<CitaAsignadaGrillaDTO> lista = new List<CitaAsignadaGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaAsignadaGrillaDTO obj = new CitaAsignadaGrillaDTO
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Asignado = reader["Asignado"].ToString(),
                        AsignadoA = reader["AsignadoA"].ToString(),
                        FechaAsignacion = (reader["FechaAsignacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["FechaAsignacion"]),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        FechaCitaString = Convert.ToDateTime(reader["FechaCita"]).ToString("dd-MM-yyyy"),
                        FechaConfirmacion = (reader["FechaConfirmacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["FechaConfirmacion"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Tipo = Convert.ToInt32(reader["Tipo"]),
                        IdUsuarioRegistra = (reader["IdUsuarioRegistra"] == DBNull.Value) ? (int?)null : Convert.ToInt32(reader["IdUsuarioRegistra"]),
                        AsignadoPor = (reader["AsignadoPor"] == DBNull.Value) ? "" : reader["AsignadoPor"].ToString(),
                        EstadoAsignacion = (reader["EstadoAsignacion"] == DBNull.Value) ? "" : reader["EstadoAsignacion"].ToString(),
                        EstadoCita = (reader["EstadoCita"] == DBNull.Value) ? "" : reader["EstadoCita"].ToString(),
                        HoraInicio =  reader["HoraInicio"].ToString(),

                        IdEstadoAsignacion = (reader["IdEstadoAsignacion"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IdEstadoAsignacion"])
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


        static async Task<List<CitaAsignadaGrillaDTO>> ReadObtenerCitasPasadasAsignacion(DbDataReader reader)
        {
            try
            {
                List<CitaAsignadaGrillaDTO> lista = new List<CitaAsignadaGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaAsignadaGrillaDTO obj = new CitaAsignadaGrillaDTO
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdCronograma = Convert.ToInt32(reader["IdCronograma"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Asignado = reader["Asignado"].ToString(),
                        AsignadoA = reader["AsignadoA"].ToString(),
                        FechaAsignacion = (reader["FechaAsignacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["FechaAsignacion"]),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        FechaCitaString = Convert.ToDateTime(reader["FechaCita"]).ToString("dd-MM-yyyy"),
                        FechaConfirmacion = (reader["FechaConfirmacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["FechaConfirmacion"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Tipo = Convert.ToInt32(reader["Tipo"]),
                        IdUsuarioRegistra = (reader["IdUsuarioRegistra"] == DBNull.Value) ? (int?)null : Convert.ToInt32(reader["IdUsuarioRegistra"]),
                        AsignadoPor = (reader["AsignadoPor"] == DBNull.Value) ? "" : reader["AsignadoPor"].ToString(),
                        EstadoAsignacion = (reader["EstadoAsignacion"] == DBNull.Value) ? "" : reader["EstadoAsignacion"].ToString(),
                        EstadoCita = (reader["EstadoCita"] == DBNull.Value) ? "" : reader["EstadoCita"].ToString(),
                        HoraInicio = reader["HoraInicio"].ToString(),
                        TipoCliente = Convert.ToString(reader["TipoCliente"]),

                        IdEstadoAsignacion = (reader["IdEstadoAsignacion"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IdEstadoAsignacion"])
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

        static async Task<IEnumerable<CitaAsignadaGrillaDTO>> ReadObtenerListado(DbDataReader reader)
        {
            try
            {
                IList<CitaAsignadaGrillaDTO> lista = new List<CitaAsignadaGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaAsignadaGrillaDTO obj = new CitaAsignadaGrillaDTO
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        IdCronograma = Convert.ToInt32(reader["IdCronograma"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Telefono = (reader["Telefono"] == DBNull.Value) ? "" : reader["Telefono"].ToString(),
                        Asignado = reader["Asignado"].ToString(),
                        AsignadoA = reader["AsignadoA"].ToString(),
                        FechaAsignacion = (reader["FechaAsignacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["FechaAsignacion"]),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        FechaCitaString = Convert.ToDateTime(reader["FechaCita"]).ToString("dd-MM-yyyy"),
                        FechaConfirmacion = (reader["FechaConfirmacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["FechaConfirmacion"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Tipo = Convert.ToInt32(reader["Tipo"]),
                        IdUsuarioRegistra = (reader["IdUsuarioRegistra"] == DBNull.Value) ? (int?)null : Convert.ToInt32(reader["IdUsuarioRegistra"]),
                        AsignadoPor = (reader["AsignadoPor"] == DBNull.Value) ? "" : reader["AsignadoPor"].ToString(),
                        EstadoAsignacion = (reader["EstadoAsignacion"] == DBNull.Value) ? "" : reader["EstadoAsignacion"].ToString(),
                        EstadoCita = (reader["EstadoCita"] == DBNull.Value) ? "" : reader["EstadoCita"].ToString(),
                        HoraInicio = reader["HoraInicio"].ToString(),

                        IdEstadoAsignacion = (reader["IdEstadoAsignacion"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IdEstadoAsignacion"]),
                        Motivo = (reader["Motivo"] == DBNull.Value) ? null : Convert.ToString(reader["Motivo"]),

                        IdEstadoCita = Convert.ToInt32(reader["idEstado"]),
                        ColorEstadoCita = Convert.ToString(reader["ColorEstado"]),

                        Sede = Convert.ToString(reader["Sede"]),
                        IdServicio = Convert.ToInt32(reader["IdServicio"]),

                        TipoCliente = Convert.ToString(reader["TipoCliente"]),



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

        static async Task<IEnumerable<CitaAsignadaGrillaDTO>> ReadObtenerReporte(DbDataReader reader)
        {
            try
            {
                IList<CitaAsignadaGrillaDTO> lista = new List<CitaAsignadaGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaAsignadaGrillaDTO obj = new CitaAsignadaGrillaDTO
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        IdCronograma = Convert.ToInt32(reader["IdCronograma"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Telefono = (reader["Telefono"] == DBNull.Value) ? "" : reader["Telefono"].ToString(),
                        Asignado = reader["Asignado"].ToString(),
                        AsignadoA = reader["AsignadoA"].ToString(),
                        FechaAsignacion = (reader["FechaAsignacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["FechaAsignacion"]),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        FechaCitaString = Convert.ToDateTime(reader["FechaCita"]).ToString("dd-MM-yyyy"),
                        FechaConfirmacion = (reader["FechaConfirmacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["FechaConfirmacion"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Tipo = Convert.ToInt32(reader["Tipo"]),
                        IdUsuarioRegistra = (reader["IdUsuarioRegistra"] == DBNull.Value) ? (int?)null : Convert.ToInt32(reader["IdUsuarioRegistra"]),
                        AsignadoPor = (reader["AsignadoPor"] == DBNull.Value) ? "" : reader["AsignadoPor"].ToString(),
                        EstadoAsignacion = (reader["EstadoAsignacion"] == DBNull.Value) ? "" : reader["EstadoAsignacion"].ToString(),
                        EstadoCita = (reader["EstadoCita"] == DBNull.Value) ? "" : reader["EstadoCita"].ToString(),
                        HoraInicio = reader["HoraInicio"].ToString(),

                        IdEstadoAsignacion = (reader["IdEstadoAsignacion"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IdEstadoAsignacion"]),
                        Motivo = (reader["Motivo"] == DBNull.Value) ? null : Convert.ToString(reader["Motivo"]),

                        IdEstadoCita = Convert.ToInt32(reader["idEstado"]),
                        ColorEstadoCita = Convert.ToString(reader["ColorEstado"]),

                        Sede = Convert.ToString(reader["Sede"]),
                        IdServicio = Convert.ToInt32(reader["IdServicio"]),


                        Documento = DBNull.Value == reader["Documento"] ? null : Convert.ToString(reader["Documento"]),
                        NumeroDocumento = DBNull.Value == reader["NumeroDocumento"] ? null : Convert.ToString(reader["NumeroDocumento"]),


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

        static async Task<List<CitaAsignadaGrillaDTO>> ReadObtenerCitasAbandonadasAsignacion(DbDataReader reader)
        {
            try
            {
                List<CitaAsignadaGrillaDTO> lista = new List<CitaAsignadaGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaAsignadaGrillaDTO obj = new CitaAsignadaGrillaDTO
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Asignado = reader["Asignado"].ToString(),
                        AsignadoA = reader["AsignadoA"].ToString(),
                        FechaAsignacion = (reader["FechaAsignacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["FechaAsignacion"]),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        FechaCitaString = Convert.ToDateTime(reader["FechaCita"]).ToString("dd-MM-yyyy"),
                        FechaConfirmacion = (reader["FechaConfirmacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["FechaConfirmacion"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Tipo = Convert.ToInt32(reader["Tipo"]),
                        IdUsuarioRegistra = (reader["IdUsuarioRegistra"] == DBNull.Value) ? (int?)null : Convert.ToInt32(reader["IdUsuarioRegistra"]),
                        AsignadoPor = (reader["AsignadoPor"] == DBNull.Value) ? "" : reader["AsignadoPor"].ToString(),
                        EstadoAsignacion = (reader["EstadoAsignacion"] == DBNull.Value) ? "" : reader["EstadoAsignacion"].ToString(),
                        EstadoCita = (reader["EstadoCita"] == DBNull.Value) ? "" : reader["EstadoCita"].ToString(),
                        ColorEstadoCita = (reader["ColorEstadoCita"] == DBNull.Value) ? "" : reader["ColorEstadoCita"].ToString(),
                        HoraInicio = reader["HoraInicio"].ToString(),

                        IdEstadoAsignacion = (reader["IdEstadoAsignacion"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IdEstadoAsignacion"])
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

        static async Task<List<CitaAsignadaGrillaDTO>> ReadObtenerListadoAbandonados(DbDataReader reader)
        {
            try
            {
                List<CitaAsignadaGrillaDTO> lista = new List<CitaAsignadaGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaAsignadaGrillaDTO obj = new CitaAsignadaGrillaDTO
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdCronograma = Convert.ToInt32(reader["IdCronograma"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Asignado = reader["Asignado"].ToString(),
                        AsignadoA = reader["AsignadoA"].ToString(),
                        FechaAsignacion = (reader["FechaAsignacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["FechaAsignacion"]),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        FechaCitaString = Convert.ToDateTime(reader["FechaCita"]).ToString("dd-MM-yyyy"),
                        FechaConfirmacion = (reader["FechaConfirmacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["FechaConfirmacion"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Tipo = Convert.ToInt32(reader["Tipo"]),
                        IdUsuarioRegistra = (reader["IdUsuarioRegistra"] == DBNull.Value) ? (int?)null : Convert.ToInt32(reader["IdUsuarioRegistra"]),
                        AsignadoPor = (reader["AsignadoPor"] == DBNull.Value) ? "" : reader["AsignadoPor"].ToString(),
                        EstadoAsignacion = (reader["EstadoAsignacion"] == DBNull.Value) ? "" : reader["EstadoAsignacion"].ToString(),
                        EstadoCita = (reader["EstadoCita"] == DBNull.Value) ? "" : reader["EstadoCita"].ToString(),
                        ColorEstadoCita = (reader["ColorEstadoCita"] == DBNull.Value) ? "" : reader["ColorEstadoCita"].ToString(),
                        HoraInicio = reader["HoraInicio"].ToString(),

                        IdEstadoAsignacion = (reader["IdEstadoAsignacion"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IdEstadoAsignacion"]),
                        IdServicio = Convert.ToInt32(reader["IdServicio"]),

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

        static async Task<List<CitaAsignadaGrillaDTO>> ReadObtenerAbandonadasByIdUsuario(DbDataReader reader)
        {
            try
            {
                List<CitaAsignadaGrillaDTO> lista = new List<CitaAsignadaGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaAsignadaGrillaDTO obj = new CitaAsignadaGrillaDTO
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Asignado = reader["Asignado"].ToString(),
                        FechaAsignacion = (reader["FechaAsignacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["FechaAsignacion"]),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        FechaCitaString = Convert.ToDateTime(reader["FechaCita"]).ToString("dd-MM-yyyy"),
                        FechaConfirmacion = (reader["FechaConfirmacion"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["FechaConfirmacion"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Tipo = Convert.ToInt32(reader["Tipo"]),
                        IdUsuarioRegistra = (reader["IdUsuarioRegistra"] == DBNull.Value) ? (int?)null : Convert.ToInt32(reader["IdUsuarioRegistra"]),
                        AsignadoPor = (reader["AsignadoPor"] == DBNull.Value) ? "" : reader["AsignadoPor"].ToString(),
                        EstadoAsignacion = (reader["EstadoAsignacion"] == DBNull.Value) ? "" : reader["EstadoAsignacion"].ToString(),
                        EstadoCita = (reader["EstadoCita"] == DBNull.Value) ? "" : reader["EstadoCita"].ToString(),
                        ColorEstadoCita = (reader["ColorEstadoCita"] == DBNull.Value) ? "" : reader["ColorEstadoCita"].ToString(),


                        IdEstadoAsignacion = (reader["IdEstadoAsignacion"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IdEstadoAsignacion"])
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
