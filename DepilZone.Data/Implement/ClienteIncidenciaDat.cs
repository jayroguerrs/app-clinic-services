using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data
{
    public class ClienteIncidenciaDat : IClienteIncidenciaDat
    {
        private readonly string _connectionString;

        public ClienteIncidenciaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<ClienteIncidenciaDTO>> Listar(int idSede, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteIncidencia_Listar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pFechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaHasta);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListar(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ClienteIncidenciaDTO>> ListarPorCliente(int idCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteIncidencia_ListarPorCliente", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarPorCliente(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Registrar(ClienteIncidenciaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteIncidencia_Registrar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadRegistrar(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //READING
        static async Task<List<ClienteIncidenciaDTO>> ReadListar(DbDataReader reader)
        {
            try
            {
                List<ClienteIncidenciaDTO> collection = new List<ClienteIncidenciaDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteIncidenciaDTO obj = new ClienteIncidenciaDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Cliente = Convert.ToString(reader["Cliente"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.Descripcion = Convert.ToString(reader["Descripcion"]);
                    obj.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                    obj.IdUsuarioModifico = reader["IdUsuarioModifico"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdUsuarioModifico"]);
                    obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                    obj.UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : Convert.ToString(reader["UsuarioModifico"]);

                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        static async Task<List<ClienteIncidenciaDTO>> ReadListarPorCliente(DbDataReader reader)
        {
            try
            {
                List<ClienteIncidenciaDTO> collection = new List<ClienteIncidenciaDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteIncidenciaDTO obj = new ClienteIncidenciaDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Cliente = Convert.ToString(reader["Cliente"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.Descripcion = Convert.ToString(reader["Descripcion"]);
                    obj.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                    obj.IdUsuarioModifico = reader["IdUsuarioModifico"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdUsuarioModifico"]);
                    obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                    obj.UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : Convert.ToString(reader["UsuarioModifico"]);

                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        static async Task<bool> ReadRegistrar(DbDataReader reader)
        {
            try
            {
                bool exito = false;
                string message = "";
                string errorDetalle = "";
                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        message = Convert.ToString(reader["Mensaje"]);
                        errorDetalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(message);
                    }
                }

                return exito;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
