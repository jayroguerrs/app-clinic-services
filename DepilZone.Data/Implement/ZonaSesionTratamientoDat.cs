using DepilZone.Data.Interface;
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
    public class ZonaSesionTratamientoDat : IZonaSesionTratamientoDat
    {
        private readonly string _connectionString;
        public ZonaSesionTratamientoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<ZonaSesionTratamientoDTO>> ObtenerByZona(int idZona, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ZonaSesionTratamiento_ListarByZona", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pIdZona", idZona);

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


        public async Task<List<ZonaTratamientoDTO>> ObtenerByZonaSesion(int idZona, int idUsuario, int sesion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ZonaSesionTratamiento_ListarByZonaSesion", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pIdZona", idZona);
                cmd.Parameters.AddWithValue("pSesion", sesion);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerByZonaSesion(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Insertar (ZonaSesionTratamientosDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ZonaSesionTratamiento_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdZona", model.IdZona);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                var ser = JsonSerializer.Serialize(model.Tratamientos);
                cmd.Parameters.AddWithValue("pTratamientos", ser);

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


        // Readers


        static async Task<List<ZonaSesionTratamientoDTO>> ReadObtener(DbDataReader reader)
        {

            List<ZonaSesionTratamientoDTO> collection = new List<ZonaSesionTratamientoDTO>();

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
                            ZonaSesionTratamientoDTO tratamiento = new ZonaSesionTratamientoDTO()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                IdZona = Convert.ToInt32(reader["IdZona"]),
                                Sesion = Convert.ToInt32(reader["Sesion"]),
                                IdTratamientos = JsonSerializer.Deserialize<List<int>>(Convert.ToString(reader["Tratamientos"])),
                                IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]),
                                UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
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

        static async Task<List<ZonaTratamientoDTO>> ReadObtenerByZonaSesion(DbDataReader reader)
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



    }
}
