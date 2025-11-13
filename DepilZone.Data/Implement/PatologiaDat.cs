using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class PatologiaDat : IPatologiaDat
    {
        private readonly string _connectionString;
        public PatologiaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<PatologiaEnt>> ObtenerListado()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Patologia_ObtenerListado", conn)
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

        // READERS

        static async Task<IEnumerable<PatologiaEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<PatologiaEnt> lista = new List<PatologiaEnt>();
                while (await reader.ReadAsync())
                {
                    PatologiaEnt obj = new PatologiaEnt
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString()
                    };
                    lista.Add(obj);
                }
                List<PatologiaPreguntaEnt> patologiaPreguntas = new List<PatologiaPreguntaEnt>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        patologiaPreguntas.Add(new PatologiaPreguntaEnt
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdPatologia = Convert.ToInt32(reader["IdPatologia"]),
                            Pregunta = reader["Pregunta"].ToString(),
                            Orden = Convert.ToInt32(reader["Orden"])
                        });
                    }
                }
                var dataDistinct = patologiaPreguntas.Select(x => x.IdPatologia).Distinct().ToList();
                for (int i = 0; i < dataDistinct.Count; i++)
                {
                    var obj = lista.FirstOrDefault(x => x.Id == dataDistinct[i]);
                    if (obj != null)
                        obj.PatologiaPregunta = patologiaPreguntas.FindAll(x => x.IdPatologia == dataDistinct[i]).ToList();
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
