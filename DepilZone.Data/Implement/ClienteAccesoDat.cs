using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data
{
    public class ClienteAccesoDat : IClienteAccesoDat
    {
        private readonly string _connectionString;

        public ClienteAccesoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<bool> ModificarCorreo(int idCliente, ClienteAccesoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteAcceso_ModificarCorreo", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                cmd.Parameters.AddWithValue("pCorreo", model.Correo);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadModificarCorreo(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        public async Task<bool> ModificarClave(int idCliente, ClienteAccesoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteAcceso_ModificarClave", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                cmd.Parameters.AddWithValue("pClave", model.Clave);
                cmd.Parameters.AddWithValue("pParametro", DBConn.ParametroCripto());
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadModificarClave(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ClienteAccesoDTO> ObtenerCredenciales(int idCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteAcceso_ObtenerCredenciales", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerCredenciales(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //READING
        static async Task<bool> ReadModificarCorreo(DbDataReader reader)
        {
            try
            {
                bool Exito = true;
                string Mensaje = "";
                string ErrorDetalle = "";
                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito)
                    {
                        Mensaje = Convert.ToString(reader["Mensaje"]);
                        ErrorDetalle = Convert.ToString(reader["ErrorDetalle"]);

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

        static async Task<bool> ReadModificarClave(DbDataReader reader)
        {
            try
            {
                bool Exito = true;
                string Mensaje = "";
                string ErrorDetalle = "";
                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito)
                    {
                        Mensaje = Convert.ToString(reader["Mensaje"]);
                        ErrorDetalle = Convert.ToString(reader["ErrorDetalle"]);

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

        static async Task<ClienteAccesoDTO> ReadObtenerCredenciales(DbDataReader reader)
        {
            try
            {
                bool Exito = true;
                string Mensaje = "";
                string ErrorDetalle = "";
                ClienteAccesoDTO obj = new ClienteAccesoDTO();
                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito)
                    {
                        Mensaje = Convert.ToString(reader["Mensaje"]);
                        ErrorDetalle = Convert.ToString(reader["ErrorDetalle"]);

                        throw new AlertException(Mensaje);
                    }
                    obj.Correo = Convert.ToString(reader["Correo"]);
                    obj.Clave = Convert.ToString(reader["Clave"]);
                    obj.Registrado = Convert.ToBoolean(reader["Registrado"]);
                }

                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

    }
}
