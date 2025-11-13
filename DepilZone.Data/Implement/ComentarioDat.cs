using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class ComentarioDat: IComentarioDat
    {
        private readonly string _connectionString;

        public ComentarioDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<ComentarioEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Comentario_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
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


        static async Task<IEnumerable<ComentarioEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<ComentarioEnt> lista = new List<ComentarioEnt>();
                while (await reader.ReadAsync())
                {
                    ComentarioEnt obj = new ComentarioEnt
                    {
                        Id = reader.GetFieldValue<int>(0),
                        Descripcion = reader["Descripcion"].ToString()
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
