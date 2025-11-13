using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class PreferenteAtencionCategoriaDat : IPreferenteAtencionCategoriaDat
    {
        private readonly string _connectionString;
        public PreferenteAtencionCategoriaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<PreferenteAtencionCategoriaDTO>> Listar()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PreferenteAtencionCategoria_Listar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
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



        static async Task<List<PreferenteAtencionCategoriaDTO>> ReadListar(DbDataReader reader)
        {
            try
            {
                List<PreferenteAtencionCategoriaDTO> collection = new List<PreferenteAtencionCategoriaDTO>();
                while (await reader.ReadAsync())
                {
                    PreferenteAtencionCategoriaDTO obj = new PreferenteAtencionCategoriaDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = Convert.ToString(reader["Nombre"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
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
