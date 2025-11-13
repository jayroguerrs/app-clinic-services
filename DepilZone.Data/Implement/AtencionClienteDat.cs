using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
	public class AtencionClienteDat : IAtencionClienteDat
	{
        private readonly string _connectionString;

        public AtencionClienteDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<bool> Insertar(AtencionClienteRegistrarDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cat_AtencionCliente_Registrar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pLlaveCliente", model.LlaveCliente);
                cmd.Parameters.AddWithValue("pFecha", model.Fecha);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
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


        // READERS

        static async Task<bool> ReadInsertar(DbDataReader reader)
        {
            try
            {
                bool Exito = false;
                string Error = "";
                string ErrorDetalle = "";

                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito)
                    {
                        Error = Convert.ToString(reader["Error"]);
                        ErrorDetalle = Convert.ToString(reader["ErrorDetalle"]);

                        throw new AlertException(Error);
                    }
                }

                return Exito;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        
    }
}
