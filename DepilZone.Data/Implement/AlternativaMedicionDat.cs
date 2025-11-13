using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class AlternativaMedicionDat : IAlternativaMedicionDat
    {

        private readonly string _connectionString;

        public AlternativaMedicionDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<AlternativaMedicionDTO>> ListarByTipo(int tipo)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_AlternativaMedicion_ListarByTipo", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pTipo", tipo);
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

        // READERS

        static async Task<List<AlternativaMedicionDTO>> ReadItems(DbDataReader reader)
        {
            try
            {
                List<AlternativaMedicionDTO> collection = new List<AlternativaMedicionDTO>();
                while (await reader.ReadAsync())
                {
                    AlternativaMedicionDTO obj = new AlternativaMedicionDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        IdTipoMedicion = Convert.ToInt32(reader["IdTipoMedicion"]),
                    };
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
