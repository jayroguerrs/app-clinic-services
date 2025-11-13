using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class PreferenteAtencionOpcionDat : IPreferenteAtencionOpcionDat
    {
        private readonly string _connectionString;
        public PreferenteAtencionOpcionDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<PreferenteAtencionOpcionDTO>> ListarByCategoria(int idCategoria)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PreferenteAtencionOpcion_ListarByCategoria", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCategoria", idCategoria);
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



        // READERS



        static async Task<List<PreferenteAtencionOpcionDTO>> ReadListar(DbDataReader reader)
        {
            try
            {
                List<PreferenteAtencionOpcionDTO> collection = new List<PreferenteAtencionOpcionDTO>();
                while (await reader.ReadAsync())
                {
                    PreferenteAtencionOpcionDTO obj = new PreferenteAtencionOpcionDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = Convert.ToString(reader["Nombre"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
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
