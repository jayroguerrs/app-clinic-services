using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
	public class DescuentoDat : IDescuentoDat
	{
        private readonly string _connectionString;

        public DescuentoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<DescuentoDTO>> ObtenerListado()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Descuento_ObtenerListado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
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
        

        // READERS

        static async Task<List<DescuentoDTO>> ReadItems(DbDataReader reader)
        {
            try
            {
                List<DescuentoDTO> collection = new List<DescuentoDTO>();
                while (await reader.ReadAsync())
                {
                    var obj = new DescuentoDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombre = reader["Nombre"].ToString();
                    obj.Porcentaje = Convert.ToInt32(reader["Porcentaje"]);

                    obj.UsuarioRegistro = reader["UsuarioRegistro"] == DBNull.Value ? null : reader["UsuarioRegistro"].ToString();
                    obj.UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString();

                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
       


    }
}
