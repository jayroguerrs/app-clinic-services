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

namespace DepilZone.Data
{
    public class ZonaTratamientoDat : IZonaTratamientoDat
    {
        private readonly string _connectionString;
        public ZonaTratamientoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<ZonaTratamientoDTO>> Obtener(int IdUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ZonaTratamiento_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", IdUsuario);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtener(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ZonaTratamientoDTO>> ObtenerListadoByServicio(int idServicio, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ZonaTratamiento_ListarByServicio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerListadoByServicio(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Insertar (ZonaTratamientoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ZonaTratamiento_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadInsertar(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Modificar(ZonaTratamientoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ZonaTratamiento_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", model.Id);
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioModifico);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadModificar(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        // Readers


        static async Task<List<ZonaTratamientoDTO>> ReadObtener(DbDataReader reader)
        {

            List<ZonaTratamientoDTO> collection = new List<ZonaTratamientoDTO>();

            try
            {
                bool Exito = false;
                string ErrorMensaje = "";
                string ErrorDetalle = "";

                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito) {
                        ErrorMensaje = Convert.ToString(reader["Mensaje"]);
                        ErrorDetalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(ErrorMensaje);
                    }
                }


                if (Exito)
                {

                    if (reader.NextResult())
                    {
                        while (await reader.ReadAsync())
                        {
                            ZonaTratamientoDTO tratamiento = new ZonaTratamientoDTO()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                IdServicio = Convert.ToInt32(reader["IdServicio"]),
                                Servicio = Convert.ToString(reader["Servicio"]),
                                ServicioColor = Convert.ToString(reader["ServicioColor"]),
                                Nombre = Convert.ToString(reader["Nombre"]),
                                Descripcion = DBNull.Value == reader["Descripcion"] ? null : Convert.ToString(reader["Descripcion"]),
                                IdEstado = Convert.ToInt32(reader["IdEstado"]),
                                IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]),
                                IdUsuarioModifico = DBNull.Value == reader["IdUsuarioModifico"] ? (int?)null : Convert.ToInt32(reader["IdUsuarioModifico"]),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                                FechaModifico = DBNull.Value == reader["FechaModifico"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]),
                                UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]),
                                UsuarioModifico = DBNull.Value == reader["UsuarioModifico"] ? null : Convert.ToString(reader["UsuarioModifico"])
                            };
                            collection.Add(tratamiento);
                        }
                    }

                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<ZonaTratamientoDTO>> ReadObtenerListadoByServicio(DbDataReader reader)
        {

            List<ZonaTratamientoDTO> collection = new List<ZonaTratamientoDTO>();

            try
            {
                bool Exito = false;
                string ErrorMensaje = "";
                string ErrorDetalle = "";

                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito)
                    {
                        ErrorMensaje = Convert.ToString(reader["Mensaje"]);
                        ErrorDetalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(ErrorMensaje);
                    }
                }


                if (Exito)
                {

                    if (reader.NextResult())
                    {
                        while (await reader.ReadAsync())
                        {
                            ZonaTratamientoDTO tratamiento = new ZonaTratamientoDTO()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = Convert.ToString(reader["Nombre"]),
                                IdEstado = Convert.ToInt32(reader["IdEstado"]),
         
                            };
                            collection.Add(tratamiento);
                        }
                    }

                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<bool> ReadInsertar(DbDataReader reader)
        {

            try
            {
                bool Exito = false;
                string ErrorMensaje = "";
                string ErrorDetalle = "";

                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito)
                    {
                        ErrorMensaje = Convert.ToString(reader["Mensaje"]);
                        ErrorDetalle = Convert.ToString(reader["ErrorDetalle"]);

                        throw new AlertException(ErrorMensaje);
                    }
                }


                return Exito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<bool> ReadModificar(DbDataReader reader)
        {

            try
            {
                bool Exito = false;
                string ErrorMensaje = "";
                string ErrorDetalle = "";

                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito)
                    {
                        ErrorMensaje = Convert.ToString(reader["Mensaje"]);
                        ErrorDetalle = Convert.ToString(reader["ErrorDetalle"]);

                        throw new AlertException(ErrorMensaje);
                    }
                }


                return Exito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
